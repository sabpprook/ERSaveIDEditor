using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ERSaveIDEditor
{
    internal class ELSave
    {
        private readonly int header_length = 0x300;
        private readonly int hash_length = 0x10;
        private readonly int save_count = 10;
        private readonly int save_length = 0x280010;
        private readonly int footer_offset = 0x019003A0;
        private readonly int footer_length = 0x60010;
        private readonly int steamid_offset = 0x019003B4;

        private readonly int char_desc_offset = 0x01901D00;
        private readonly int char_desc_length = 0x24C;
        private readonly int char_name_offset = 0xE;
        private readonly int char_name_length = 0x20;
        private readonly int char_lvl_offset = 0x30;
        private readonly int char_time_offset = 0x34;

        private readonly ulong temp_steamid = 88888888888888888;

        private byte[] saveData { get; set; }

        public ELSave(string file)
        {
            saveData = File.ReadAllBytes(file);
        }

        public void Save(string file)
        {
            File.WriteAllBytes(file, saveData);
        }

        public UInt64 GetSteamID64()
        {
            return BitConverter.ToUInt64(saveData, steamid_offset);
        }

        public void SetSteamID64(UInt64 steamid64)
        {
            var data = BitConverter.GetBytes(steamid64);
            foreach (var offset in GetSteamID64Offsets())
            {
                Buffer.BlockCopy(data, 0, saveData, (int)offset, data.Length);
            }
            ComputeHash();
        }

        public (string name, string lvl, string time) GetSlotDesc(int slotIndex)
        {
            var offset = char_desc_offset + (slotIndex * char_desc_length);
            var name = Encoding.Unicode.GetString(saveData, offset + char_name_offset, char_name_length).Replace("\0", "");
            var lvl = BitConverter.ToUInt32(saveData, offset + char_lvl_offset);
            var time = BitConverter.ToUInt32(saveData, offset + char_time_offset);
            var ts = TimeSpan.FromSeconds(time);
            if (string.IsNullOrEmpty(name))
                return (null, null, null);
            return (name, lvl.ToString(), ts.ToString());
        }

        public string GetSlotData(int slotIndex)
        {
            var data = new byte[save_length];
            var offset = slotIndex * save_length + header_length;
            Buffer.BlockCopy(saveData, offset, data, 0, data.Length);

            var id = GetSteamID64();
            offset = 0;
            using (var ms = new MemoryStream(data))
            using (var br = new BinaryReader(ms))
            {
                br.BaseStream.Position = 0x200000;
                while (br.BaseStream.Position < (save_length - 8))
                {
                    if (id == br.ReadUInt64())
                    {
                        offset = (int)(br.BaseStream.Position - 8);
                        break;
                    }
                    br.BaseStream.Position -= 7;
                }
            }
            if (offset > 0)
            {
                var buffer = BitConverter.GetBytes(temp_steamid);
                Buffer.BlockCopy(buffer, 0, data, offset, buffer.Length);
            }

            data = GZip.compress(data);

            return Convert.ToBase64String(data);
        }

        public bool SetSlotData(int slotIndex, string base64String)
        {
            var data = Convert.FromBase64String(base64String);
            
            if (BitConverter.ToUInt16(data, 0) == 0x8B1F)
                data = GZip.decompress(data);

            if (data.Length != save_length)
                return false;

            var id = GetSteamID64();
            var offset = -1;
            using (var ms = new MemoryStream(data))
            using (var br = new BinaryReader(ms))
            {
                br.BaseStream.Position = 0x200000;
                while (br.BaseStream.Position < (save_length - 8))
                {
                    if (temp_steamid == br.ReadUInt64())
                    {
                        offset = (int)(br.BaseStream.Position - 8);
                        break;
                    }
                    br.BaseStream.Position -= 7;
                }
            }
            if (offset < 0)
                return false;

            var buffer = BitConverter.GetBytes(id);
            Buffer.BlockCopy(buffer, 0, data, offset, buffer.Length);

            offset = slotIndex * save_length + header_length;
            Buffer.BlockCopy(data, 0, saveData, offset, data.Length);

            return true;
        }

        private List<long> GetSteamID64Offsets()
        {
            var id = GetSteamID64();
            var list = new List<long>();
            list.Add(steamid_offset);
            for (int slotIndex = 0; slotIndex < save_count; slotIndex++)
            {
                var data = new byte[save_length];
                var offset = slotIndex * save_length + header_length;
                Buffer.BlockCopy(saveData, offset, data, 0, data.Length);
                using (var ms = new MemoryStream(data))
                using (var br = new BinaryReader(ms))
                {
                    br.BaseStream.Position = 0x200000;
                    while (br.BaseStream.Position < (save_length - 8))
                    {
                        if (id == br.ReadUInt64())
                        {
                            list.Add(offset + (br.BaseStream.Position - 8));
                            break;
                        }
                        br.BaseStream.Position -= 7;
                    }
                }
            }
            return list;
        }

        private void ComputeHash()
        {
            var data = new byte[footer_length - hash_length];
            Buffer.BlockCopy(saveData, (footer_offset + hash_length), data, 0, data.Length);

            var hash = MD5.Create().ComputeHash(data);
            Buffer.BlockCopy(hash, 0, saveData, footer_offset, hash.Length);

            for (int slotIndex = 0; slotIndex < save_count; slotIndex++)
            {
                data = new byte[save_length - hash_length];
                var offset = slotIndex * save_length + header_length;
                Buffer.BlockCopy(saveData, (offset + hash_length), data, 0, data.Length);

                hash = MD5.Create().ComputeHash(data);
                Buffer.BlockCopy(hash, 0, saveData, offset, hash.Length);
            }
        }
    }
}
