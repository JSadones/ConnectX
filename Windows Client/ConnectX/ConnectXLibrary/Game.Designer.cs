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
			this.lblPlayer1 = new System.Windows.Forms.Label();
			this.lblPlayer2 = new System.Windows.Forms.Label();
			this.lblPointsPlayer1 = new System.Windows.Forms.Label();
			this.lblPointsPlayer2 = new System.Windows.Forms.Label();
			this.lblTurn = new System.Windows.Forms.Label();
			this.lblMouseX = new System.Windows.Forms.Label();
			this.lblMouseY = new System.Windows.Forms.Label();
			this.lblTurnName = new System.Windows.Forms.Label();
			this.lblStreak = new System.Windows.Forms.Label();
			this.lblStreakNumber = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
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
			this.pnlGame.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.pnlGame.BackgroundImage = global::ConnectXLibrary.Properties.Resources.bg;
			this.pnlGame.Location = new System.Drawing.Point(-4, 157);
			this.pnlGame.Name = "pnlGame";
			this.pnlGame.Size = new System.Drawing.Size(793, 540);
			this.pnlGame.TabIndex = 4;
			this.pnlGame.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGame_Paint);
			this.pnlGame.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlGame_MouseClick);
			// 
			// lblPlayer1
			// 
			this.lblPlayer1.AutoSize = true;
			this.lblPlayer1.BackColor = System.Drawing.Color.Transparent;
			this.lblPlayer1.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayer1.ForeColor = System.Drawing.Color.White;
			this.lblPlayer1.Location = new System.Drawing.Point(135, 6);
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
			this.lblPlayer2.Location = new System.Drawing.Point(135, 50);
			this.lblPlayer2.Name = "lblPlayer2";
			this.lblPlayer2.Size = new System.Drawing.Size(160, 44);
			this.lblPlayer2.TabIndex = 9;
			this.lblPlayer2.Text = "Player 2";
			// 
			// lblPointsPlayer1
			// 
			this.lblPointsPlayer1.AutoSize = true;
			this.lblPointsPlayer1.BackColor = System.Drawing.Color.Transparent;
			this.lblPointsPlayer1.Font = new System.Drawing.Font("Century Gothic", 27.75F);
			this.lblPointsPlayer1.ForeColor = System.Drawing.Color.White;
			this.lblPointsPlayer1.Location = new System.Drawing.Point(25, 6);
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
			this.lblPointsPlayer2.Location = new System.Drawing.Point(25, 50);
			this.lblPointsPlayer2.Name = "lblPointsPlayer2";
			this.lblPointsPlayer2.Size = new System.Drawing.Size(41, 44);
			this.lblPointsPlayer2.TabIndex = 12;
			this.lblPointsPlayer2.Text = "0";
			// 
			// lblTurn
			// 
			this.lblTurn.AutoSize = true;
			this.lblTurn.BackColor = System.Drawing.Color.Transparent;
			this.lblTurn.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTurn.ForeColor = System.Drawing.Color.White;
			this.lblTurn.Location = new System.Drawing.Point(480, 6);
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
			this.lblTurnName.Location = new System.Drawing.Point(621, 6);
			this.lblTurnName.Name = "lblTurnName";
			this.lblTurnName.Size = new System.Drawing.Size(0, 44);
			this.lblTurnName.TabIndex = 17;
			this.lblTurnName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblStreak
			// 
			this.lblStreak.AutoSize = true;
			this.lblStreak.BackColor = System.Drawing.Color.Transparent;
			this.lblStreak.Font = new System.Drawing.Font("Century Gothic", 27.75F);
			this.lblStreak.ForeColor = System.Drawing.Color.White;
			this.lblStreak.Location = new System.Drawing.Point(480, 50);
			this.lblStreak.Name = "lblStreak";
			this.lblStreak.Size = new System.Drawing.Size(138, 44);
			this.lblStreak.TabIndex = 18;
			this.lblStreak.Text = "Streak:";
			this.lblStreak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblStreakNumber
			// 
			this.lblStreakNumber.AutoSize = true;
			this.lblStreakNumber.BackColor = System.Drawing.Color.Transparent;
			this.lblStreakNumber.Font = new System.Drawing.Font("Century Gothic", 27.75F);
			this.lblStreakNumber.ForeColor = System.Drawing.Color.White;
			this.lblStreakNumber.Location = new System.Drawing.Point(621, 50);
			this.lblStreakNumber.Name = "lblStreakNumber";
			this.lblStreakNumber.Size = new System.Drawing.Size(0, 44);
			this.lblStreakNumber.TabIndex = 19;
			this.lblStreakNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(813, 30);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(159, 583);
			this.textBox1.TabIndex = 20;
			this.textBox1.MouseHover += new System.EventHandler(this.textBox1_MouseHover);
			// 
			// Game
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::ConnectXLibrary.Properties.Resources.bg;
			this.ClientSize = new System.Drawing.Size(984, 693);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.lblStreakNumber);
			this.Controls.Add(this.lblStreak);
			this.Controls.Add(this.lblTurnName);
			this.Controls.Add(this.lblMouseY);
			this.Controls.Add(this.lblMouseX);
			this.Controls.Add(this.lblTurn);
			this.Controls.Add(this.lblPointsPlayer2);
			this.Controls.Add(this.lblPointsPlayer1);
			this.Controls.Add(this.lblPlayer2);
			this.Controls.Add(this.lblPlayer1);
			this.Controls.Add(this.pnlGame);
			this.Controls.Add(this.lblName);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1000, 732);
			this.MinimumSize = new System.Drawing.Size(1000, 732);
			this.Name = "Game";
			this.Text = "Connect X";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        public System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Label lblPointsPlayer1;
        private System.Windows.Forms.Label lblPointsPlayer2;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblMouseX;
        private System.Windows.Forms.Label lblMouseY;
        private System.Windows.Forms.Label lblTurnName;
		private System.Windows.Forms.Label lblStreak;
		private System.Windows.Forms.Label lblStreakNumber;
        private System.Windows.Forms.TextBox textBox1;
    }
}