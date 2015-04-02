﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectXLibrary
{
    public partial class Menu : Form
    {
        #region Constructor
        public Menu() {
            InitializeComponent();
            ConnectX game = new ConnectX();
            WebServer server = new WebServer();
        }
        #endregion

        #region Methods
        private void btnMultiplayer_Click(object sender, EventArgs e) {
            pnlEnterData.Visible = true;
            pnlMenu.Visible = false;
        }

        private void btnStart_Click(object sender, EventArgs e) {
            string namePlayer1 = txtBoxPlayer1Name.Text;
            string namePlayer2 = txtBoxPlayer2Name.Text;
            int width = int.Parse(txtBoxWidth.Text);
            int length = int.Parse(txtBoxLength.Text);
            int winstreak = int.Parse(txtBoxWinstreak.Text);

            pnlEnterData.Visible = false;
            pnlMenu.Visible = true;
            Game gameForm = new Game(namePlayer1, namePlayer2, width, length, winstreak);
            gameForm.StartPosition = FormStartPosition.Manual;
            gameForm.Location = new Point(this.Location.X, this.Location.Y);
            gameForm.Show();
        }

        private void txtBoxPlayer1Name_TextChanged(object sender, EventArgs e) {
            checkTextBoxes();
        }

        private void txtBoxPlayer2Name_TextChanged(object sender, EventArgs e) {
            checkTextBoxes();
        }

        private void txtBoxWinstreak_TextChanged(object sender, EventArgs e) {
            checkTextBoxes();
        }

        private void checkTextBoxes() {
            if ((txtBoxPlayer1Name.Text != "") && (txtBoxPlayer2Name.Text != "") && (txtBoxWinstreak.Text != "")) {
                btnStart.Enabled = true;
            }
            else btnStart.Enabled = false;
        }

        private void btnSluiten_Click(object sender, EventArgs e) {
            this.Close();
        }
        #endregion
    }
}