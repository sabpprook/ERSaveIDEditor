namespace ERSaveIDEditor
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_SaveFile = new System.Windows.Forms.TextBox();
            this.tb_CurrentSteamID = new System.Windows.Forms.TextBox();
            this.tb_NewSteamID = new System.Windows.Forms.TextBox();
            this.btn_LoadFile = new System.Windows.Forms.Button();
            this.btn_SaveFile = new System.Windows.Forms.Button();
            this.tb_SteamAccount = new System.Windows.Forms.TextBox();
            this.btn_Slot1 = new System.Windows.Forms.Button();
            this.btn_Slot2 = new System.Windows.Forms.Button();
            this.btn_Slot3 = new System.Windows.Forms.Button();
            this.btn_Slot4 = new System.Windows.Forms.Button();
            this.btn_Slot5 = new System.Windows.Forms.Button();
            this.btn_Slot6 = new System.Windows.Forms.Button();
            this.btn_Slot7 = new System.Windows.Forms.Button();
            this.btn_Slot8 = new System.Windows.Forms.Button();
            this.btn_Slot9 = new System.Windows.Forms.Button();
            this.btn_Slot10 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.radioBtn_English = new System.Windows.Forms.RadioButton();
            this.radioBtn_Chinese = new System.Windows.Forms.RadioButton();
            this.linkLabel_ShowGuide = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Save File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Current ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 40, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "New ID:";
            // 
            // tb_SaveFile
            // 
            this.tb_SaveFile.Location = new System.Drawing.Point(101, 16);
            this.tb_SaveFile.Name = "tb_SaveFile";
            this.tb_SaveFile.ReadOnly = true;
            this.tb_SaveFile.Size = new System.Drawing.Size(460, 27);
            this.tb_SaveFile.TabIndex = 3;
            this.tb_SaveFile.TabStop = false;
            // 
            // tb_CurrentSteamID
            // 
            this.tb_CurrentSteamID.Location = new System.Drawing.Point(100, 65);
            this.tb_CurrentSteamID.Name = "tb_CurrentSteamID";
            this.tb_CurrentSteamID.ReadOnly = true;
            this.tb_CurrentSteamID.Size = new System.Drawing.Size(260, 27);
            this.tb_CurrentSteamID.TabIndex = 4;
            this.tb_CurrentSteamID.TabStop = false;
            this.tb_CurrentSteamID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_NewSteamID
            // 
            this.tb_NewSteamID.Enabled = false;
            this.tb_NewSteamID.ForeColor = System.Drawing.Color.DarkViolet;
            this.tb_NewSteamID.Location = new System.Drawing.Point(101, 114);
            this.tb_NewSteamID.Name = "tb_NewSteamID";
            this.tb_NewSteamID.Size = new System.Drawing.Size(259, 27);
            this.tb_NewSteamID.TabIndex = 5;
            this.tb_NewSteamID.TabStop = false;
            this.tb_NewSteamID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_LoadFile
            // 
            this.btn_LoadFile.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoadFile.Location = new System.Drawing.Point(411, 61);
            this.btn_LoadFile.Name = "btn_LoadFile";
            this.btn_LoadFile.Size = new System.Drawing.Size(150, 32);
            this.btn_LoadFile.TabIndex = 6;
            this.btn_LoadFile.Text = "Load";
            this.btn_LoadFile.UseVisualStyleBackColor = true;
            this.btn_LoadFile.Click += new System.EventHandler(this.btn_LoadFile_Click);
            // 
            // btn_SaveFile
            // 
            this.btn_SaveFile.Enabled = false;
            this.btn_SaveFile.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SaveFile.Location = new System.Drawing.Point(411, 110);
            this.btn_SaveFile.Name = "btn_SaveFile";
            this.btn_SaveFile.Size = new System.Drawing.Size(150, 32);
            this.btn_SaveFile.TabIndex = 7;
            this.btn_SaveFile.Text = "Save";
            this.btn_SaveFile.UseVisualStyleBackColor = true;
            this.btn_SaveFile.Click += new System.EventHandler(this.btn_SaveFile_Click);
            // 
            // tb_SteamAccount
            // 
            this.tb_SteamAccount.Location = new System.Drawing.Point(14, 172);
            this.tb_SteamAccount.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.tb_SteamAccount.Multiline = true;
            this.tb_SteamAccount.Name = "tb_SteamAccount";
            this.tb_SteamAccount.ReadOnly = true;
            this.tb_SteamAccount.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_SteamAccount.Size = new System.Drawing.Size(547, 190);
            this.tb_SteamAccount.TabIndex = 9;
            // 
            // btn_Slot1
            // 
            this.btn_Slot1.Enabled = false;
            this.btn_Slot1.Location = new System.Drawing.Point(582, 12);
            this.btn_Slot1.Name = "btn_Slot1";
            this.btn_Slot1.Size = new System.Drawing.Size(290, 30);
            this.btn_Slot1.TabIndex = 10;
            this.btn_Slot1.TabStop = false;
            this.btn_Slot1.Tag = "0";
            this.btn_Slot1.Text = "EMPTY";
            this.btn_Slot1.UseVisualStyleBackColor = true;
            this.btn_Slot1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Slot_MouseUp);
            // 
            // btn_Slot2
            // 
            this.btn_Slot2.Enabled = false;
            this.btn_Slot2.Location = new System.Drawing.Point(582, 48);
            this.btn_Slot2.Name = "btn_Slot2";
            this.btn_Slot2.Size = new System.Drawing.Size(290, 30);
            this.btn_Slot2.TabIndex = 11;
            this.btn_Slot2.TabStop = false;
            this.btn_Slot2.Tag = "1";
            this.btn_Slot2.Text = "EMPTY";
            this.btn_Slot2.UseVisualStyleBackColor = true;
            this.btn_Slot2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Slot_MouseUp);
            // 
            // btn_Slot3
            // 
            this.btn_Slot3.Enabled = false;
            this.btn_Slot3.Location = new System.Drawing.Point(582, 84);
            this.btn_Slot3.Name = "btn_Slot3";
            this.btn_Slot3.Size = new System.Drawing.Size(290, 30);
            this.btn_Slot3.TabIndex = 12;
            this.btn_Slot3.TabStop = false;
            this.btn_Slot3.Tag = "2";
            this.btn_Slot3.Text = "EMPTY";
            this.btn_Slot3.UseVisualStyleBackColor = true;
            this.btn_Slot3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Slot_MouseUp);
            // 
            // btn_Slot4
            // 
            this.btn_Slot4.Enabled = false;
            this.btn_Slot4.Location = new System.Drawing.Point(582, 120);
            this.btn_Slot4.Name = "btn_Slot4";
            this.btn_Slot4.Size = new System.Drawing.Size(290, 30);
            this.btn_Slot4.TabIndex = 13;
            this.btn_Slot4.TabStop = false;
            this.btn_Slot4.Tag = "3";
            this.btn_Slot4.Text = "EMPTY";
            this.btn_Slot4.UseVisualStyleBackColor = true;
            this.btn_Slot4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Slot_MouseUp);
            // 
            // btn_Slot5
            // 
            this.btn_Slot5.Enabled = false;
            this.btn_Slot5.Location = new System.Drawing.Point(582, 156);
            this.btn_Slot5.Name = "btn_Slot5";
            this.btn_Slot5.Size = new System.Drawing.Size(290, 30);
            this.btn_Slot5.TabIndex = 14;
            this.btn_Slot5.TabStop = false;
            this.btn_Slot5.Tag = "4";
            this.btn_Slot5.Text = "EMPTY";
            this.btn_Slot5.UseVisualStyleBackColor = true;
            this.btn_Slot5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Slot_MouseUp);
            // 
            // btn_Slot6
            // 
            this.btn_Slot6.Enabled = false;
            this.btn_Slot6.Location = new System.Drawing.Point(582, 192);
            this.btn_Slot6.Name = "btn_Slot6";
            this.btn_Slot6.Size = new System.Drawing.Size(290, 30);
            this.btn_Slot6.TabIndex = 15;
            this.btn_Slot6.TabStop = false;
            this.btn_Slot6.Tag = "5";
            this.btn_Slot6.Text = "EMPTY";
            this.btn_Slot6.UseVisualStyleBackColor = true;
            this.btn_Slot6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Slot_MouseUp);
            // 
            // btn_Slot7
            // 
            this.btn_Slot7.Enabled = false;
            this.btn_Slot7.Location = new System.Drawing.Point(582, 228);
            this.btn_Slot7.Name = "btn_Slot7";
            this.btn_Slot7.Size = new System.Drawing.Size(290, 30);
            this.btn_Slot7.TabIndex = 16;
            this.btn_Slot7.TabStop = false;
            this.btn_Slot7.Tag = "6";
            this.btn_Slot7.Text = "EMPTY";
            this.btn_Slot7.UseVisualStyleBackColor = true;
            this.btn_Slot7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Slot_MouseUp);
            // 
            // btn_Slot8
            // 
            this.btn_Slot8.Enabled = false;
            this.btn_Slot8.Location = new System.Drawing.Point(582, 264);
            this.btn_Slot8.Name = "btn_Slot8";
            this.btn_Slot8.Size = new System.Drawing.Size(290, 30);
            this.btn_Slot8.TabIndex = 17;
            this.btn_Slot8.TabStop = false;
            this.btn_Slot8.Tag = "7";
            this.btn_Slot8.Text = "EMPTY";
            this.btn_Slot8.UseVisualStyleBackColor = true;
            this.btn_Slot8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Slot_MouseUp);
            // 
            // btn_Slot9
            // 
            this.btn_Slot9.Enabled = false;
            this.btn_Slot9.Location = new System.Drawing.Point(582, 300);
            this.btn_Slot9.Name = "btn_Slot9";
            this.btn_Slot9.Size = new System.Drawing.Size(290, 30);
            this.btn_Slot9.TabIndex = 18;
            this.btn_Slot9.TabStop = false;
            this.btn_Slot9.Tag = "8";
            this.btn_Slot9.Text = "EMPTY";
            this.btn_Slot9.UseVisualStyleBackColor = true;
            this.btn_Slot9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Slot_MouseUp);
            // 
            // btn_Slot10
            // 
            this.btn_Slot10.Enabled = false;
            this.btn_Slot10.Location = new System.Drawing.Point(582, 336);
            this.btn_Slot10.Name = "btn_Slot10";
            this.btn_Slot10.Size = new System.Drawing.Size(290, 30);
            this.btn_Slot10.TabIndex = 19;
            this.btn_Slot10.TabStop = false;
            this.btn_Slot10.Tag = "9";
            this.btn_Slot10.Text = "EMPTY";
            this.btn_Slot10.UseVisualStyleBackColor = true;
            this.btn_Slot10.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Slot_MouseUp);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 200;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 40;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.DeepSkyBlue;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.DeepSkyBlue;
            this.linkLabel1.Location = new System.Drawing.Point(718, 372);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(154, 19);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "github.com/sabpprook";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // radioBtn_English
            // 
            this.radioBtn_English.AutoSize = true;
            this.radioBtn_English.Checked = true;
            this.radioBtn_English.Location = new System.Drawing.Point(394, 370);
            this.radioBtn_English.Name = "radioBtn_English";
            this.radioBtn_English.Size = new System.Drawing.Size(74, 23);
            this.radioBtn_English.TabIndex = 21;
            this.radioBtn_English.TabStop = true;
            this.radioBtn_English.Text = "English";
            this.radioBtn_English.UseVisualStyleBackColor = true;
            this.radioBtn_English.CheckedChanged += new System.EventHandler(this.radioBtn_English_CheckedChanged);
            // 
            // radioBtn_Chinese
            // 
            this.radioBtn_Chinese.AutoSize = true;
            this.radioBtn_Chinese.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBtn_Chinese.Location = new System.Drawing.Point(474, 370);
            this.radioBtn_Chinese.Name = "radioBtn_Chinese";
            this.radioBtn_Chinese.Size = new System.Drawing.Size(87, 23);
            this.radioBtn_Chinese.TabIndex = 22;
            this.radioBtn_Chinese.Text = "繁體中文";
            this.radioBtn_Chinese.UseVisualStyleBackColor = true;
            this.radioBtn_Chinese.CheckedChanged += new System.EventHandler(this.radioBtn_Chinese_CheckedChanged);
            // 
            // linkLabel_ShowGuide
            // 
            this.linkLabel_ShowGuide.ActiveLinkColor = System.Drawing.Color.Crimson;
            this.linkLabel_ShowGuide.AutoSize = true;
            this.linkLabel_ShowGuide.LinkColor = System.Drawing.Color.Crimson;
            this.linkLabel_ShowGuide.Location = new System.Drawing.Point(12, 372);
            this.linkLabel_ShowGuide.Name = "linkLabel_ShowGuide";
            this.linkLabel_ShowGuide.Size = new System.Drawing.Size(85, 19);
            this.linkLabel_ShowGuide.TabIndex = 23;
            this.linkLabel_ShowGuide.TabStop = true;
            this.linkLabel_ShowGuide.Text = "Show Guide";
            this.linkLabel_ShowGuide.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_ShowGuide_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 401);
            this.Controls.Add(this.linkLabel_ShowGuide);
            this.Controls.Add(this.radioBtn_Chinese);
            this.Controls.Add(this.radioBtn_English);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btn_Slot10);
            this.Controls.Add(this.btn_Slot9);
            this.Controls.Add(this.btn_Slot8);
            this.Controls.Add(this.btn_Slot7);
            this.Controls.Add(this.btn_Slot6);
            this.Controls.Add(this.btn_Slot5);
            this.Controls.Add(this.btn_Slot4);
            this.Controls.Add(this.btn_Slot3);
            this.Controls.Add(this.btn_Slot2);
            this.Controls.Add(this.btn_Slot1);
            this.Controls.Add(this.tb_SteamAccount);
            this.Controls.Add(this.btn_SaveFile);
            this.Controls.Add(this.btn_LoadFile);
            this.Controls.Add(this.tb_NewSteamID);
            this.Controls.Add(this.tb_CurrentSteamID);
            this.Controls.Add(this.tb_SaveFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.95D;
            this.Text = "Elden Ring Save SteamID Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_SaveFile;
        private System.Windows.Forms.TextBox tb_CurrentSteamID;
        private System.Windows.Forms.TextBox tb_NewSteamID;
        private System.Windows.Forms.Button btn_LoadFile;
        private System.Windows.Forms.Button btn_SaveFile;
        private System.Windows.Forms.TextBox tb_SteamAccount;
        private System.Windows.Forms.Button btn_Slot1;
        private System.Windows.Forms.Button btn_Slot2;
        private System.Windows.Forms.Button btn_Slot3;
        private System.Windows.Forms.Button btn_Slot4;
        private System.Windows.Forms.Button btn_Slot5;
        private System.Windows.Forms.Button btn_Slot6;
        private System.Windows.Forms.Button btn_Slot7;
        private System.Windows.Forms.Button btn_Slot8;
        private System.Windows.Forms.Button btn_Slot9;
        private System.Windows.Forms.Button btn_Slot10;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.RadioButton radioBtn_English;
        private System.Windows.Forms.RadioButton radioBtn_Chinese;
        private System.Windows.Forms.LinkLabel linkLabel_ShowGuide;
    }
}

