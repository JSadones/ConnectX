using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectXLibrary
{
    public partial class Menu : Form
    {
        #region State
        bool multiplayer;
        #endregion
        #region Constructor
        public Menu() 
        {
            InitializeComponent();
            picBoxPlayer1.BackColor = Color.Blue;
            picBoxPlayer2.BackColor = Color.Red;
			txtBoxRows.Text = ConnectX.GetDefaultRows().ToString();
			txtBoxColumns.Text = ConnectX.GetDefaultColumns().ToString();
			txtBoxStreakToWin.Text = ConnectX.GetDefaultStreakToWin().ToString();
        }//Menu
        #endregion

        #region Methods

        #region EventClicks
        private void btnMultiplayer_Click(object sender, EventArgs e)
        {
            multiplayer = true;
            showMenu();
        }//btnMultiplayer_Click

        private void btnPlayCPU_Click(object sender, EventArgs e)
        {
            multiplayer = false;
            showMenu();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string namePlayer1 = txtBoxPlayer1Name.Text;
            int columns = int.Parse(txtBoxColumns.Text);
            int rows = int.Parse(txtBoxRows.Text);
            int streaktowin = int.Parse(txtBoxStreakToWin.Text);

            pnlEnterData.Visible = false;
            pnlStartScreen.Visible = true;
            Game gameForm;

            if (multiplayer)
            {
                string namePlayer2 = txtBoxPlayer2Name.Text;
                gameForm = new Game(columns, rows, streaktowin, namePlayer1, namePlayer2);
            }
            else
            {
                gameForm = new Game(columns, rows, streaktowin, namePlayer1);
            }


            pnlEnterData.Visible = false;
            pnlStartScreen.Visible = true;
            
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
        }//txtBoxPlayer1Name_TextChanged

        private void txtBoxPlayer2Name_TextChanged(object sender, EventArgs e)
        {
            checkNames();
        }//txtBoxPlayer2Name_TextChanged

        private void txtBoxStreakToWin_TextChanged(object sender, EventArgs e)
        {
            checkStreak();
        }//txtBoxStreakToWin_TextChanged

        private void txtBoxColumns_TextChanged(object sender, EventArgs e)
        {
            checkDimension();
        } // txtBoxWidth_TextChanged

        private void txtBoxRows_TextChanged(object sender, EventArgs e)
        {
            checkDimension();
        } //txtBoxLength_TextChanged
        #endregion

        private void showColorDialog()
        {
            //TODO (Zie issues)
        }//showColorDialog

        private void checkDimension()
        {
            if ((txtBoxRows.Text != "") && (txtBoxColumns.Text != ""))
            {
                int columns = 0;
                int rows = 0;

                #region Exception Handling
                try
                {
                    rows = Convert.ToInt32(txtBoxRows.Text);
                }
                catch (FormatException e)
                {
                    txtBoxRows.Text = ConnectX.GetDefaultRows().ToString();
                    rows = ConnectX.GetDefaultRows();
                    lblErrorDimension.Text = "Invalid character.";
                }

                try
                {
                    columns = Convert.ToInt32(txtBoxColumns.Text);
                }
                catch (FormatException e)
                {
                    txtBoxColumns.Text = ConnectX.GetDefaultColumns().ToString();
					columns = ConnectX.GetDefaultColumns();
                    lblErrorDimension.Text = "Invalid character.";
                }
                #endregion

                if ((columns < 4) || (rows < 4))
                {
                    btnStart.Enabled = false;
                    lblErrorDimension.Text = "Please select at least 4 columns and 4 rows.";
                }
                else if ((columns > 10 || rows > 10))
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
            

            if (txtBoxStreakToWin.Text != "" && txtBoxColumns.Text !="" && txtBoxRows.Text != "")
			{
                int columns = int.Parse(txtBoxRows.Text);
                int rows = int.Parse(txtBoxColumns.Text);
                int streak = 0;

                #region Exception Handling
                try
                {
                    streak = Convert.ToInt32(txtBoxStreakToWin.Text);
                }
                catch (FormatException e)
                {
                    txtBoxStreakToWin.Text = ConnectX.GetDefaultStreakToWin().ToString();
					streak = ConnectX.GetDefaultStreakToWin();
                    lblErrorStreak.Text = "Invalid character.";
                }
                #endregion

				if ((streak > rows) && (streak > columns) || (streak <= 3))
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
		}//checkStreak

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

        private void btnWebclient_Click(object sender, EventArgs e)
        {
            Server server = new Server();
            server.Show();
        }

        private void showMenu()
        {
            if (multiplayer)
            {
                lblPlayer2Name.Visible = true;
                picBoxPlayer2.Visible = true;
                txtBoxPlayer2Name.Visible = true;
            }
            else
            {
                lblPlayer2Name.Visible = false;
                picBoxPlayer2.Visible = false;
                txtBoxPlayer2Name.Visible = false;
            }
            pnlEnterData.Visible = true;
            pnlStartScreen.Visible = false;
        }//showMenu
        #endregion
    }
}