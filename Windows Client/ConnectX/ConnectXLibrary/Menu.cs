using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectXLibrary
{
    public partial class Menu : Form {
        public Menu() {
            InitializeComponent();
            ConnectX game = new ConnectX();
        }

        private void btnSluiten_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnPlayCPU_Click(object sender, EventArgs e) {
            
        }

        private void btnSettings_Click(object sender, EventArgs e) {
            pnlMenu.Visible = false;
        }

        private void Menu_Load(object sender, EventArgs e) {
            pnlMenu.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e) {
            Game game = new Game();
            game.StartPosition = FormStartPosition.Manual;
            game.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide();
            game.Show();
        }
    }
}
