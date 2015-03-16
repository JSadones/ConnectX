using System;
using System.Windows.Forms;

namespace XOPeenRij
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnSluiten_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
