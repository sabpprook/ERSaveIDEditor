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
        private readonly int HEADER_LENGTH = 0x300;
        private readonly int CHECKSUM_LENGTH = 0x10;
        private readonly int SAVEDATA_SLOT = 10;
        private readonly int SAVEDATA_LENGTH = 0x280010;
        private readonly int FOOTER_OFFSET = 0x019003A0;
        private readonly int FOOTER_LENGTH = 0x60010;
        private readonly int VERSION_BIT_OFFSET = 0x019003B0;
        private readonly int STEAMID_OFFSET = 0x019003B4;

        private readonly int CHAR_DESC_OFFSET = 0x01901D00;
        private readonly int CHAR_DESC_LENGTH = 0x24C;
        private readonly int CHAR_NAME_OFFSET = 0xE;
        private readonly int CHAR_NAME_LENGTH = 0x20;
        private readonly int CHAR_LEVEL_OFFSET = 0x30;
        private readonly int CHAR_PLAYED_OFFSET = 0x34;

        private readonly ulong STEAMID_TAMPERED = 88888888888888888;

        public bool isDowngrade { get; set; }
        private byte[] SAVEDATA { get; set; }

        public ELSave(string file)
        {
            SAVEDATA = File.ReadAllBytes(file);
        }

        public void Save(string file)
        {
            File.WriteAllBytes(file, SAVEDATA);
        }

        public UInt64 GetSteamID64()
        {
            return BitConverter.ToUInt64(SAVEDATA, STEAMID_OFFSET);
        }

        public void SetSteamID64(UInt64 steamid64)
        {
            var data = BitConverter.GetBytes(steamid64);
            foreach (var offset in GetSteamID64Offsets())
            {
                Buffer.BlockCopy(data, 0, SAVEDATA, (int)offset, data.Length);
            }
            ComputeHash();
        }

        public (string name, string lvl, string time) GetSlotDesc(int slotIndex)
        {
            var offset = CHAR_DESC_OFFSET + (slotIndex * CHAR_DESC_LENGTH);
            var name = Encoding.Unicode.GetString(SAVEDATA, offset + CHAR_NAME_OFFSET, CHAR_NAME_LENGTH).Replace("\0", "");
            var lvl = BitConverter.ToUInt32(SAVEDATA, offset + CHAR_LEVEL_OFFSET);
            var time = BitConverter.ToUInt32(SAVEDATA, offset + CHAR_PLAYED_OFFSET);
            var ts = TimeSpan.FromSeconds(time);
            if (string.IsNullOrEmpty(name))
                return (null, null, null);
            return (name, lvl.ToString(), $"{(int)ts.TotalHours}:{ts.Minutes}:{ts.Seconds}");
        }

        public string GetSlotData(int slotIndex)
        {
            var data = new byte[SAVEDATA_LENGTH];
            var desc = new byte[CHAR_DESC_LENGTH];

            var data_offset = slotIndex * SAVEDATA_LENGTH + HEADER_LENGTH;
            Buffer.BlockCopy(SAVEDATA, data_offset, data, 0, data.Length);

            var desc_offset = slotIndex * CHAR_DESC_LENGTH + CHAR_DESC_OFFSET;
            Buffer.BlockCopy(SAVEDATA, desc_offset, desc, 0, desc.Length);

            data_offset = SearchSteamID(data, GetSteamID64());
            if (data_offset > 0)
            {
                var buffer = BitConverter.GetBytes(STEAMID_TAMPERED);
                Buffer.BlockCopy(buffer, 0, data, data_offset, buffer.Length);
            }

            data = GZip.compress(data.Concat(desc).ToArray());
            return Convert.ToBase64String(data);
        }

        public bool SetSlotData(int slotIndex, string base64String)
        {
            var data = Convert.FromBase64String(base64String);

            if (BitConverter.ToUInt16(data, 0) == 0x8B1F)
                data = GZip.decompress(data);

            if (data.Length != (SAVEDATA_LENGTH + CHAR_DESC_LENGTH))
                return false;

            var offset = SearchSteamID(data, STEAMID_TAMPERED);
            if (offset < 0) return false;

            var buffer = BitConverter.GetBytes(GetSteamID64());
            Buffer.BlockCopy(buffer, 0, data, offset, buffer.Length);

            offset = slotIndex * SAVEDATA_LENGTH + HEADER_LENGTH;
            Buffer.BlockCopy(data, 0, SAVEDATA, offset, SAVEDATA_LENGTH);

            offset = slotIndex * CHAR_DESC_LENGTH + CHAR_DESC_OFFSET;
            Buffer.BlockCopy(data, SAVEDATA_LENGTH, SAVEDATA, offset, CHAR_DESC_LENGTH);

            return true;
        }

        private List<long> GetSteamID64Offsets()
        {
            var id = GetSteamID64();
            var list = new List<long>();
            list.Add(STEAMID_OFFSET);
            for (int slotIndex = 0; slotIndex < SAVEDATA_SLOT; slotIndex++)
            {
                var data = new byte[SAVEDATA_LENGTH];
                var offset = slotIndex * SAVEDATA_LENGTH + HEADER_LENGTH;
                Buffer.BlockCopy(SAVEDATA, offset, data, 0, data.Length);

                var id_offset = SearchSteamID(data, id);
                if (id_offset > 0) list.Add(offset + id_offset);
            }
            return list;
        }

        private int SearchSteamID(byte[] data, ulong steamid64)
        {
            var offset = -1;
            using (var ms = new MemoryStream(data))
            using (var br = new BinaryReader(ms))
            {
                br.BaseStream.Position = 0x200000;
                while (br.BaseStream.Position < (SAVEDATA_LENGTH - 8))
                {
                    if (steamid64 == br.ReadUInt64())
                    {
                        offset = (int)(br.BaseStream.Position - 8);
                        break;
                    }
                    br.BaseStream.Position -= 7;
                }
            }
            return offset;
        }

        private void ComputeHash()
        {
            if (isDowngrade)
                SAVEDATA[VERSION_BIT_OFFSET] = 0x0D;

            var data = new byte[FOOTER_LENGTH - CHECKSUM_LENGTH];
            Buffer.BlockCopy(SAVEDATA, (FOOTER_OFFSET + CHECKSUM_LENGTH), data, 0, data.Length);

            var hash = MD5.Create().ComputeHash(data);
            Buffer.BlockCopy(hash, 0, SAVEDATA, FOOTER_OFFSET, hash.Length);

            for (int slotIndex = 0; slotIndex < SAVEDATA_SLOT; slotIndex++)
            {
                data = new byte[SAVEDATA_LENGTH - CHECKSUM_LENGTH];
                var offset = slotIndex * SAVEDATA_LENGTH + HEADER_LENGTH;
                Buffer.BlockCopy(SAVEDATA, (offset + CHECKSUM_LENGTH), data, 0, data.Length);

                hash = MD5.Create().ComputeHash(data);
                Buffer.BlockCopy(hash, 0, SAVEDATA, offset, hash.Length);
            }
        }
    }
}
