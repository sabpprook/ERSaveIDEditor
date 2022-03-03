using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERSaveIDEditor
{
    public partial class Form1 : Form
    {
        string SaveFile { get; set; }
        ELSave SaveData { get; set; }
        UInt64 OrigSteamID { get; set; }
        UInt64 NewSteamID { get; set; }
        List<Button> ButtonSlot { get; set; }
        Locale LocaleTable { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ButtonSlot = new List<Button>();
            ButtonSlot.Add(btn_Slot1); ButtonSlot.Add(btn_Slot2);
            ButtonSlot.Add(btn_Slot3); ButtonSlot.Add(btn_Slot4);
            ButtonSlot.Add(btn_Slot5); ButtonSlot.Add(btn_Slot6);
            ButtonSlot.Add(btn_Slot7); ButtonSlot.Add(btn_Slot8);
            ButtonSlot.Add(btn_Slot9); ButtonSlot.Add(btn_Slot10);

            tb_SteamAccount.Text += "SteamID64\t\tAccount\t\tPersonal Name\r\n";
            var list = Steam.GetLoginUsers();
            foreach (var user in list)
            {
                var line = $"{user.id}\t{user.account_name}\t{user.persona_name}\r\n";
                tb_SteamAccount.Text += line;
            }

            LocaleTable = new English();
            ChangeText(radioBtn_English.Font);
        }

        private void radioBtn_English_CheckedChanged(object sender, EventArgs e)
        {
            LocaleTable = new English();
            ChangeText(radioBtn_English.Font);
        }

        private void radioBtn_Chinese_CheckedChanged(object sender, EventArgs e)
        {
            LocaleTable = new Chinese();
            ChangeText(radioBtn_Chinese.Font);
        }

        private void ChangeText(Font font)
        {
            this.Text = LocaleTable.Str_Title();
            label1.Text = LocaleTable.Str_Save_File();
            label2.Text = LocaleTable.Str_Current_ID();
            label3.Text = LocaleTable.Str_New_ID();
            btn_LoadFile.Text = LocaleTable.Str_Load();
            btn_SaveFile.Text = LocaleTable.Str_Save();
            linkLabel_ShowGuide.Text = LocaleTable.Str_Show_Guide();
            label1.Font = label2.Font = label3.Font = linkLabel_ShowGuide.Font = font;
            btn_LoadFile.Font = btn_SaveFile.Font = font;
            foreach (var btn in ButtonSlot)
            {
                var index = int.Parse(btn.Tag.ToString());
                if (!btn.Enabled) btn.Text = LocaleTable.Str_Empty();
            }
        }

        private void btn_LoadFile_Click(object sender, EventArgs e)
        {
            tb_SaveFile.Text = tb_CurrentSteamID.Text = tb_NewSteamID.Text = string.Empty;
            tb_NewSteamID.Enabled = btn_SaveFile.Enabled = false;

            foreach (var btn in ButtonSlot)
            {
                btn.Text = LocaleTable.Str_Empty();
                btn.Enabled = false;
            }

            var ofd = new OpenFileDialog()
            {
                InitialDirectory = Environment.ExpandEnvironmentVariables("%APPDATA%\\EldenRing"),
                FileName = "ER0000.sl2",
                Filter = "Elden Ring savedata (*.sl2)|*.sl2"
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            SaveFile = ofd.FileName;
            if (!File.Exists(SaveFile))
                return;

            tb_SaveFile.Text = SaveFile;
            SaveData = new ELSave(SaveFile);

            OrigSteamID = SaveData.GetSteamID64();
            tb_CurrentSteamID.Text = OrigSteamID.ToString();

            UpdateSlot();

            tb_NewSteamID.Enabled = true;
            btn_SaveFile.Enabled = true;
        }

        private void btn_SaveFile_Click(object sender, EventArgs e)
        {
            if (UInt64.TryParse(tb_NewSteamID.Text, out UInt64 value))
            {
                if (MessageBox.Show(String.Format(LocaleTable.Msg_Save_New_SteamID64(), value), "",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                NewSteamID = value;
            }
            else
            {
                if (MessageBox.Show(String.Format(LocaleTable.Msg_Save_Orig_SteamID64(), OrigSteamID), "",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                NewSteamID = OrigSteamID;
            }

            var ofd = new OpenFileDialog()
            {
                InitialDirectory = Environment.ExpandEnvironmentVariables("%APPDATA%\\EldenRing"),
                FileName = "ER0000.sl2",
                Filter = "Elden Ring savedata (*.sl2)|*.sl2",
                CheckFileExists = false
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            SaveData.SetSteamID64(NewSteamID);
            SaveData.Save(ofd.FileName);

            MessageBox.Show(LocaleTable.Msg_File_Saved(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void UpdateSlot()
        {
            await Task.Delay(500);
            foreach (var btn in ButtonSlot)
            {
                var index = int.Parse(btn.Tag.ToString());
                var desc = SaveData.GetSlotDesc(index);
                if (desc.name != null)
                {
                    btn.Text = $"{desc.name} (LV: {desc.lvl} Played: {desc.time})";
                    btn.Enabled = true;
                }
                else
                {
                    btn.Text = LocaleTable.Str_Empty();
                    btn.Enabled = false;
                }
            }
        }

        private void btn_Slot_MouseUp(object sender, MouseEventArgs e)
        {
            var btn = sender as Button;
            var index = int.Parse(btn.Tag.ToString());
            if (e.Button == MouseButtons.Left)
            {
                var base64 = SaveData.GetSlotData(index);
                Clipboard.SetText(base64);
                MessageBox.Show(string.Format(LocaleTable.Msg_Slot_Copy_To_Clipboard(), index + 1));
            }
            if (e.Button == MouseButtons.Right)
            {
                var base64 = Clipboard.GetText();
                try
                {
                    var data = Convert.FromBase64String(base64);
                    if (data.Length == 0x280010)
                    {
                        SaveData.SetSlotData(index, base64);
                    }
                    MessageBox.Show(string.Format(LocaleTable.Msg_Slot_Write_From_Clipboard(), index + 1));
                }
                catch { }
            }
        }

        private void linkLabel_ShowGuide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Task.Run(() => MessageBox.Show(LocaleTable.Str_Guide(), "", MessageBoxButtons.OK, MessageBoxIcon.Information));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/sabpprook/ERSaveIDEditor");
        }
    }
}
