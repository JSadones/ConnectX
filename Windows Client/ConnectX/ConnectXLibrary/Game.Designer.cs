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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
			this.lblName = new System.Windows.Forms.Label();
			this.pnlGame = new System.Windows.Forms.Panel();
			this.picBoxBanner = new System.Windows.Forms.PictureBox();
			this.lblPlayer1 = new System.Windows.Forms.Label();
			this.lblPlayer2 = new System.Windows.Forms.Label();
			this.lblDividerPlayer1 = new System.Windows.Forms.Label();
			this.lblPointsPlayer1 = new System.Windows.Forms.Label();
			this.lblPointsPlayer2 = new System.Windows.Forms.Label();
			this.lblDividerPlayer2 = new System.Windows.Forms.Label();
			this.lblTurn = new System.Windows.Forms.Label();
			this.lblMouseX = new System.Windows.Forms.Label();
			this.lblMouseY = new System.Windows.Forms.Label();
			this.lblTurnName = new System.Windows.Forms.Label();
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
			this.pnlGame.Size = new System.Drawing.Size(1189, 477);
			this.pnlGame.TabIndex = 4;
			this.pnlGame.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGame_Paint);
			this.pnlGame.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlGame_MouseClick);
			this.pnlGame.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlGame_MouseMove);
			// 
			// picBoxBanner
			// 
			this.picBoxBanner.BackColor = System.Drawing.Color.Transparent;
			this.picBoxBanner.Image = global::ConnectXLibrary.Properties.Resources.banner1;
			this.picBoxBanner.Location = new System.Drawing.Point(833, 12);
			this.picBoxBanner.Name = "picBoxBanner";
			this.picBoxBanner.Size = new System.Drawing.Size(368, 52);
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
			this.lblPlayer1.Location = new System.Drawing.Point(126, 20);
			this.lblPlayer1.Name = "lblPlayer1";
			this.lblPlayer1.Size = new System.Drawing.Size(160, 44);
			this.lblPlayer1.TabIndex = 8;
			this.lblPlayer1.Text = "Player 1";
			this.lblPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblPlayer2
			// 
			this.lblPlayer2.AutoSize = true;
			this.lblPlayer2.BackColor = System.Drawing.Color.Transparent;
			this.lblPlayer2.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayer2.ForeColor = System.Drawing.Color.White;
			this.lblPlayer2.Location = new System.Drawing.Point(126, 82);
			this.lblPlayer2.Name = "lblPlayer2";
			this.lblPlayer2.Size = new System.Drawing.Size(160, 44);
			this.lblPlayer2.TabIndex = 9;
			this.lblPlayer2.Text = "Player 2";
			// 
			// lblDividerPlayer1
			// 
			this.lblDividerPlayer1.AutoSize = true;
			this.lblDividerPlayer1.BackColor = System.Drawing.Color.Transparent;
			this.lblDividerPlayer1.Font = new System.Drawing.Font("Century Gothic", 27.75F);
			this.lblDividerPlayer1.ForeColor = System.Drawing.Color.White;
			this.lblDividerPlayer1.Location = new System.Drawing.Point(75, 20);
			this.lblDividerPlayer1.Name = "lblDividerPlayer1";
			this.lblDividerPlayer1.Size = new System.Drawing.Size(45, 44);
			this.lblDividerPlayer1.TabIndex = 10;
			this.lblDividerPlayer1.Text = "|";
			// 
			// lblPointsPlayer1
			// 
			this.lblPointsPlayer1.AutoSize = true;
			this.lblPointsPlayer1.BackColor = System.Drawing.Color.Transparent;
			this.lblPointsPlayer1.Font = new System.Drawing.Font("Century Gothic", 27.75F);
			this.lblPointsPlayer1.ForeColor = System.Drawing.Color.White;
			this.lblPointsPlayer1.Location = new System.Drawing.Point(28, 20);
			this.lblPointsPlayer1.Name = "lblPointsPlayer1";
			this.lblPointsPlayer1.Size = new System.Drawing.Size(41, 44);
			this.lblPointsPlayer1.TabIndex = 11;
			this.lblPointsPlayer1.Text = "0";
			// 
			// lblPointsPlayer2
			// 
			this.lblPointsPlayer2.AutoSize = true;
			this.lblPointsPlayer2.BackColor = System.Drawing.Color.Transparent;
			this.lblPointsPlayer2.Font = new System.Drawing.Font("Century Gothic", 27.75F);
			this.lblPointsPlayer2.ForeColor = System.Drawing.Color.White;
			this.lblPointsPlayer2.Location = new System.Drawing.Point(28, 82);
			this.lblPointsPlayer2.Name = "lblPointsPlayer2";
			this.lblPointsPlayer2.Size = new System.Drawing.Size(41, 44);
			this.lblPointsPlayer2.TabIndex = 12;
			this.lblPointsPlayer2.Text = "0";
			// 
			// lblDividerPlayer2
			// 
			this.lblDividerPlayer2.AutoSize = true;
			this.lblDividerPlayer2.BackColor = System.Drawing.Color.Transparent;
			this.lblDividerPlayer2.Font = new System.Drawing.Font("Century Gothic", 27.75F);
			this.lblDividerPlayer2.ForeColor = System.Drawing.Color.White;
			this.lblDividerPlayer2.Location = new System.Drawing.Point(75, 82);
			this.lblDividerPlayer2.Name = "lblDividerPlayer2";
			this.lblDividerPlayer2.Size = new System.Drawing.Size(45, 44);
			this.lblDividerPlayer2.TabIndex = 13;
			this.lblDividerPlayer2.Text = "|";
			// 
			// lblTurn
			// 
			this.lblTurn.AutoSize = true;
			this.lblTurn.BackColor = System.Drawing.Color.Transparent;
			this.lblTurn.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTurn.ForeColor = System.Drawing.Color.White;
			this.lblTurn.Location = new System.Drawing.Point(483, 20);
			this.lblTurn.Name = "lblTurn";
			this.lblTurn.Size = new System.Drawing.Size(112, 44);
			this.lblTurn.TabIndex = 14;
			this.lblTurn.Text = "Turn :";
			this.lblTurn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblMouseX
			// 
			this.lblMouseX.AutoSize = true;
			this.lblMouseX.Location = new System.Drawing.Point(356, 50);
			this.lblMouseX.Name = "lblMouseX";
			this.lblMouseX.Size = new System.Drawing.Size(0, 13);
			this.lblMouseX.TabIndex = 15;
			// 
			// lblMouseY
			// 
			this.lblMouseY.AutoSize = true;
			this.lblMouseY.Location = new System.Drawing.Point(359, 82);
			this.lblMouseY.Name = "lblMouseY";
			this.lblMouseY.Size = new System.Drawing.Size(0, 13);
			this.lblMouseY.TabIndex = 16;
			// 
			// lblTurnName
			// 
			this.lblTurnName.AutoSize = true;
			this.lblTurnName.BackColor = System.Drawing.Color.Transparent;
			this.lblTurnName.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTurnName.ForeColor = System.Drawing.Color.White;
			this.lblTurnName.Location = new System.Drawing.Point(601, 19);
			this.lblTurnName.Name = "lblTurnName";
			this.lblTurnName.Size = new System.Drawing.Size(0, 44);
			this.lblTurnName.TabIndex = 17;
			this.lblTurnName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Game
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::ConnectXLibrary.Properties.Resources._128_184;
			this.ClientSize = new System.Drawing.Size(1213, 661);
			this.Controls.Add(this.lblTurnName);
			this.Controls.Add(this.lblMouseY);
			this.Controls.Add(this.lblMouseX);
			this.Controls.Add(this.lblTurn);
			this.Controls.Add(this.lblDividerPlayer2);
			this.Controls.Add(this.lblPointsPlayer2);
			this.Controls.Add(this.lblPointsPlayer1);
			this.Controls.Add(this.lblDividerPlayer1);
			this.Controls.Add(this.lblPlayer2);
			this.Controls.Add(this.lblPlayer1);
			this.Controls.Add(this.picBoxBanner);
			this.Controls.Add(this.pnlGame);
			this.Controls.Add(this.lblName);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1229, 700);
			this.MinimumSize = new System.Drawing.Size(1229, 700);
			this.Name = "Game";
			this.Text = "Connect X";
			((System.ComponentModel.ISupportInitialize)(this.picBoxBanner)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.PictureBox picBoxBanner;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Label lblDividerPlayer1;
        private System.Windows.Forms.Label lblPointsPlayer1;
        private System.Windows.Forms.Label lblPointsPlayer2;
        private System.Windows.Forms.Label lblDividerPlayer2;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblMouseX;
        private System.Windows.Forms.Label lblMouseY;
        private System.Windows.Forms.Label lblTurnName;
    }
}