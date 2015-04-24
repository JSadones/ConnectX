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
            this.lblLinkWebclient = new System.Windows.Forms.LinkLabel();
            this.lblSideInfo = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnPlayCPU = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnMultiplayer = new System.Windows.Forms.Button();
            this.pnlEnterData = new System.Windows.Forms.Panel();
            this.lblErrorNaam = new System.Windows.Forms.Label();
            this.lblErrorDimension = new System.Windows.Forms.Label();
            this.picBoxPlayer2 = new System.Windows.Forms.PictureBox();
            this.picBoxPlayer1 = new System.Windows.Forms.PictureBox();
            this.txtBoxWinstreak = new System.Windows.Forms.TextBox();
            this.lblWinstreak = new System.Windows.Forms.Label();
            this.txtBoxWidth = new System.Windows.Forms.TextBox();
            this.txtBoxLength = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblLength = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblGridSize = new System.Windows.Forms.Label();
            this.txtBoxPlayer2Name = new System.Windows.Forms.TextBox();
            this.lblPlayer2Name = new System.Windows.Forms.Label();
            this.lblPlayer1Name = new System.Windows.Forms.Label();
            this.txtBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.picBoxBanner = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pnlMenu.SuspendLayout();
            this.pnlEnterData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLinkWebclient
            // 
            this.lblLinkWebclient.AutoSize = true;
            this.lblLinkWebclient.BackColor = System.Drawing.Color.Transparent;
            this.lblLinkWebclient.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLinkWebclient.ForeColor = System.Drawing.Color.White;
            this.lblLinkWebclient.LinkColor = System.Drawing.Color.White;
            this.lblLinkWebclient.Location = new System.Drawing.Point(163, 115);
            this.lblLinkWebclient.Name = "lblLinkWebclient";
            this.lblLinkWebclient.Size = new System.Drawing.Size(293, 24);
            this.lblLinkWebclient.TabIndex = 2;
            this.lblLinkWebclient.TabStop = true;
            this.lblLinkWebclient.Text = "Also play on our webclient !";
            this.lblLinkWebclient.Visible = false;
            // 
            // lblSideInfo
            // 
            this.lblSideInfo.AutoSize = true;
            this.lblSideInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblSideInfo.ForeColor = System.Drawing.Color.White;
            this.lblSideInfo.Location = new System.Drawing.Point(7, 618);
            this.lblSideInfo.Name = "lblSideInfo";
            this.lblSideInfo.Size = new System.Drawing.Size(476, 26);
            this.lblSideInfo.TabIndex = 3;
            this.lblSideInfo.Text = "Connect X\r\nHowest TI-S2 Project - Groep 30 : Shane Deconinck, Matthias Haelman, L" +
    "ucas Pirard, Jel Sadones";
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold);
            this.btnQuit.Location = new System.Drawing.Point(338, 316);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(529, 87);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "QUIT";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnSluiten_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Enabled = false;
            this.btnSettings.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold);
            this.btnSettings.Location = new System.Drawing.Point(338, 216);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(529, 87);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "SETTINGS";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // btnPlayCPU
            // 
            this.btnPlayCPU.BackColor = System.Drawing.SystemColors.Control;
            this.btnPlayCPU.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayCPU.Location = new System.Drawing.Point(338, 16);
            this.btnPlayCPU.Name = "btnPlayCPU";
            this.btnPlayCPU.Size = new System.Drawing.Size(529, 87);
            this.btnPlayCPU.TabIndex = 0;
            this.btnPlayCPU.Text = "PLAY AGAINST CPU";
            this.btnPlayCPU.UseVisualStyleBackColor = false;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.Controls.Add(this.btnMultiplayer);
            this.pnlMenu.Controls.Add(this.btnPlayCPU);
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.btnQuit);
            this.pnlMenu.Location = new System.Drawing.Point(2, 153);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1204, 453);
            this.pnlMenu.TabIndex = 5;
            // 
            // btnMultiplayer
            // 
            this.btnMultiplayer.BackColor = System.Drawing.SystemColors.Control;
            this.btnMultiplayer.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiplayer.Location = new System.Drawing.Point(338, 116);
            this.btnMultiplayer.Name = "btnMultiplayer";
            this.btnMultiplayer.Size = new System.Drawing.Size(529, 87);
            this.btnMultiplayer.TabIndex = 5;
            this.btnMultiplayer.Text = "PLAY (MULTIPLAYER)";
            this.btnMultiplayer.UseVisualStyleBackColor = false;
            this.btnMultiplayer.Click += new System.EventHandler(this.btnMultiplayer_Click);
            // 
            // pnlEnterData
            // 
            this.pnlEnterData.BackColor = System.Drawing.Color.Transparent;
            this.pnlEnterData.Controls.Add(this.lblErrorNaam);
            this.pnlEnterData.Controls.Add(this.lblErrorDimension);
            this.pnlEnterData.Controls.Add(this.picBoxPlayer2);
            this.pnlEnterData.Controls.Add(this.picBoxPlayer1);
            this.pnlEnterData.Controls.Add(this.txtBoxWinstreak);
            this.pnlEnterData.Controls.Add(this.lblWinstreak);
            this.pnlEnterData.Controls.Add(this.txtBoxWidth);
            this.pnlEnterData.Controls.Add(this.txtBoxLength);
            this.pnlEnterData.Controls.Add(this.btnStart);
            this.pnlEnterData.Controls.Add(this.lblLength);
            this.pnlEnterData.Controls.Add(this.lblWidth);
            this.pnlEnterData.Controls.Add(this.lblGridSize);
            this.pnlEnterData.Controls.Add(this.txtBoxPlayer2Name);
            this.pnlEnterData.Controls.Add(this.lblPlayer2Name);
            this.pnlEnterData.Controls.Add(this.lblPlayer1Name);
            this.pnlEnterData.Controls.Add(this.txtBoxPlayer1Name);
            this.pnlEnterData.Location = new System.Drawing.Point(7, 150);
            this.pnlEnterData.Name = "pnlEnterData";
            this.pnlEnterData.Size = new System.Drawing.Size(1204, 453);
            this.pnlEnterData.TabIndex = 7;
            this.pnlEnterData.Visible = false;
            // 
            // lblErrorNaam
            // 
            this.lblErrorNaam.AutoSize = true;
            this.lblErrorNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorNaam.ForeColor = System.Drawing.Color.Red;
            this.lblErrorNaam.Location = new System.Drawing.Point(483, 296);
            this.lblErrorNaam.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorNaam.Name = "lblErrorNaam";
            this.lblErrorNaam.Size = new System.Drawing.Size(0, 20);
            this.lblErrorNaam.TabIndex = 19;
            // 
            // lblErrorDimension
            // 
            this.lblErrorDimension.AutoSize = true;
            this.lblErrorDimension.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorDimension.ForeColor = System.Drawing.Color.Red;
            this.lblErrorDimension.Location = new System.Drawing.Point(483, 339);
            this.lblErrorDimension.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorDimension.Name = "lblErrorDimension";
            this.lblErrorDimension.Size = new System.Drawing.Size(0, 20);
            this.lblErrorDimension.TabIndex = 18;
            // 
            // picBoxPlayer2
            // 
            this.picBoxPlayer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.picBoxPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxPlayer2.Location = new System.Drawing.Point(1036, 103);
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
            this.picBoxPlayer1.Location = new System.Drawing.Point(1036, 28);
            this.picBoxPlayer1.Name = "picBoxPlayer1";
            this.picBoxPlayer1.Size = new System.Drawing.Size(49, 49);
            this.picBoxPlayer1.TabIndex = 16;
            this.picBoxPlayer1.TabStop = false;
            this.picBoxPlayer1.Click += new System.EventHandler(this.picBoxPlayer1_Click);
            // 
            // txtBoxWinstreak
            // 
            this.txtBoxWinstreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxWinstreak.Location = new System.Drawing.Point(776, 258);
            this.txtBoxWinstreak.Name = "txtBoxWinstreak";
            this.txtBoxWinstreak.Size = new System.Drawing.Size(59, 40);
            this.txtBoxWinstreak.TabIndex = 15;
            this.txtBoxWinstreak.Text = "4";
            this.txtBoxWinstreak.TextChanged += new System.EventHandler(this.txtBoxWinstreak_TextChanged);
            // 
            // lblWinstreak
            // 
            this.lblWinstreak.AutoSize = true;
            this.lblWinstreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinstreak.ForeColor = System.Drawing.Color.White;
            this.lblWinstreak.Location = new System.Drawing.Point(563, 253);
            this.lblWinstreak.Name = "lblWinstreak";
            this.lblWinstreak.Size = new System.Drawing.Size(184, 42);
            this.lblWinstreak.TabIndex = 14;
            this.lblWinstreak.Text = "Winstreak";
            // 
            // txtBoxWidth
            // 
            this.txtBoxWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxWidth.Location = new System.Drawing.Point(682, 190);
            this.txtBoxWidth.Name = "txtBoxWidth";
            this.txtBoxWidth.Size = new System.Drawing.Size(59, 40);
            this.txtBoxWidth.TabIndex = 13;
            this.txtBoxWidth.Text = "5";
            this.txtBoxWidth.TextChanged += new System.EventHandler(this.txtBoxWidth_TextChanged);
            // 
            // txtBoxLength
            // 
            this.txtBoxLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxLength.Location = new System.Drawing.Point(925, 193);
            this.txtBoxLength.Name = "txtBoxLength";
            this.txtBoxLength.Size = new System.Drawing.Size(59, 40);
            this.txtBoxLength.TabIndex = 12;
            this.txtBoxLength.Text = "5";
            this.txtBoxLength.TextChanged += new System.EventHandler(this.txtBoxLength_TextChanged);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(487, 379);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(254, 60);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "START GAME";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLength.ForeColor = System.Drawing.Color.White;
            this.lblLength.Location = new System.Drawing.Point(786, 188);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(133, 42);
            this.lblLength.TabIndex = 8;
            this.lblLength.Text = "Length";
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWidth.ForeColor = System.Drawing.Color.White;
            this.lblWidth.Location = new System.Drawing.Point(563, 188);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(113, 42);
            this.lblWidth.TabIndex = 7;
            this.lblWidth.Text = "Width";
            // 
            // lblGridSize
            // 
            this.lblGridSize.AutoSize = true;
            this.lblGridSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGridSize.ForeColor = System.Drawing.Color.White;
            this.lblGridSize.Location = new System.Drawing.Point(346, 188);
            this.lblGridSize.Name = "lblGridSize";
            this.lblGridSize.Size = new System.Drawing.Size(185, 42);
            this.lblGridSize.TabIndex = 5;
            this.lblGridSize.Text = "Grid size :";
            // 
            // txtBoxPlayer2Name
            // 
            this.txtBoxPlayer2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPlayer2Name.Location = new System.Drawing.Point(570, 103);
            this.txtBoxPlayer2Name.MaxLength = 10;
            this.txtBoxPlayer2Name.Name = "txtBoxPlayer2Name";
            this.txtBoxPlayer2Name.Size = new System.Drawing.Size(381, 49);
            this.txtBoxPlayer2Name.TabIndex = 4;
            this.txtBoxPlayer2Name.Text = "Bert";
            this.txtBoxPlayer2Name.TextChanged += new System.EventHandler(this.txtBoxPlayer2Name_TextChanged);
            // 
            // lblPlayer2Name
            // 
            this.lblPlayer2Name.AutoSize = true;
            this.lblPlayer2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2Name.ForeColor = System.Drawing.Color.White;
            this.lblPlayer2Name.Location = new System.Drawing.Point(253, 106);
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
            this.lblPlayer1Name.Location = new System.Drawing.Point(253, 31);
            this.lblPlayer1Name.Name = "lblPlayer1Name";
            this.lblPlayer1Name.Size = new System.Drawing.Size(288, 42);
            this.lblPlayer1Name.TabIndex = 2;
            this.lblPlayer1Name.Text = "Player 1 name : ";
            // 
            // txtBoxPlayer1Name
            // 
            this.txtBoxPlayer1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPlayer1Name.Location = new System.Drawing.Point(570, 28);
            this.txtBoxPlayer1Name.MaxLength = 10;
            this.txtBoxPlayer1Name.Name = "txtBoxPlayer1Name";
            this.txtBoxPlayer1Name.Size = new System.Drawing.Size(381, 49);
            this.txtBoxPlayer1Name.TabIndex = 0;
            this.txtBoxPlayer1Name.Text = "Dirk";
            this.txtBoxPlayer1Name.TextChanged += new System.EventHandler(this.txtBoxPlayer1Name_TextChanged);
            // 
            // picBoxBanner
            // 
            this.picBoxBanner.BackColor = System.Drawing.Color.Transparent;
            this.picBoxBanner.Image = global::ConnectXLibrary.Properties.Resources.banner1;
            this.picBoxBanner.Location = new System.Drawing.Point(222, 7);
            this.picBoxBanner.Name = "picBoxBanner";
            this.picBoxBanner.Size = new System.Drawing.Size(769, 105);
            this.picBoxBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxBanner.TabIndex = 6;
            this.picBoxBanner.TabStop = false;
            // 
            // colorDialog1
            // 
            this.colorDialog1.AllowFullOpen = false;
            this.colorDialog1.SolidColorOnly = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::ConnectXLibrary.Properties.Resources._128_184;
            this.ClientSize = new System.Drawing.Size(1208, 646);
            this.Controls.Add(this.pnlEnterData);
            this.Controls.Add(this.picBoxBanner);
            this.Controls.Add(this.lblSideInfo);
            this.Controls.Add(this.lblLinkWebclient);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1224, 685);
            this.MinimumSize = new System.Drawing.Size(967, 564);
            this.Name = "Menu";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 26);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect X";
            this.pnlMenu.ResumeLayout(false);
            this.pnlEnterData.ResumeLayout(false);
            this.pnlEnterData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblLinkWebclient;
        private System.Windows.Forms.Label lblSideInfo;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnPlayCPU;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.PictureBox picBoxBanner;
        private System.Windows.Forms.Button btnMultiplayer;
        private System.Windows.Forms.Panel pnlEnterData;
        private System.Windows.Forms.Label lblPlayer1Name;
        private System.Windows.Forms.TextBox txtBoxPlayer1Name;
        private System.Windows.Forms.Label lblGridSize;
        private System.Windows.Forms.TextBox txtBoxPlayer2Name;
        private System.Windows.Forms.Label lblPlayer2Name;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtBoxLength;
        private System.Windows.Forms.TextBox txtBoxWidth;
        private System.Windows.Forms.TextBox txtBoxWinstreak;
        private System.Windows.Forms.Label lblWinstreak;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox picBoxPlayer1;
        private System.Windows.Forms.PictureBox picBoxPlayer2;
        private System.Windows.Forms.Label lblErrorDimension;
        private System.Windows.Forms.Label lblErrorNaam;
    }
}

