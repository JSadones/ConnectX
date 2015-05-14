namespace ConnectXLibrary
{
    partial class Server
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Server));
			this.label1 = new System.Windows.Forms.Label();
			this.btnStopServer = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Century Gothic", 27.75F);
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(2, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(337, 44);
			this.label1.TabIndex = 0;
			this.label1.Text = "Server is running...";
			// 
			// btnStopServer
			// 
			this.btnStopServer.Location = new System.Drawing.Point(87, 154);
			this.btnStopServer.Name = "btnStopServer";
			this.btnStopServer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.btnStopServer.Size = new System.Drawing.Size(156, 57);
			this.btnStopServer.TabIndex = 1;
			this.btnStopServer.Text = "Stop server";
			this.btnStopServer.UseVisualStyleBackColor = true;
			this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
			// 
			// Server
			// 
			this.BackgroundImage = global::ConnectXLibrary.Properties.Resources.bg;
			this.ClientSize = new System.Drawing.Size(331, 261);
			this.Controls.Add(this.btnStopServer);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Server";
			this.Text = "Server";
			this.Load += new System.EventHandler(this.Server_Load); 
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);

			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnStopServer;

    }
}