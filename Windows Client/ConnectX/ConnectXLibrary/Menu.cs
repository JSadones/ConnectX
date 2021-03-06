﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectXLibrary
{
    public partial class Menu : Form
    {
        #region State
        bool multiplayerGame, dimensionOK, streakOK, namesOK;
        #endregion

        #region Constructor
        public Menu() 
        {
            InitializeComponent();

			txtBoxRows.Text = ConnectX.GetDefaultRows().ToString();
			txtBoxColumns.Text = ConnectX.GetDefaultColumns().ToString();
			txtBoxStreakToWin.Text = ConnectX.GetDefaultStreakToWin().ToString();
            lblErrorDimension.Text = "";
            lblErrorName.Text = "";
            lblErrorStreak.Text = "";

            checkNames();
            startButtonState();
        }//Menu
        #endregion

        #region Methods
        //===Click Methods===
        private void btnPlayCPU_Click(object sender, EventArgs e)
        {
            multiplayerGame = false;
            groupDifficulty.Visible = true;
            showMenu();
        }//btnPlayCPU_Click

        private void btnMultiplayer_Click(object sender, EventArgs e)
        {
            multiplayerGame = true;
            groupDifficulty.Visible = false;
            showMenu();
        }//btnMultiplayer_Click

        private void btnWebclient_Click(object sender, EventArgs e)
        {
            Server server = new Server();
			this.Hide();
			server.Closed += (s, args) => this.Show();
			server.Show();

        }//btnWebclient_Click

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }//btnClose_Click

        private void btnStart_Click(object sender, EventArgs e)
        {
            string player1Name = txtBoxPlayer1Name.Text;
            int columns = int.Parse(txtBoxColumns.Text);
            int rows = int.Parse(txtBoxRows.Text);
            int streaktowin = int.Parse(txtBoxStreakToWin.Text);
            Game gameForm;
            pnlEnterData.Visible = false;
            pnlStartScreen.Visible = true;
            int difficulty = 0;
            
            if (!multiplayerGame)
            {
                if (radioEasy.Checked) difficulty = 1;
                else if (radioMedium.Checked) difficulty = 2;
                else if (radioHard.Checked) difficulty = 3;
                else if (radioHardcore.Checked) difficulty = 4;

                gameForm = new Game(difficulty, columns, rows, streaktowin, player1Name);
            }
            else
            {
                string player2Name = txtBoxPlayer2Name.Text;
                gameForm = new Game(difficulty, columns, rows, streaktowin, player1Name, player2Name);
            }

            pnlEnterData.Visible = false;
            pnlStartScreen.Visible = true;

			this.Hide();
			gameForm.Closed += (s, args) => this.Show();

            gameForm.StartPosition = FormStartPosition.Manual;
            gameForm.Location = new Point(this.Location.X, this.Location.Y);
            gameForm.Show();
			
        }//btnStart_Click


        //===TextBox Methods===
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
            checkStreak();
        } // txtBoxWidth_TextChanged

        private void txtBoxRows_TextChanged(object sender, EventArgs e)
        {
            checkDimension();
            checkStreak();
        } //txtBoxLength_TextChanged


        //===Check Methods===
        private void checkDimension()
        {
            if ((txtBoxRows.Text != "") && (txtBoxColumns.Text != ""))
            {
                int columns = 0;
                int rows = 0;

                try
                {
                    rows = int.Parse(txtBoxRows.Text);
                }
                catch (FormatException)
                {
                    txtBoxRows.Text = ConnectX.GetDefaultRows().ToString();
                    rows = ConnectX.GetDefaultRows();
                }

                try
                {
                    columns = int.Parse(txtBoxColumns.Text);
                }
                catch (FormatException)
                {
                    txtBoxColumns.Text = ConnectX.GetDefaultColumns().ToString();
                    columns = ConnectX.GetDefaultColumns();
                }

                if ((columns < 4) || (rows < 4))
                {
                    dimensionOK = false;
                    lblErrorDimension.Text = "Please select at least 4 columns and 4 rows.";
                }
                else if ((columns > 10 || rows > 10))
                {
                    dimensionOK = false;
                    lblErrorDimension.Text = "Please don't select more than 10 columns and 10 rows.";
                }
                else
                {
                    dimensionOK = true;
                    lblErrorDimension.Text = "";
                }
            }
            else
            {
                dimensionOK = false;
                lblErrorDimension.Text = "Please enter valid rows and/or columns.";
            }
        }// checkDimension

        private void checkStreak()
        {
            if (txtBoxStreakToWin.Text != "" && txtBoxColumns.Text != "" && txtBoxRows.Text != "")
            {
                int columns = int.Parse(txtBoxRows.Text);
                int rows = int.Parse(txtBoxColumns.Text);
                int streak;

                try
                {
                    streak = int.Parse(txtBoxStreakToWin.Text);
                }
                catch (FormatException)
                {
                    txtBoxStreakToWin.Text = ConnectX.GetDefaultStreakToWin().ToString();
                    streak = ConnectX.GetDefaultStreakToWin();
                }

                if ((streak > rows) && (streak > columns))
                {
                    streakOK = false;
                    lblErrorStreak.Text = "Please select a valid streak.";
                }
                else if(streak <= 3)
                {
                    lblErrorStreak.Text = "Streak must be higher than 3.";
                }
                else
                {
                    streakOK = true;
                    lblErrorStreak.Text = "";
                }
            }
            else
            {
                streakOK = false;
                lblErrorStreak.Text = "Please enter a streak.";
            }
            startButtonState();
        }//checkStreak

        private void checkNames()
        {
            if ((txtBoxPlayer1Name.Text == txtBoxPlayer2Name.Text) && (txtBoxPlayer1Name.Text != "") && (txtBoxPlayer2Name.Text != ""))
            {
                namesOK = false;
                lblErrorName.Text = "Same names are not allowed.";
            }
            else if (txtBoxPlayer1Name.Text == "" || txtBoxPlayer2Name.Text == "")
            {
                namesOK = false;
                lblErrorName.Text = "Please select a name.";
            }
            else
            {
                namesOK = true;
                lblErrorName.Text = "";
            }
            startButtonState();
        }//checkNames

        private void startButtonState()
        {
            if (dimensionOK && streakOK && namesOK) btnStart.Enabled = true;
            else btnStart.Enabled = false;
        }//startButtonState


        //===Other Methods===
        private void showMenu()
        {
            if (multiplayerGame)
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