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
            this.btnPlayCPU.Location = new System.Drawing.Point(726, 126);
            this.btnPlayCPU.Margin = new System.Windows.Forms.Padding(6);
            this.btnPlayCPU.Name = "btnPlayCPU";
            this.btnPlayCPU.Size = new System.Drawing.Size(444, 129);
            this.btnPlayCPU.TabIndex = 0;
            this.btnPlayCPU.Text = "Play against CPU";
            this.btnPlayCPU.UseVisualStyleBackColor = true;
            this.btnPlayCPU.Click += new System.EventHandler(this.btnPlayCPU_Click);
            // 
            // btnSluiten
            // 
            this.btnSluiten.Location = new System.Drawing.Point(726, 606);
            this.btnSluiten.Margin = new System.Windows.Forms.Padding(6);
            this.btnSluiten.Name = "btnSluiten";
            this.btnSluiten.Size = new System.Drawing.Size(444, 132);
            this.btnSluiten.TabIndex = 1;
            this.btnSluiten.Text = "Sluiten";
            this.btnSluiten.UseVisualStyleBackColor = true;
            this.btnSluiten.Click += new System.EventHandler(this.btnSluiten_Click);
            // 
            // lblLinkWebclient
            // 
            this.lblLinkWebclient.AutoSize = true;
            this.lblLinkWebclient.Location = new System.Drawing.Point(20, 856);
            this.lblLinkWebclient.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLinkWebclient.Name = "lblLinkWebclient";
            this.lblLinkWebclient.Size = new System.Drawing.Size(177, 25);
            this.lblLinkWebclient.TabIndex = 2;
            this.lblLinkWebclient.TabStop = true;
            this.lblLinkWebclient.Text = "Webserver Client";
            // 
            // lblSideInfo
            // 
            this.lblSideInfo.AutoSize = true;
            this.lblSideInfo.Location = new System.Drawing.Point(1658, 856);
            this.lblSideInfo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSideInfo.Name = "lblSideInfo";
            this.lblSideInfo.Size = new System.Drawing.Size(118, 25);
            this.lblSideInfo.TabIndex = 3;
            this.lblSideInfo.Text = "Connect X ";
            // 
            // lblSettings
            // 
            this.lblSettings.Location = new System.Drawing.Point(726, 363);
            this.lblSettings.Margin = new System.Windows.Forms.Padding(6);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(444, 130);
            this.lblSettings.TabIndex = 4;
            this.lblSettings.Text = "Settings";
            this.lblSettings.UseVisualStyleBackColor = true;
            this.lblSettings.Click += new System.EventHandler(this.lblSettings_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.pnlSettings);
            this.pnlMenu.Location = new System.Drawing.Point(4, 2);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(6);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1806, 896);
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
            this.pnlSettings.Margin = new System.Windows.Forms.Padding(6);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(1806, 902);
            this.pnlSettings.TabIndex = 5;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1794, 909);
            this.Controls.Add(this.pnlMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1820, 980);
            this.MinimumSize = new System.Drawing.Size(1820, 980);
            this.Name = "Menu";
            this.Padding = new System.Windows.Forms.Padding(7, 7, 7, 50);
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
        private System.Windows.Forms.Button btnSluiten;
        private System.Windows.Forms.LinkLabel lblLinkWebclient;
        private System.Windows.Forms.Label lblSideInfo;
        private System.Windows.Forms.Button lblSettings;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlSettings;
    }
}

