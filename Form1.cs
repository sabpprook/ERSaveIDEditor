using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
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
        Locale.ITranslate Locale { get; set; }
        Locale.ITranslate EN = new Locale.English();
        Locale.ITranslate ZH_TW = new Locale.TChinese();
        Locale.ITranslate ZH_CN = new Locale.SChinese();

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

#if _3DM
            radioBtn_CHS.Checked = true;
            linkLabel1.Text = "sabpprook @ 3DMGAME (ELDEN RING)";
#else
            radioBtn_English.Checked = true;
#endif

            tb_SteamAccount.Text += "SteamID64\t\tAccount\t\tPersonal Name\r\n";
            var list = Steam.GetLoginUsers();
            foreach (var user in list)
            {
                var line = $"{user.id}\t{user.account_name}\t{user.persona_name}\r\n";
                tb_SteamAccount.Text += line;
            }
        }

        private void radioBtn_English_CheckedChanged(object sender, EventArgs e)
        {
            Locale = EN;
            ChangeText(radioBtn_English.Font);
        }

        private void radioBtn_CHT_CheckedChanged(object sender, EventArgs e)
        {
            Locale = ZH_TW;
            ChangeText(radioBtn_CHT.Font);
        }

        private void radioBtn_CHS_CheckedChanged(object sender, EventArgs e)
        {
            Locale = ZH_CN;
            ChangeText(radioBtn_CHS.Font);
        }

        private void ChangeText(Font font)
        {
            this.Text = Locale.STR_TITLE;
            label1.Text = Locale.STR_SAVE_FILE;
            label2.Text = Locale.STR_CURRENT_ID;
            label3.Text = Locale.STR_NEW_ID;
            btn_LoadFile.Text = Locale.STR_LOAD;
            btn_SaveFile.Text = Locale.STR_SAVE;
            linkLabel_ShowGuide.Text = Locale.STR_SHOW_GUIDE;
            label1.Font = label2.Font = label3.Font = linkLabel_ShowGuide.Font = font;
            btn_LoadFile.Font = btn_SaveFile.Font = font;
            foreach (var btn in ButtonSlot)
            {
                var index = int.Parse(btn.Tag.ToString());
                if (!btn.Enabled) btn.Text = Locale.STR_EMPTY;
            }
            GC.Collect();
        }

        private void btn_LoadFile_Click(object sender, EventArgs e)
        {
            tb_SaveFile.Text = tb_CurrentSteamID.Text = tb_NewSteamID.Text = string.Empty;
            tb_NewSteamID.Enabled = btn_SaveFile.Enabled = false;

            foreach (var btn in ButtonSlot)
            {
                btn.Text = Locale.STR_EMPTY;
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
            var newSteamID = false;
            tb_NewSteamID.Text = Regex.Replace(tb_NewSteamID.Text, "[^0-9]", "");

            newSteamID = UInt64.TryParse(tb_NewSteamID.Text, out UInt64 value);

            if (newSteamID)
                newSteamID = !tb_CurrentSteamID.Text.Equals(value.ToString());

            if (newSteamID)
            {
                if (MessageBox.Show(String.Format(Locale.MSG_SAVE_NEW_STEAMID64, value), "",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                    return;
                NewSteamID = value;
            }
            else
            {
                NewSteamID = OrigSteamID;
            }

            var InitDir = Environment.ExpandEnvironmentVariables($"%APPDATA%\\EldenRing\\{NewSteamID}");
            if (!Directory.Exists(InitDir))
                Directory.CreateDirectory(InitDir);

            var ofd = new OpenFileDialog()
            {
                InitialDirectory = InitDir,
                FileName = "ER0000.sl2",
                Filter = "Elden Ring savedata (*.sl2)|*.sl2",
                CheckFileExists = false
            };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            SaveData.isDowngrade = (MessageBox.Show(Locale.MSG_SAVEDATA_DOWNGRADE, "", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);

            SaveData.SetSteamID64(NewSteamID);
            SaveData.Save(ofd.FileName);

            MessageBox.Show(Locale.MSG_FILE_SAVED, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void UpdateSlot()
        {
            await Task.Delay(200);
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
                    btn.Text = Locale.STR_EMPTY;
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
                MessageBox.Show(string.Format(Locale.MSG_SLOT_COPY_TO_CLIPBOARD, index + 1));
            }
            if (e.Button == MouseButtons.Right)
            {
                var base64 = Clipboard.GetText();
                try
                {
                    var data = Convert.FromBase64String(base64);
                    if (SaveData.SetSlotData(index, base64))
                    {
                        UpdateSlot();
                        MessageBox.Show(string.Format(Locale.MSG_SLOT_WRITE_FROM_CLIPBOARD, index + 1));
                    }
                }
                catch { }
            }
        }

        private void linkLabel_ShowGuide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Task.Run(() => MessageBox.Show(Locale.STR_GUIDE, "", MessageBoxButtons.OK, MessageBoxIcon.Information));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
#if _3DM
            Process.Start("https://bbs.3dmgame.com/thread-6277467-1-1.html");
#else
            Process.Start("https://github.com/sabpprook/ERSaveIDEditor");
#endif
        }
    }
}
