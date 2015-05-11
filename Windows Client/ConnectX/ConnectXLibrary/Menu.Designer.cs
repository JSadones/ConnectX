namespace ConnectXLibrary
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.lblSideInfo = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnPlayCPU = new System.Windows.Forms.Button();
            this.btnMultiplayer = new System.Windows.Forms.Button();
            this.pnlEnterData = new System.Windows.Forms.Panel();
            this.groupDifficulty = new System.Windows.Forms.GroupBox();
            this.radioHard = new System.Windows.Forms.RadioButton();
            this.radioMedium = new System.Windows.Forms.RadioButton();
            this.radioEasy = new System.Windows.Forms.RadioButton();
            this.lblInfoHard = new System.Windows.Forms.Label();
            this.lblInfoMedium = new System.Windows.Forms.Label();
            this.lblInfoEasy = new System.Windows.Forms.Label();
            this.lblErrorStreak = new System.Windows.Forms.Label();
            this.lblErrorName = new System.Windows.Forms.Label();
            this.lblErrorDimension = new System.Windows.Forms.Label();
            this.picBoxPlayer2 = new System.Windows.Forms.PictureBox();
            this.picBoxPlayer1 = new System.Windows.Forms.PictureBox();
            this.txtBoxStreakToWin = new System.Windows.Forms.TextBox();
            this.lblWinstreak = new System.Windows.Forms.Label();
            this.txtBoxRows = new System.Windows.Forms.TextBox();
            this.txtBoxColumns = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblColumns = new System.Windows.Forms.Label();
            this.lblRows = new System.Windows.Forms.Label();
            this.lblGridSize = new System.Windows.Forms.Label();
            this.txtBoxPlayer2Name = new System.Windows.Forms.TextBox();
            this.lblPlayer2Name = new System.Windows.Forms.Label();
            this.lblPlayer1Name = new System.Windows.Forms.Label();
            this.txtBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.btnWebclient = new System.Windows.Forms.Button();
            this.picBoxBanner = new System.Windows.Forms.PictureBox();
            this.pnlStartScreen = new System.Windows.Forms.Panel();
            this.pnlEnterData.SuspendLayout();
            this.groupDifficulty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBanner)).BeginInit();
            this.pnlStartScreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSideInfo
            // 
            this.lblSideInfo.AutoSize = true;
            this.lblSideInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblSideInfo.ForeColor = System.Drawing.Color.White;
            this.lblSideInfo.Location = new System.Drawing.Point(166, 313);
            this.lblSideInfo.Name = "lblSideInfo";
            this.lblSideInfo.Size = new System.Drawing.Size(476, 26);
            this.lblSideInfo.TabIndex = 3;
            this.lblSideInfo.Text = "Connect X\r\nHowest TI-S2 Project - Groep 30 : Shane Deconinck, Matthias Haelman, L" +
    "ucas Pirard, Jel Sadones";
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.Location = new System.Drawing.Point(906, 7);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(40, 40);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Enabled = false;
            this.btnSettings.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(705, 7);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(169, 72);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "SETTINGS";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnPlayCPU
            // 
            this.btnPlayCPU.BackColor = System.Drawing.SystemColors.Control;
            this.btnPlayCPU.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayCPU.Location = new System.Drawing.Point(71, 7);
            this.btnPlayCPU.Name = "btnPlayCPU";
            this.btnPlayCPU.Size = new System.Drawing.Size(148, 72);
            this.btnPlayCPU.TabIndex = 0;
            this.btnPlayCPU.Text = "PLAY CPU";
            this.btnPlayCPU.UseVisualStyleBackColor = false;
            this.btnPlayCPU.Click += new System.EventHandler(this.btnPlayCPU_Click);
            // 
            // btnMultiplayer
            // 
            this.btnMultiplayer.BackColor = System.Drawing.SystemColors.Control;
            this.btnMultiplayer.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiplayer.Location = new System.Drawing.Point(273, 7);
            this.btnMultiplayer.Name = "btnMultiplayer";
            this.btnMultiplayer.Size = new System.Drawing.Size(193, 72);
            this.btnMultiplayer.TabIndex = 5;
            this.btnMultiplayer.Text = "PLAY (MULTIPLAYER)";
            this.btnMultiplayer.UseVisualStyleBackColor = false;
            this.btnMultiplayer.Click += new System.EventHandler(this.btnMultiplayer_Click);
            // 
            // pnlEnterData
            // 
            this.pnlEnterData.BackColor = System.Drawing.Color.Transparent;
            this.pnlEnterData.Controls.Add(this.groupDifficulty);
            this.pnlEnterData.Controls.Add(this.lblErrorStreak);
            this.pnlEnterData.Controls.Add(this.lblErrorName);
            this.pnlEnterData.Controls.Add(this.lblErrorDimension);
            this.pnlEnterData.Controls.Add(this.picBoxPlayer2);
            this.pnlEnterData.Controls.Add(this.picBoxPlayer1);
            this.pnlEnterData.Controls.Add(this.txtBoxStreakToWin);
            this.pnlEnterData.Controls.Add(this.lblWinstreak);
            this.pnlEnterData.Controls.Add(this.txtBoxRows);
            this.pnlEnterData.Controls.Add(this.txtBoxColumns);
            this.pnlEnterData.Controls.Add(this.btnStart);
            this.pnlEnterData.Controls.Add(this.lblColumns);
            this.pnlEnterData.Controls.Add(this.lblRows);
            this.pnlEnterData.Controls.Add(this.lblGridSize);
            this.pnlEnterData.Controls.Add(this.txtBoxPlayer2Name);
            this.pnlEnterData.Controls.Add(this.lblPlayer2Name);
            this.pnlEnterData.Controls.Add(this.lblPlayer1Name);
            this.pnlEnterData.Controls.Add(this.txtBoxPlayer1Name);
            this.pnlEnterData.Location = new System.Drawing.Point(7, 130);
            this.pnlEnterData.Name = "pnlEnterData";
            this.pnlEnterData.Size = new System.Drawing.Size(967, 552);
            this.pnlEnterData.TabIndex = 7;
            this.pnlEnterData.Visible = false;
            // 
            // groupDifficulty
            // 
            this.groupDifficulty.Controls.Add(this.radioHard);
            this.groupDifficulty.Controls.Add(this.radioMedium);
            this.groupDifficulty.Controls.Add(this.radioEasy);
            this.groupDifficulty.Controls.Add(this.lblInfoHard);
            this.groupDifficulty.Controls.Add(this.lblInfoMedium);
            this.groupDifficulty.Controls.Add(this.lblInfoEasy);
            this.groupDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDifficulty.ForeColor = System.Drawing.Color.White;
            this.groupDifficulty.Location = new System.Drawing.Point(689, 42);
            this.groupDifficulty.Name = "groupDifficulty";
            this.groupDifficulty.Size = new System.Drawing.Size(265, 308);
            this.groupDifficulty.TabIndex = 21;
            this.groupDifficulty.TabStop = false;
            this.groupDifficulty.Text = "AI Difficulty";
            this.groupDifficulty.Visible = false;
            // 
            // radioHard
            // 
            this.radioHard.AutoSize = true;
            this.radioHard.Location = new System.Drawing.Point(24, 219);
            this.radioHard.Name = "radioHard";
            this.radioHard.Size = new System.Drawing.Size(76, 29);
            this.radioHard.TabIndex = 8;
            this.radioHard.Text = "Hard";
            this.radioHard.UseVisualStyleBackColor = true;
            // 
            // radioMedium
            // 
            this.radioMedium.AutoSize = true;
            this.radioMedium.Checked = true;
            this.radioMedium.Location = new System.Drawing.Point(24, 131);
            this.radioMedium.Name = "radioMedium";
            this.radioMedium.Size = new System.Drawing.Size(106, 29);
            this.radioMedium.TabIndex = 7;
            this.radioMedium.TabStop = true;
            this.radioMedium.Text = "Medium";
            this.radioMedium.UseVisualStyleBackColor = true;
            // 
            // radioEasy
            // 
            this.radioEasy.AutoSize = true;
            this.radioEasy.Location = new System.Drawing.Point(24, 30);
            this.radioEasy.Name = "radioEasy";
            this.radioEasy.Size = new System.Drawing.Size(78, 29);
            this.radioEasy.TabIndex = 6;
            this.radioEasy.Text = "Easy";
            this.radioEasy.UseVisualStyleBackColor = true;
            // 
            // lblInfoHard
            // 
            this.lblInfoHard.AutoSize = true;
            this.lblInfoHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoHard.Location = new System.Drawing.Point(33, 251);
            this.lblInfoHard.Name = "lblInfoHard";
            this.lblInfoHard.Size = new System.Drawing.Size(104, 20);
            this.lblInfoHard.TabIndex = 5;
            this.lblInfoHard.Text = "(I don\'t know)";
            // 
            // lblInfoMedium
            // 
            this.lblInfoMedium.AutoSize = true;
            this.lblInfoMedium.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoMedium.Location = new System.Drawing.Point(33, 163);
            this.lblInfoMedium.Name = "lblInfoMedium";
            this.lblInfoMedium.Size = new System.Drawing.Size(104, 20);
            this.lblInfoMedium.TabIndex = 4;
            this.lblInfoMedium.Text = "(I don\'t know)";
            // 
            // lblInfoEasy
            // 
            this.lblInfoEasy.AutoSize = true;
            this.lblInfoEasy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoEasy.Location = new System.Drawing.Point(33, 62);
            this.lblInfoEasy.Name = "lblInfoEasy";
            this.lblInfoEasy.Size = new System.Drawing.Size(220, 40);
            this.lblInfoEasy.TabIndex = 3;
            this.lblInfoEasy.Text = "(AI chooses a random column\r\nhis turn.)";
            // 
            // lblErrorStreak
            // 
            this.lblErrorStreak.AutoSize = true;
            this.lblErrorStreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorStreak.ForeColor = System.Drawing.Color.Red;
            this.lblErrorStreak.Location = new System.Drawing.Point(60, 396);
            this.lblErrorStreak.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorStreak.Name = "lblErrorStreak";
            this.lblErrorStreak.Size = new System.Drawing.Size(89, 20);
            this.lblErrorStreak.TabIndex = 20;
            this.lblErrorStreak.Text = "errorStreak";
            // 
            // lblErrorName
            // 
            this.lblErrorName.AutoSize = true;
            this.lblErrorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorName.ForeColor = System.Drawing.Color.Red;
            this.lblErrorName.Location = new System.Drawing.Point(60, 173);
            this.lblErrorName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorName.Name = "lblErrorName";
            this.lblErrorName.Size = new System.Drawing.Size(84, 20);
            this.lblErrorName.TabIndex = 19;
            this.lblErrorName.Text = "errorName";
            // 
            // lblErrorDimension
            // 
            this.lblErrorDimension.AutoSize = true;
            this.lblErrorDimension.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorDimension.ForeColor = System.Drawing.Color.Red;
            this.lblErrorDimension.Location = new System.Drawing.Point(60, 367);
            this.lblErrorDimension.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorDimension.Name = "lblErrorDimension";
            this.lblErrorDimension.Size = new System.Drawing.Size(117, 20);
            this.lblErrorDimension.TabIndex = 18;
            this.lblErrorDimension.Text = "errorDimension";
            // 
            // picBoxPlayer2
            // 
            this.picBoxPlayer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.picBoxPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxPlayer2.Location = new System.Drawing.Point(580, 107);
            this.picBoxPlayer2.Name = "picBoxPlayer2";
            this.picBoxPlayer2.Size = new System.Drawing.Size(49, 49);
            this.picBoxPlayer2.TabIndex = 17;
            this.picBoxPlayer2.TabStop = false;
            this.picBoxPlayer2.Click += new System.EventHandler(this.picBoxPlayer2_Click);
            // 
            // picBoxPlayer1
            // 
            this.picBoxPlayer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.picBoxPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxPlayer1.Location = new System.Drawing.Point(580, 39);
            this.picBoxPlayer1.Name = "picBoxPlayer1";
            this.picBoxPlayer1.Size = new System.Drawing.Size(49, 49);
            this.picBoxPlayer1.TabIndex = 16;
            this.picBoxPlayer1.TabStop = false;
            this.picBoxPlayer1.Click += new System.EventHandler(this.picBoxPlayer1_Click);
            // 
            // txtBoxStreakToWin
            // 
            this.txtBoxStreakToWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxStreakToWin.Location = new System.Drawing.Point(448, 310);
            this.txtBoxStreakToWin.Name = "txtBoxStreakToWin";
            this.txtBoxStreakToWin.Size = new System.Drawing.Size(45, 40);
            this.txtBoxStreakToWin.TabIndex = 5;
            this.txtBoxStreakToWin.TextChanged += new System.EventHandler(this.txtBoxStreakToWin_TextChanged);
            // 
            // lblWinstreak
            // 
            this.lblWinstreak.AutoSize = true;
            this.lblWinstreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinstreak.ForeColor = System.Drawing.Color.White;
            this.lblWinstreak.Location = new System.Drawing.Point(238, 305);
            this.lblWinstreak.Name = "lblWinstreak";
            this.lblWinstreak.Size = new System.Drawing.Size(184, 42);
            this.lblWinstreak.TabIndex = 14;
            this.lblWinstreak.Text = "Winstreak";
            // 
            // txtBoxRows
            // 
            this.txtBoxRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxRows.Location = new System.Drawing.Point(448, 212);
            this.txtBoxRows.Name = "txtBoxRows";
            this.txtBoxRows.Size = new System.Drawing.Size(45, 40);
            this.txtBoxRows.TabIndex = 3;
            this.txtBoxRows.TextChanged += new System.EventHandler(this.txtBoxColumns_TextChanged);
            // 
            // txtBoxColumns
            // 
            this.txtBoxColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxColumns.Location = new System.Drawing.Point(448, 262);
            this.txtBoxColumns.Name = "txtBoxColumns";
            this.txtBoxColumns.Size = new System.Drawing.Size(45, 40);
            this.txtBoxColumns.TabIndex = 4;
            this.txtBoxColumns.TextChanged += new System.EventHandler(this.txtBoxRows_TextChanged);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(374, 461);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(254, 60);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "START GAME";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumns.ForeColor = System.Drawing.Color.White;
            this.lblColumns.Location = new System.Drawing.Point(238, 257);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(165, 42);
            this.lblColumns.TabIndex = 8;
            this.lblColumns.Text = "Columns";
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRows.ForeColor = System.Drawing.Color.White;
            this.lblRows.Location = new System.Drawing.Point(238, 212);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(112, 42);
            this.lblRows.TabIndex = 7;
            this.lblRows.Text = "Rows";
            // 
            // lblGridSize
            // 
            this.lblGridSize.AutoSize = true;
            this.lblGridSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGridSize.ForeColor = System.Drawing.Color.White;
            this.lblGridSize.Location = new System.Drawing.Point(22, 212);
            this.lblGridSize.Name = "lblGridSize";
            this.lblGridSize.Size = new System.Drawing.Size(185, 42);
            this.lblGridSize.TabIndex = 5;
            this.lblGridSize.Text = "Grid size :";
            // 
            // txtBoxPlayer2Name
            // 
            this.txtBoxPlayer2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPlayer2Name.Location = new System.Drawing.Point(366, 107);
            this.txtBoxPlayer2Name.MaxLength = 10;
            this.txtBoxPlayer2Name.Name = "txtBoxPlayer2Name";
            this.txtBoxPlayer2Name.Size = new System.Drawing.Size(189, 49);
            this.txtBoxPlayer2Name.TabIndex = 2;
            this.txtBoxPlayer2Name.Text = "Red";
            this.txtBoxPlayer2Name.TextChanged += new System.EventHandler(this.txtBoxPlayer2Name_TextChanged);
            // 
            // lblPlayer2Name
            // 
            this.lblPlayer2Name.AutoSize = true;
            this.lblPlayer2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2Name.ForeColor = System.Drawing.Color.White;
            this.lblPlayer2Name.Location = new System.Drawing.Point(57, 110);
            this.lblPlayer2Name.Name = "lblPlayer2Name";
            this.lblPlayer2Name.Size = new System.Drawing.Size(288, 42);
            this.lblPlayer2Name.TabIndex = 3;
            this.lblPlayer2Name.Text = "Player 2 name : ";
            // 
            // lblPlayer1Name
            // 
            this.lblPlayer1Name.AutoSize = true;
            this.lblPlayer1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1Name.ForeColor = System.Drawing.Color.White;
            this.lblPlayer1Name.Location = new System.Drawing.Point(57, 42);
            this.lblPlayer1Name.Name = "lblPlayer1Name";
            this.lblPlayer1Name.Size = new System.Drawing.Size(288, 42);
            this.lblPlayer1Name.TabIndex = 2;
            this.lblPlayer1Name.Text = "Player 1 name : ";
            // 
            // txtBoxPlayer1Name
            // 
            this.txtBoxPlayer1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPlayer1Name.Location = new System.Drawing.Point(366, 39);
            this.txtBoxPlayer1Name.MaxLength = 10;
            this.txtBoxPlayer1Name.Name = "txtBoxPlayer1Name";
            this.txtBoxPlayer1Name.Size = new System.Drawing.Size(189, 49);
            this.txtBoxPlayer1Name.TabIndex = 0;
            this.txtBoxPlayer1Name.Text = "Blue";
            this.txtBoxPlayer1Name.TextChanged += new System.EventHandler(this.txtBoxPlayer1Name_TextChanged);
            // 
            // btnWebclient
            // 
            this.btnWebclient.BackColor = System.Drawing.SystemColors.Control;
            this.btnWebclient.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWebclient.Location = new System.Drawing.Point(505, 7);
            this.btnWebclient.Name = "btnWebclient";
            this.btnWebclient.Size = new System.Drawing.Size(163, 72);
            this.btnWebclient.TabIndex = 8;
            this.btnWebclient.Text = "WEBCLIENT";
            this.btnWebclient.UseVisualStyleBackColor = false;
            this.btnWebclient.Click += new System.EventHandler(this.btnWebclient_Click);
            // 
            // picBoxBanner
            // 
            this.picBoxBanner.BackColor = System.Drawing.Color.Transparent;
            this.picBoxBanner.Image = global::ConnectXLibrary.Properties.Resources.banner;
            this.picBoxBanner.Location = new System.Drawing.Point(75, 193);
            this.picBoxBanner.Name = "picBoxBanner";
            this.picBoxBanner.Size = new System.Drawing.Size(769, 112);
            this.picBoxBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxBanner.TabIndex = 6;
            this.picBoxBanner.TabStop = false;
            // 
            // pnlStartScreen
            // 
            this.pnlStartScreen.BackColor = System.Drawing.Color.Transparent;
            this.pnlStartScreen.Controls.Add(this.picBoxBanner);
            this.pnlStartScreen.Controls.Add(this.lblSideInfo);
            this.pnlStartScreen.Location = new System.Drawing.Point(10, 127);
            this.pnlStartScreen.Name = "pnlStartScreen";
            this.pnlStartScreen.Size = new System.Drawing.Size(967, 558);
            this.pnlStartScreen.TabIndex = 5;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::ConnectXLibrary.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(984, 693);
            this.Controls.Add(this.btnWebclient);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnMultiplayer);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnPlayCPU);
            this.Controls.Add(this.pnlEnterData);
            this.Controls.Add(this.pnlStartScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 732);
            this.MinimumSize = new System.Drawing.Size(1000, 732);
            this.Name = "Menu";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 26);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect X";
            this.pnlEnterData.ResumeLayout(false);
            this.pnlEnterData.PerformLayout();
            this.groupDifficulty.ResumeLayout(false);
            this.groupDifficulty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBanner)).EndInit();
            this.pnlStartScreen.ResumeLayout(false);
            this.pnlStartScreen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSideInfo;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnPlayCPU;
        private System.Windows.Forms.Button btnMultiplayer;
        private System.Windows.Forms.Panel pnlEnterData;
        private System.Windows.Forms.Label lblPlayer1Name;
        private System.Windows.Forms.TextBox txtBoxPlayer1Name;
        private System.Windows.Forms.Label lblGridSize;
        private System.Windows.Forms.TextBox txtBoxPlayer2Name;
        private System.Windows.Forms.Label lblPlayer2Name;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtBoxColumns;
        private System.Windows.Forms.TextBox txtBoxRows;
        private System.Windows.Forms.TextBox txtBoxStreakToWin;
        private System.Windows.Forms.Label lblWinstreak;
        private System.Windows.Forms.PictureBox picBoxPlayer1;
        private System.Windows.Forms.PictureBox picBoxPlayer2;
        private System.Windows.Forms.Label lblErrorDimension;
        private System.Windows.Forms.Label lblErrorName;
        private System.Windows.Forms.Label lblErrorStreak;
        private System.Windows.Forms.Button btnWebclient;
        private System.Windows.Forms.PictureBox picBoxBanner;
		private System.Windows.Forms.Panel pnlStartScreen;
        private System.Windows.Forms.GroupBox groupDifficulty;
        private System.Windows.Forms.Label lblInfoEasy;
        private System.Windows.Forms.Label lblInfoHard;
        private System.Windows.Forms.Label lblInfoMedium;
        private System.Windows.Forms.RadioButton radioHard;
        private System.Windows.Forms.RadioButton radioMedium;
        private System.Windows.Forms.RadioButton radioEasy;
    }
}

