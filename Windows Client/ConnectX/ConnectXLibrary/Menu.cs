using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectXLibrary
{
    public partial class Menu : Form
    {
        #region Constructor
        public Menu() 
        {
            InitializeComponent();
            picBoxPlayer1.BackColor = Color.Blue;
            picBoxPlayer2.BackColor = Color.Red;
        }//Menu
        #endregion

        #region Methods
        #region EventClicks
        private void btnMultiplayer_Click(object sender, EventArgs e)
        {
            pnlEnterData.Visible = true;
            pnlMenu.Visible = false;
        }//btnMultiplayer_Click

        private void btnStart_Click(object sender, EventArgs e)
        {
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
        }//btnStart_Click

        private void btnSluiten_Click(object sender, EventArgs e)
        {
            this.Close();
        }//btnSluiten_Click

        private void picBoxPlayer1_Click(object sender, EventArgs e)
        {
            showColorDialog();
        }//picBoxPlayer1_Click

        private void picBoxPlayer2_Click(object sender, EventArgs e)
        {
            showColorDialog();
        }//picBoxPlayer2_Click
        #endregion

        #region EventTextChanged
        private void txtBoxPlayer1Name_TextChanged(object sender, EventArgs e)
        {
            checkTextBoxes();
            checkDoubleName();
        }//txtBoxPlayer1Name_TextChanged

        private void txtBoxPlayer2Name_TextChanged(object sender, EventArgs e)
        {
            checkTextBoxes();
            checkDoubleName();
        }//txtBoxPlayer2Name_TextChanged

        private void txtBoxWinstreak_TextChanged(object sender, EventArgs e)
        {
            checkTextBoxes();
        }//txtBoxWinstreak_TextChanged

        private void txtBoxWidth_TextChanged(object sender, EventArgs e)
        {
            dimensieCheck();
        } // txtBoxWidth_TextChanged

        private void txtBoxLength_TextChanged(object sender, EventArgs e)
        {
            dimensieCheck();
        } //txtBoxLength_TextChanged



        #endregion

        private void checkTextBoxes()
        {
            if ((txtBoxPlayer1Name.Text != "") && (txtBoxPlayer2Name.Text != "") && (txtBoxWinstreak.Text != ""))
            {
                btnStart.Enabled = true;
            }
            else btnStart.Enabled = false;
        }//checkTextBoxes

        private void showColorDialog()
        {
            //TODO (Zie issues)
        }

        private void dimensieCheck()
        {
            if ((txtBoxWidth.Text != "") && (txtBoxLength.Text != ""))
            {
               int Width = int.Parse(txtBoxWidth.Text);
               int Length = int.Parse(txtBoxLength.Text);
               int Winstreak = int.Parse(txtBoxWinstreak.Text);
                if ((Width >= Winstreak) && (Length >= Winstreak))
                {
                    btnStart.Enabled = true;
                    lblErrorDimension.Text = "";
                }
                else 
                {
                    btnStart.Enabled = false;
                    lblErrorDimension.Text += "Gelieve min. 4x4 afmetingen te kiezen.";
                }
            }
            else
            {
                btnStart.Enabled = false;
            }
        } // dimensieCheck

        private void checkDoubleName() 
        {
            if (txtBoxPlayer1Name.Text == txtBoxPlayer2Name.Text)
            {
                btnStart.Enabled = false;
                lblErrorNaam.Text = "De namen moeten verschillen van elkaar.";
            }
            else
            {
                btnStart.Enabled = true;
                lblErrorNaam.Text = "";
            }
        }//checkDoubleName
        #endregion
    }
}