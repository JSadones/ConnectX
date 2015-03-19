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
            this.picBoxBanner = new System.Windows.Forms.PictureBox();
            this.pnlMenu.SuspendLayout();
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
            this.lblLinkWebclient.Location = new System.Drawing.Point(278, 148);
            this.lblLinkWebclient.Name = "lblLinkWebclient";
            this.lblLinkWebclient.Size = new System.Drawing.Size(307, 24);
            this.lblLinkWebclient.TabIndex = 2;
            this.lblLinkWebclient.TabStop = true;
            this.lblLinkWebclient.Text = "Also play with our webclient !";
            // 
            // lblSideInfo
            // 
            this.lblSideInfo.AutoSize = true;
            this.lblSideInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblSideInfo.ForeColor = System.Drawing.Color.White;
            this.lblSideInfo.Location = new System.Drawing.Point(7, 808);
            this.lblSideInfo.Name = "lblSideInfo";
            this.lblSideInfo.Size = new System.Drawing.Size(476, 26);
            this.lblSideInfo.TabIndex = 3;
            this.lblSideInfo.Text = "Connect X\r\nHowest TI-S2 Project - Groep 30 : Shane Deconinck, Matthias Haelman, L" +
    "ucas Pirard, Jel Sadones";
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold);
            this.btnQuit.Location = new System.Drawing.Point(430, 440);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(680, 100);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "QUIT";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnSluiten_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Enabled = false;
            this.btnSettings.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold);
            this.btnSettings.Location = new System.Drawing.Point(430, 303);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(680, 100);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "SETTINGS";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnPlayCPU
            // 
            this.btnPlayCPU.BackColor = System.Drawing.SystemColors.Control;
            this.btnPlayCPU.Enabled = false;
            this.btnPlayCPU.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayCPU.Location = new System.Drawing.Point(430, 29);
            this.btnPlayCPU.Name = "btnPlayCPU";
            this.btnPlayCPU.Size = new System.Drawing.Size(680, 100);
            this.btnPlayCPU.TabIndex = 0;
            this.btnPlayCPU.Text = "PLAY AGAINST CPU";
            this.btnPlayCPU.UseVisualStyleBackColor = false;
            this.btnPlayCPU.Click += new System.EventHandler(this.btnPlayCPU_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.Controls.Add(this.btnMultiplayer);
            this.pnlMenu.Controls.Add(this.btnPlayCPU);
            this.pnlMenu.Controls.Add(this.btnSettings);
            this.pnlMenu.Controls.Add(this.btnQuit);
            this.pnlMenu.Location = new System.Drawing.Point(2, 179);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1552, 562);
            this.pnlMenu.TabIndex = 5;
            // 
            // btnMultiplayer
            // 
            this.btnMultiplayer.BackColor = System.Drawing.SystemColors.Control;
            this.btnMultiplayer.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold);
            this.btnMultiplayer.Location = new System.Drawing.Point(430, 166);
            this.btnMultiplayer.Name = "btnMultiplayer";
            this.btnMultiplayer.Size = new System.Drawing.Size(680, 100);
            this.btnMultiplayer.TabIndex = 5;
            this.btnMultiplayer.Text = "MULTIPLAYER\r";
            this.btnMultiplayer.UseVisualStyleBackColor = false;
            this.btnMultiplayer.Click += new System.EventHandler(this.button1_Click);
            // 
            // picBoxBanner
            // 
            this.picBoxBanner.BackColor = System.Drawing.Color.Transparent;
            this.picBoxBanner.Image = global::ConnectXLibrary.Properties.Resources.banner1;
            this.picBoxBanner.Location = new System.Drawing.Point(317, 7);
            this.picBoxBanner.Name = "picBoxBanner";
            this.picBoxBanner.Size = new System.Drawing.Size(927, 144);
            this.picBoxBanner.TabIndex = 6;
            this.picBoxBanner.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::ConnectXLibrary.Properties.Resources._128_184;
            this.ClientSize = new System.Drawing.Size(1561, 843);
            this.Controls.Add(this.picBoxBanner);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.lblSideInfo);
            this.Controls.Add(this.lblLinkWebclient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1577, 882);
            this.MinimumSize = new System.Drawing.Size(1577, 882);
            this.Name = "Menu";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 26);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Connect X";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.pnlMenu.ResumeLayout(false);
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
    }
}

