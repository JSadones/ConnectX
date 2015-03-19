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
            this.btnPlayCPU = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblLinkWebclient = new System.Windows.Forms.LinkLabel();
            this.lblSideInfo = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.pnlGameCpu = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlayCPU
            // 
            this.btnPlayCPU.BackColor = System.Drawing.SystemColors.Control;
            this.btnPlayCPU.Location = new System.Drawing.Point(340, 66);
            this.btnPlayCPU.Name = "btnPlayCPU";
            this.btnPlayCPU.Size = new System.Drawing.Size(222, 67);
            this.btnPlayCPU.TabIndex = 0;
            this.btnPlayCPU.Text = "Play against CPU";
            this.btnPlayCPU.UseVisualStyleBackColor = false;
            this.btnPlayCPU.Click += new System.EventHandler(this.btnPlayCPU_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(340, 315);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(222, 69);
            this.btnQuit.TabIndex = 1;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnSluiten_Click);
            // 
            // lblLinkWebclient
            // 
            this.lblLinkWebclient.AutoSize = true;
            this.lblLinkWebclient.BackColor = System.Drawing.Color.Transparent;
            this.lblLinkWebclient.Location = new System.Drawing.Point(10, 445);
            this.lblLinkWebclient.Name = "lblLinkWebclient";
            this.lblLinkWebclient.Size = new System.Drawing.Size(88, 13);
            this.lblLinkWebclient.TabIndex = 2;
            this.lblLinkWebclient.TabStop = true;
            this.lblLinkWebclient.Text = "Webserver Client";
            // 
            // lblSideInfo
            // 
            this.lblSideInfo.AutoSize = true;
            this.lblSideInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblSideInfo.Location = new System.Drawing.Point(829, 445);
            this.lblSideInfo.Name = "lblSideInfo";
            this.lblSideInfo.Size = new System.Drawing.Size(60, 13);
            this.lblSideInfo.TabIndex = 3;
            this.lblSideInfo.Text = "Connect X ";
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(340, 189);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(222, 68);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.Controls.Add(this.pnlSettings);
            this.pnlMenu.Location = new System.Drawing.Point(2, 1);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(903, 489);
            this.pnlMenu.TabIndex = 5;
            // 
            // pnlSettings
            // 
            this.pnlSettings.BackColor = System.Drawing.Color.Transparent;
            this.pnlSettings.Controls.Add(this.lblSideInfo);
            this.pnlSettings.Controls.Add(this.lblLinkWebclient);
            this.pnlSettings.Controls.Add(this.btnPlayCPU);
            this.pnlSettings.Controls.Add(this.btnSettings);
            this.pnlSettings.Controls.Add(this.btnQuit);
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(903, 489);
            this.pnlSettings.TabIndex = 5;
            // 
            // pnlGameCpu
            // 
            this.pnlGameCpu.BackColor = System.Drawing.Color.Transparent;
            this.pnlGameCpu.Location = new System.Drawing.Point(2, 1);
            this.pnlGameCpu.Name = "pnlGameCpu";
            this.pnlGameCpu.Size = new System.Drawing.Size(903, 489);
            this.pnlGameCpu.TabIndex = 5;
            this.pnlGameCpu.Visible = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::ConnectXLibrary.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(902, 489);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlGameCpu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(918, 528);
            this.MinimumSize = new System.Drawing.Size(918, 528);
            this.Name = "Menu";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 26);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Connect X";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlayCPU;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.LinkLabel lblLinkWebclient;
        private System.Windows.Forms.Label lblSideInfo;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Panel pnlGameCpu;
    }
}

