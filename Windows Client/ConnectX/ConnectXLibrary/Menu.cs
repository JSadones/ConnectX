using System;
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
        }
        #endregion

        #region Methods
        private void btnSluiten_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnMultiplayer_Click(object sender, EventArgs e) {
            pnlEnterData.Visible = true;
            pnlMenu.Visible = false;
        }

        private void btnStart_Click(object sender, EventArgs e) {
            pnlEnterData.Visible = false;
            pnlMenu.Visible = true;
            Game gameForm = new Game();
            gameForm.StartPosition = FormStartPosition.Manual;
            gameForm.Location = new Point(this.Location.X, this.Location.Y);
            gameForm.Show();
        }
        #endregion
    }
}