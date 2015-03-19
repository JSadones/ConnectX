namespace ConnectXLibrary
{
    partial class Game
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
            this.lblWelkom = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlGame = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelkom
            // 
            this.lblWelkom.AutoSize = true;
            this.lblWelkom.Location = new System.Drawing.Point(349, 13);
            this.lblWelkom.Name = "lblWelkom";
            this.lblWelkom.Size = new System.Drawing.Size(46, 13);
            this.lblWelkom.TabIndex = 0;
            this.lblWelkom.Text = "Welkom";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(420, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(165, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(420, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 2;
            // 
            // pnlGame
            // 
            this.pnlGame.Location = new System.Drawing.Point(12, 52);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(910, 452);
            this.pnlGame.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(442, 510);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ConnectXLibrary.Properties.Resources._128_184;
            this.ClientSize = new System.Drawing.Size(1561, 843);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlGame);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblWelkom);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1577, 882);
            this.MinimumSize = new System.Drawing.Size(1577, 882);
            this.Name = "Game";
            this.Text = "Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelkom;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Panel pnlGame;
    }
}