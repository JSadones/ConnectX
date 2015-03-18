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
            this.SuspendLayout();
            // 
            // btnPlayCPU
            // 
            this.btnPlayCPU.Location = new System.Drawing.Point(107, 33);
            this.btnPlayCPU.Name = "btnPlayCPU";
            this.btnPlayCPU.Size = new System.Drawing.Size(118, 28);
            this.btnPlayCPU.TabIndex = 0;
            this.btnPlayCPU.Text = "Play Against CPU";
            this.btnPlayCPU.UseVisualStyleBackColor = true;
            this.btnPlayCPU.Click += new System.EventHandler(this.btnPlayCPU_Click);
            // 
            // btnSluiten
            // 
            this.btnSluiten.Location = new System.Drawing.Point(107, 180);
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
            this.lblLinkWebclient.Location = new System.Drawing.Point(12, 242);
            this.lblLinkWebclient.Name = "lblLinkWebclient";
            this.lblLinkWebclient.Size = new System.Drawing.Size(88, 13);
            this.lblLinkWebclient.TabIndex = 2;
            this.lblLinkWebclient.TabStop = true;
            this.lblLinkWebclient.Text = "Webserver Client";
            // 
            // lblSideInfo
            // 
            this.lblSideInfo.AutoSize = true;
            this.lblSideInfo.Location = new System.Drawing.Point(269, 242);
            this.lblSideInfo.Name = "lblSideInfo";
            this.lblSideInfo.Size = new System.Drawing.Size(60, 13);
            this.lblSideInfo.TabIndex = 3;
            this.lblSideInfo.Text = "Connect X ";
            // 
            // lblSettings
            // 
            this.lblSettings.Location = new System.Drawing.Point(107, 91);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(118, 28);
            this.lblSettings.TabIndex = 4;
            this.lblSettings.Text = "Settings";
            this.lblSettings.UseVisualStyleBackColor = true;
            this.lblSettings.Click += new System.EventHandler(this.lblSettings_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 264);
            this.Controls.Add(this.lblSettings);
            this.Controls.Add(this.lblSideInfo);
            this.Controls.Add(this.lblLinkWebclient);
            this.Controls.Add(this.btnSluiten);
            this.Controls.Add(this.btnPlayCPU);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu";
            this.Text = "Connect X";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlayCPU;
        private System.Windows.Forms.Button btnSluiten;
        private System.Windows.Forms.LinkLabel lblLinkWebclient;
        private System.Windows.Forms.Label lblSideInfo;
        private System.Windows.Forms.Button lblSettings;
    }
}

