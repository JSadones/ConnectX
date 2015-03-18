using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectXLibrary
{
    public partial class Menu : Form
    {
        public Menu() {
            InitializeComponent();
            ConnectX game = new ConnectX();
        }

        private void btnSluiten_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnPlayCPU_Click(object sender, EventArgs e) {
            
        }

        private void lblSettings_Click(object sender, EventArgs e) {
            Settings settings = new Settings();
            settings.StartPosition = FormStartPosition.Manual;
            settings.Location = new Point(this.Location.X, this.Location.Y);
            this.Hide();
            settings.Show();
        }
    }
}
