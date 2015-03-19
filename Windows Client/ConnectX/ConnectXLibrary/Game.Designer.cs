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
            this.lblName = new System.Windows.Forms.Label();
            this.pnlGame = new System.Windows.Forms.Panel();
            this.btnDrawGrid = new System.Windows.Forms.Button();
            this.picBoxBanner = new System.Windows.Forms.PictureBox();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBanner)).BeginInit();
            this.SuspendLayout();
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
            this.pnlGame.BackColor = System.Drawing.Color.White;
            this.pnlGame.Location = new System.Drawing.Point(12, 157);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(1537, 634);
            this.pnlGame.TabIndex = 4;
            // 
            // btnDrawGrid
            // 
            this.btnDrawGrid.Location = new System.Drawing.Point(743, 808);
            this.btnDrawGrid.Name = "btnDrawGrid";
            this.btnDrawGrid.Size = new System.Drawing.Size(75, 23);
            this.btnDrawGrid.TabIndex = 5;
            this.btnDrawGrid.Text = "Draw Grid";
            this.btnDrawGrid.UseVisualStyleBackColor = true;
            this.btnDrawGrid.Click += new System.EventHandler(this.button1_Click);
            // 
            // picBoxBanner
            // 
            this.picBoxBanner.BackColor = System.Drawing.Color.Transparent;
            this.picBoxBanner.Image = global::ConnectXLibrary.Properties.Resources.banner1;
            this.picBoxBanner.Location = new System.Drawing.Point(549, 12);
            this.picBoxBanner.Name = "picBoxBanner";
            this.picBoxBanner.Size = new System.Drawing.Size(463, 72);
            this.picBoxBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxBanner.TabIndex = 7;
            this.picBoxBanner.TabStop = false;
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer1.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1.ForeColor = System.Drawing.Color.White;
            this.lblPlayer1.Location = new System.Drawing.Point(64, 28);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(160, 44);
            this.lblPlayer1.TabIndex = 8;
            this.lblPlayer1.Text = "Player 1";
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer2.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2.ForeColor = System.Drawing.Color.White;
            this.lblPlayer2.Location = new System.Drawing.Point(1304, 28);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(160, 44);
            this.lblPlayer2.TabIndex = 9;
            this.lblPlayer2.Text = "Player 2";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ConnectXLibrary.Properties.Resources._128_184;
            this.ClientSize = new System.Drawing.Size(1561, 843);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblPlayer1);
            this.Controls.Add(this.picBoxBanner);
            this.Controls.Add(this.btnDrawGrid);
            this.Controls.Add(this.pnlGame);
            this.Controls.Add(this.lblName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1577, 882);
            this.MinimumSize = new System.Drawing.Size(1577, 882);
            this.Name = "Game";
            this.Text = "Game";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnDrawGrid;
        public System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.PictureBox picBoxBanner;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
    }
}