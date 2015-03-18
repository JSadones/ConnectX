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
            pnlMenu.Visible = false;
            pnlGameCpu.Visible = true;
        }

        private void lblSettings_Click(object sender, EventArgs e) {
            pnlMenu.Visible = false;
            pnlSettings.Visible = true;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
