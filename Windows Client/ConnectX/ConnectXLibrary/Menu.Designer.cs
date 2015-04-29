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
            this.lblSideInfo.Location = new System.Drawing.Point(572, 452);
            this.lblSideInfo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSideInfo.Name = "lblSideInfo";
            this.lblSideInfo.Size = new System.Drawing.Size(957, 50);
            this.lblSideInfo.TabIndex = 3;
            this.lblSideInfo.Text = "Connect X\r\nHowest TI-S2 Project - Groep 30 : Shane Deconinck, Matthias Haelman, L" +
    "ucas Pirard, Jel Sadones";
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Image = ((System.Drawing.Image)(resources.GetObject("btnQuit.Image")));
            this.btnQuit.Location = new System.Drawing.Point(1836, 13);
            this.btnQuit.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(80, 77);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Enabled = false;
            this.btnSettings.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.Location = new System.Drawing.Point(1378, 62);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(338, 138);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "SETTINGS";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnPlayCPU
            // 
            this.btnPlayCPU.BackColor = System.Drawing.SystemColors.Control;
            this.btnPlayCPU.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayCPU.Location = new System.Drawing.Point(142, 62);
            this.btnPlayCPU.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnPlayCPU.Name = "btnPlayCPU";
            this.btnPlayCPU.Size = new System.Drawing.Size(296, 138);
            this.btnPlayCPU.TabIndex = 0;
            this.btnPlayCPU.Text = "PLAY CPU";
            this.btnPlayCPU.UseVisualStyleBackColor = false;
            this.btnPlayCPU.Click += new System.EventHandler(this.btnPlayCPU_Click);
            // 
            // btnMultiplayer
            // 
            this.btnMultiplayer.BackColor = System.Drawing.SystemColors.Control;
            this.btnMultiplayer.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiplayer.Location = new System.Drawing.Point(544, 62);
            this.btnMultiplayer.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnMultiplayer.Name = "btnMultiplayer";
            this.btnMultiplayer.Size = new System.Drawing.Size(386, 138);
            this.btnMultiplayer.TabIndex = 5;
            this.btnMultiplayer.Text = "PLAY (MULTIPLAYER)";
            this.btnMultiplayer.UseVisualStyleBackColor = false;
            this.btnMultiplayer.Click += new System.EventHandler(this.btnMultiplayer_Click);
            // 
            // pnlEnterData
            // 
            this.pnlEnterData.BackColor = System.Drawing.Color.Transparent;
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
            this.pnlEnterData.Location = new System.Drawing.Point(14, 250);
            this.pnlEnterData.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlEnterData.Name = "pnlEnterData";
            this.pnlEnterData.Size = new System.Drawing.Size(1878, 837);
            this.pnlEnterData.TabIndex = 7;
            this.pnlEnterData.Visible = false;
            // 
            // lblErrorStreak
            // 
            this.lblErrorStreak.AutoSize = true;
            this.lblErrorStreak.ForeColor = System.Drawing.Color.Red;
            this.lblErrorStreak.Location = new System.Drawing.Point(1042, 587);
            this.lblErrorStreak.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorStreak.Name = "lblErrorStreak";
            this.lblErrorStreak.Size = new System.Drawing.Size(0, 25);
            this.lblErrorStreak.TabIndex = 20;
            // 
            // lblErrorName
            // 
            this.lblErrorName.AutoSize = true;
            this.lblErrorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorName.ForeColor = System.Drawing.Color.Red;
            this.lblErrorName.Location = new System.Drawing.Point(1040, 288);
            this.lblErrorName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorName.Name = "lblErrorName";
            this.lblErrorName.Size = new System.Drawing.Size(0, 37);
            this.lblErrorName.TabIndex = 19;
            // 
            // lblErrorDimension
            // 
            this.lblErrorDimension.AutoSize = true;
            this.lblErrorDimension.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorDimension.ForeColor = System.Drawing.Color.Red;
            this.lblErrorDimension.Location = new System.Drawing.Point(1040, 437);
            this.lblErrorDimension.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorDimension.Name = "lblErrorDimension";
            this.lblErrorDimension.Size = new System.Drawing.Size(0, 37);
            this.lblErrorDimension.TabIndex = 18;
            // 
            // picBoxPlayer2
            // 
            this.picBoxPlayer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.picBoxPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxPlayer2.Location = new System.Drawing.Point(1324, 165);
            this.picBoxPlayer2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.picBoxPlayer2.Name = "picBoxPlayer2";
            this.picBoxPlayer2.Size = new System.Drawing.Size(96, 92);
            this.picBoxPlayer2.TabIndex = 17;
            this.picBoxPlayer2.TabStop = false;
            this.picBoxPlayer2.Click += new System.EventHandler(this.picBoxPlayer2_Click);
            // 
            // picBoxPlayer1
            // 
            this.picBoxPlayer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.picBoxPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxPlayer1.Location = new System.Drawing.Point(1324, 35);
            this.picBoxPlayer1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.picBoxPlayer1.Name = "picBoxPlayer1";
            this.picBoxPlayer1.Size = new System.Drawing.Size(96, 92);
            this.picBoxPlayer1.TabIndex = 16;
            this.picBoxPlayer1.TabStop = false;
            this.picBoxPlayer1.Click += new System.EventHandler(this.picBoxPlayer1_Click);
            // 
            // txtBoxStreakToWin
            // 
            this.txtBoxStreakToWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxStreakToWin.Location = new System.Drawing.Point(906, 560);
            this.txtBoxStreakToWin.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtBoxStreakToWin.Name = "txtBoxStreakToWin";
            this.txtBoxStreakToWin.Size = new System.Drawing.Size(86, 73);
            this.txtBoxStreakToWin.TabIndex = 5;
            this.txtBoxStreakToWin.TextChanged += new System.EventHandler(this.txtBoxStreakToWin_TextChanged);
            // 
            // lblWinstreak
            // 
            this.lblWinstreak.AutoSize = true;
            this.lblWinstreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinstreak.ForeColor = System.Drawing.Color.White;
            this.lblWinstreak.Location = new System.Drawing.Point(486, 550);
            this.lblWinstreak.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWinstreak.Name = "lblWinstreak";
            this.lblWinstreak.Size = new System.Drawing.Size(367, 85);
            this.lblWinstreak.TabIndex = 14;
            this.lblWinstreak.Text = "Winstreak";
            // 
            // txtBoxRows
            // 
            this.txtBoxRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxRows.Location = new System.Drawing.Point(906, 371);
            this.txtBoxRows.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtBoxRows.Name = "txtBoxRows";
            this.txtBoxRows.Size = new System.Drawing.Size(86, 73);
            this.txtBoxRows.TabIndex = 3;
            this.txtBoxRows.TextChanged += new System.EventHandler(this.txtBoxColumns_TextChanged);
            // 
            // txtBoxColumns
            // 
            this.txtBoxColumns.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxColumns.Location = new System.Drawing.Point(906, 467);
            this.txtBoxColumns.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtBoxColumns.Name = "txtBoxColumns";
            this.txtBoxColumns.Size = new System.Drawing.Size(86, 73);
            this.txtBoxColumns.TabIndex = 4;
            this.txtBoxColumns.TextChanged += new System.EventHandler(this.txtBoxRows_TextChanged);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(766, 696);
            this.btnStart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(508, 115);
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
            this.lblColumns.Location = new System.Drawing.Point(486, 458);
            this.lblColumns.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(329, 85);
            this.lblColumns.TabIndex = 8;
            this.lblColumns.Text = "Columns";
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRows.ForeColor = System.Drawing.Color.White;
            this.lblRows.Location = new System.Drawing.Point(486, 371);
            this.lblRows.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(221, 85);
            this.lblRows.TabIndex = 7;
            this.lblRows.Text = "Rows";
            // 
            // lblGridSize
            // 
            this.lblGridSize.AutoSize = true;
            this.lblGridSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGridSize.ForeColor = System.Drawing.Color.White;
            this.lblGridSize.Location = new System.Drawing.Point(54, 371);
            this.lblGridSize.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblGridSize.Name = "lblGridSize";
            this.lblGridSize.Size = new System.Drawing.Size(371, 85);
            this.lblGridSize.TabIndex = 5;
            this.lblGridSize.Text = "Grid size :";
            // 
            // txtBoxPlayer2Name
            // 
            this.txtBoxPlayer2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPlayer2Name.Location = new System.Drawing.Point(896, 165);
            this.txtBoxPlayer2Name.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtBoxPlayer2Name.MaxLength = 10;
            this.txtBoxPlayer2Name.Name = "txtBoxPlayer2Name";
            this.txtBoxPlayer2Name.Size = new System.Drawing.Size(374, 91);
            this.txtBoxPlayer2Name.TabIndex = 2;
            this.txtBoxPlayer2Name.Text = "Rood";
            this.txtBoxPlayer2Name.TextChanged += new System.EventHandler(this.txtBoxPlayer2Name_TextChanged);
            // 
            // lblPlayer2Name
            // 
            this.lblPlayer2Name.AutoSize = true;
            this.lblPlayer2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2Name.ForeColor = System.Drawing.Color.White;
            this.lblPlayer2Name.Location = new System.Drawing.Point(278, 171);
            this.lblPlayer2Name.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPlayer2Name.Name = "lblPlayer2Name";
            this.lblPlayer2Name.Size = new System.Drawing.Size(574, 85);
            this.lblPlayer2Name.TabIndex = 3;
            this.lblPlayer2Name.Text = "Player 2 name : ";
            // 
            // lblPlayer1Name
            // 
            this.lblPlayer1Name.AutoSize = true;
            this.lblPlayer1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1Name.ForeColor = System.Drawing.Color.White;
            this.lblPlayer1Name.Location = new System.Drawing.Point(278, 40);
            this.lblPlayer1Name.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPlayer1Name.Name = "lblPlayer1Name";
            this.lblPlayer1Name.Size = new System.Drawing.Size(574, 85);
            this.lblPlayer1Name.TabIndex = 2;
            this.lblPlayer1Name.Text = "Player 1 name : ";
            // 
            // txtBoxPlayer1Name
            // 
            this.txtBoxPlayer1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPlayer1Name.Location = new System.Drawing.Point(896, 35);
            this.txtBoxPlayer1Name.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtBoxPlayer1Name.MaxLength = 10;
            this.txtBoxPlayer1Name.Name = "txtBoxPlayer1Name";
            this.txtBoxPlayer1Name.Size = new System.Drawing.Size(374, 91);
            this.txtBoxPlayer1Name.TabIndex = 0;
            this.txtBoxPlayer1Name.Text = "Blauw";
            this.txtBoxPlayer1Name.TextChanged += new System.EventHandler(this.txtBoxPlayer1Name_TextChanged);
            // 
            // btnWebclient
            // 
            this.btnWebclient.BackColor = System.Drawing.SystemColors.Control;
            this.btnWebclient.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWebclient.Location = new System.Drawing.Point(978, 62);
            this.btnWebclient.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnWebclient.Name = "btnWebclient";
            this.btnWebclient.Size = new System.Drawing.Size(326, 138);
            this.btnWebclient.TabIndex = 8;
            this.btnWebclient.Text = "WEBCLIENT";
            this.btnWebclient.UseVisualStyleBackColor = false;
            this.btnWebclient.Click += new System.EventHandler(this.btnWebclient_Click);
            // 
            // picBoxBanner
            // 
            this.picBoxBanner.BackColor = System.Drawing.Color.Transparent;
            this.picBoxBanner.BackgroundImage = global::ConnectXLibrary.Properties.Resources.banner1;
            this.picBoxBanner.Image = global::ConnectXLibrary.Properties.Resources.banner1;
            this.picBoxBanner.Location = new System.Drawing.Point(228, 146);
            this.picBoxBanner.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.picBoxBanner.Name = "picBoxBanner";
            this.picBoxBanner.Size = new System.Drawing.Size(1538, 275);
            this.picBoxBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxBanner.TabIndex = 6;
            this.picBoxBanner.TabStop = false;
            // 
            // pnlStartScreen
            // 
            this.pnlStartScreen.BackColor = System.Drawing.Color.Transparent;
            this.pnlStartScreen.Controls.Add(this.picBoxBanner);
            this.pnlStartScreen.Controls.Add(this.lblSideInfo);
            this.pnlStartScreen.Location = new System.Drawing.Point(20, 244);
            this.pnlStartScreen.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlStartScreen.Name = "pnlStartScreen";
            this.pnlStartScreen.Size = new System.Drawing.Size(1896, 860);
            this.pnlStartScreen.TabIndex = 5;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::ConnectXLibrary.Properties.Resources._128_184;
            this.ClientSize = new System.Drawing.Size(1948, 1271);
            this.Controls.Add(this.btnWebclient);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnMultiplayer);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnPlayCPU);
            this.Controls.Add(this.pnlEnterData);
            this.Controls.Add(this.pnlStartScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1974, 1342);
            this.MinimumSize = new System.Drawing.Size(1974, 1342);
            this.Name = "Menu";
            this.Padding = new System.Windows.Forms.Padding(8, 8, 8, 50);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect X";
            this.pnlEnterData.ResumeLayout(false);
            this.pnlEnterData.PerformLayout();
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
    }
}

