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
            pnlStartScreen.Visible = false;
        }//btnMultiplayer_Click

        private void btnStart_Click(object sender, EventArgs e)
        {
            string namePlayer1 = txtBoxPlayer1Name.Text;
            string namePlayer2 = txtBoxPlayer2Name.Text;
            int columns = int.Parse(txtBoxColumns.Text);
            int rows = int.Parse(txtBoxRows.Text);
            int winstreak = int.Parse(txtBoxWinstreak.Text);

            pnlEnterData.Visible = false;
            pnlStartScreen.Visible = true;
            Game gameForm = new Game(namePlayer1, namePlayer2, columns, rows, winstreak);
            gameForm.StartPosition = FormStartPosition.Manual;
            gameForm.Location = new Point(this.Location.X, this.Location.Y);
            gameForm.Show();
        }//btnStart_Click

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }//btnClose_Click

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
            checkNames();
            checkDimension();
            checkStreak();
        }//txtBoxPlayer1Name_TextChanged

        private void txtBoxPlayer2Name_TextChanged(object sender, EventArgs e)
        {
            checkNames();
            checkDimension();
            checkStreak();
        }//txtBoxPlayer2Name_TextChanged

        private void txtBoxWinstreak_TextChanged(object sender, EventArgs e)
        {
            checkNames();
            checkDimension();
            checkStreak();
        }//txtBoxWinstreak_TextChanged

        private void txtBoxWidth_TextChanged(object sender, EventArgs e)
        {
            checkNames();
            checkDimension();
            checkStreak();
        } // txtBoxWidth_TextChanged

        private void txtBoxLength_TextChanged(object sender, EventArgs e)
        {
            checkNames();
            checkDimension();
            checkStreak();
        } //txtBoxLength_TextChanged



        #endregion

        private void showColorDialog()
        {
            //TODO (Zie issues)
        }

        private void checkDimension()
        {
            if ((txtBoxRows.Text != "") && (txtBoxColumns.Text != ""))
            {
                int width = 0;
                int length = 0;

                try
                {
                    length = Convert.ToInt32(txtBoxRows.Text);
                }
                catch (FormatException e)
                {
                    txtBoxRows.Text = "6";
                    length =6;
                    lblErrorDimension.Text = "Invalid character.";
                }
                try
                {
                    width = Convert.ToInt32(txtBoxColumns.Text);
                }
                catch (FormatException e)
                {
                    txtBoxColumns.Text = "7";
                    width = 7;
                    lblErrorDimension.Text = "Invalid character.";
                }

                if ((width < 4) || (length < 4))
                {
                    btnStart.Enabled = false;
                    lblErrorDimension.Text = "Please select at least 4 columns and 4 rows.";
                }
                else if ((width > 10 || length > 10))
                {
                    btnStart.Enabled = false;
                    lblErrorDimension.Text = "Please don't select more than 10 columns and 10 rows.";
                }
                else 
                {
                    btnStart.Enabled = true;
                    lblErrorDimension.Text = "";
                }
            }
            else
            {
                btnStart.Enabled = false;
                lblErrorDimension.Text = "";
            }
        }// dimensionCheck

		private void checkStreak()
		{
			if (txtBoxWinstreak.Text != "" && txtBoxWinstreak.Text != "0" && txtBoxColumns.Text !="" && txtBoxRows.Text != "")
			{
				int streak = int.Parse(txtBoxWinstreak.Text);
                int width = int.Parse(txtBoxRows.Text);
                int length = int.Parse(txtBoxColumns.Text);
				if ((streak > length) && (streak > width))
				{
                    btnStart.Enabled = false;
                    lblErrorStreak.Text = "Please select a valid streak.";
				}
				else
				{
                    btnStart.Enabled = true;
                    lblErrorStreak.Text = "";
				}
			}
			else 
            {
				btnStart.Enabled = false;
                lblErrorStreak.Text = "Please enter a streak";
			}
		}

		private void checkNames()
		{
			if ((txtBoxPlayer1Name.Text != txtBoxPlayer2Name.Text) && ((txtBoxPlayer1Name.Text != "") && (txtBoxPlayer2Name.Text != "")))
			{
				btnStart.Enabled = true;
				lblErrorName.Text = "";
			}
			else
			{
				btnStart.Enabled = false;
				lblErrorName.Text = "Empty or double names are not allowed";
			}
		}//checkNames
        #endregion
    }
}