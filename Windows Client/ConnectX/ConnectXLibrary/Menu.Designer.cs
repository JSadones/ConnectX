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
            this.btnSluiten = new System.Windows.Forms.Button();
            this.lblLinkWebclient = new System.Windows.Forms.LinkLabel();
            this.lblSideInfo = new System.Windows.Forms.Label();
            this.lblSettings = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlayCPU
            // 
            this.btnPlayCPU.Location = new System.Drawing.Point(354, 93);
            this.btnPlayCPU.Name = "btnPlayCPU";
            this.btnPlayCPU.Size = new System.Drawing.Size(118, 28);
            this.btnPlayCPU.TabIndex = 0;
            this.btnPlayCPU.Text = "Play against CPU";
            this.btnPlayCPU.UseVisualStyleBackColor = true;
            this.btnPlayCPU.Click += new System.EventHandler(this.btnPlayCPU_Click);
            // 
            // btnSluiten
            // 
            this.btnSluiten.Location = new System.Drawing.Point(354, 188);
            this.btnSluiten.Name = "btnSluiten";
            this.btnSluiten.Size = new System.Drawing.Size(118, 23);
            this.btnSluiten.TabIndex = 1;
            this.btnSluiten.Text = "Sluiten";
            this.btnSluiten.UseVisualStyleBackColor = true;
            this.btnSluiten.Click += new System.EventHandler(this.btnSluiten_Click);
            // 
            // lblLinkWebclient
            // 
            this.lblLinkWebclient.AutoSize = true;
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
            this.lblSideInfo.Location = new System.Drawing.Point(829, 445);
            this.lblSideInfo.Name = "lblSideInfo";
            this.lblSideInfo.Size = new System.Drawing.Size(60, 13);
            this.lblSideInfo.TabIndex = 3;
            this.lblSideInfo.Text = "Connect X ";
            // 
            // lblSettings
            // 
            this.lblSettings.Location = new System.Drawing.Point(354, 138);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(118, 28);
            this.lblSettings.TabIndex = 4;
            this.lblSettings.Text = "Settings";
            this.lblSettings.UseVisualStyleBackColor = true;
            this.lblSettings.Click += new System.EventHandler(this.lblSettings_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.pnlSettings);
            this.pnlMenu.Location = new System.Drawing.Point(2, 1);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(903, 466);
            this.pnlMenu.TabIndex = 5;
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.lblSideInfo);
            this.pnlSettings.Controls.Add(this.lblLinkWebclient);
            this.pnlSettings.Controls.Add(this.btnPlayCPU);
            this.pnlSettings.Controls.Add(this.lblSettings);
            this.pnlSettings.Controls.Add(this.btnSluiten);
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(903, 469);
            this.pnlSettings.TabIndex = 5;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 468);
            this.Controls.Add(this.pnlMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(919, 507);
            this.MinimumSize = new System.Drawing.Size(919, 507);
            this.Name = "Menu";
            this.Text = "Connect X";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlayCPU;
        private System.Windows.Forms.Button btnSluiten;
        private System.Windows.Forms.LinkLabel lblLinkWebclient;
        private System.Windows.Forms.Label lblSideInfo;
        private System.Windows.Forms.Button lblSettings;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlSettings;
    }
}

