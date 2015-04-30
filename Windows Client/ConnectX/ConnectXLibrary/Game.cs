using System;
using System.Drawing;
using System.Windows.Forms;
using ConnectXLibrary.Properties;

namespace ConnectXLibrary
{
    public partial class Game : Form
    {
        #region State
        private int rows, columns, tokenStreak, startWidth, startHeight, size;
        private string namePlayer1, namePlayer2;
        bool wonGame;
        Bitmap I;
        Graphics gr;
        ConnectX gamePlay;
        Pen myPen;
		SolidBrush redBrush = new SolidBrush(Color.Red);
		SolidBrush blueBrush = new SolidBrush(Color.Blue);
		Pen blackPen = new Pen(Color.Black, 3);
        bool multiplayer;
        #endregion

        #region Constructor
        public Game(int columns, int rows, int tokenStreak, string namePlayer1)
        {
            string cpuName = "Computer";

            InitializeComponent();
            this.namePlayer1 = namePlayer1;
            this.namePlayer2 = cpuName;
            this.rows = rows;
            this.columns = columns;
            this.tokenStreak = tokenStreak;
            int streak = tokenStreak;
            multiplayer = false;

            gamePlay = new ConnectX(rows, columns, tokenStreak, multiplayer);
            //newGame();

            lblPlayer1.Text = namePlayer1;
            lblPlayer2.Text = cpuName;
            lblStreakNumber.Text = streak.ToString();
            showPlayerAtTurn();
        }//Game

        public Game(int columns, int rows, int tokenStreak, string namePlayer1, string namePlayer2) {
            InitializeComponent();
            this.namePlayer1 = namePlayer1;
            this.namePlayer2 = namePlayer2;
            this.rows = rows;
            this.columns = columns;
            this.tokenStreak = tokenStreak;
            int streak = tokenStreak;
            multiplayer = true;

            gamePlay = new ConnectX(rows, columns, tokenStreak, multiplayer);
            //newGame();

            lblPlayer1.Text = namePlayer1;
            lblPlayer2.Text = namePlayer2;
            lblStreakNumber.Text = streak.ToString();
            showPlayerAtTurn();
        }//Game
        #endregion

        #region Properties
        private string getName(int number)
        {
            if (number == 1) return namePlayer1;
            else return namePlayer2;
        }
        #endregion+

        #region Methods
        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            drawGrid();
            drawHud();
        }//pnlGame_MouseClick

        private void updateScores() {
            lblPointsPlayer1.Text = gamePlay.getScore(1).ToString();
            lblPointsPlayer2.Text = gamePlay.getScore(2).ToString();
        }//updateScores

        private void showIfWon() {
			string title = "";
			bool won = false;
            if (gamePlay.isCurrentGameWon())
            {
                wonGame = true;
                if (gamePlay.getWinnerOfLastGame() == 1) title = namePlayer1;
                else title = namePlayer2;
                title += " has won the game.";
                won = true;
            }
            else if (gamePlay.rasterIsFull())
            {
                title = "Raster is full.";
                won = true;
            }
            else wonGame = false;
			if (won)
			{
				updateScores();
				DialogResult dialogResult = MessageBox.Show("Play another one?", title, MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					newGame();
				}
				else if (dialogResult == DialogResult.No)
				{
					string message;
					if (gamePlay.getWinnerOfLastSession() == 0)
						message = "It's a tie!";
					else
						message = getName(gamePlay.getWinnerOfLastSession()) + " won the game!";
					DialogResult dialogResult2 = MessageBox.Show(message, "Game over!", MessageBoxButtons.OK);

					if (dialogResult2 == DialogResult.OK)
					{
						this.Hide();
					}
				}
			}
        }//checkIfWon

        private void drawGrid() {
			calculateSlotSize();
            I = new Bitmap(rows, columns);
            gr = Graphics.FromImage(I);
            gr = pnlGame.CreateGraphics();
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            myPen = new Pen(Brushes.Black, 1);
            startWidth = (pnlGame.Width / 2) - ((size * columns) / 2);
            startHeight = (pnlGame.Height / 2) - ((size * rows) / 2);

            float x = startWidth;
            float y = startHeight;

            gr.Clear(Color.NavajoWhite);

			Image newImage = Resources.frame;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    gr.DrawImage(newImage, x, y, size, size);
                    x += size;
                }
                x = startWidth;
                y += size;
            }
        }//drawGrid

		private void drawHud()
		{
			Graphics hud = this.CreateGraphics();
			Rectangle blueCircle = new Rectangle(75, 20, 45, 45);
			Rectangle redCircle = new Rectangle(75, 80, 45, 45);
			hud.DrawEllipse(blackPen, blueCircle);
			hud.DrawEllipse(blackPen, redCircle);
			hud.FillEllipse(blueBrush, blueCircle);
			hud.FillEllipse(redBrush, redCircle);
		}//drawHud

        private void test(int column)
        {
            int row;
            if (multiplayer == false && gamePlay.getPlayerAtTurn() == 1)
            {
                row = gamePlay.checkIfColumnHasEmptySpot(column);
                gamePlay.insertToken(column, gamePlay.getPlayerAtTurn());
                drawToken(column, row);
            }
            else if (multiplayer == false & gamePlay.getPlayerAtTurn() == 2)
            {
                int spot = gamePlay.chooseRandomSpot();
                row = gamePlay.checkIfColumnHasEmptySpot(spot);
                gamePlay.insertToken(spot, gamePlay.getPlayerAtTurn());
                drawToken(spot, row);
            }
            else
            {
                row = gamePlay.checkIfColumnHasEmptySpot(column);
                gamePlay.insertToken(column, gamePlay.getPlayerAtTurn());
                drawToken(column, row);
            }

            gamePlay.switchPlayerAtTurn();
            showPlayerAtTurn();
            bool isWon = gamePlay.checkIfWon(column, gamePlay.getPlayerAtTurn());
            if(isWon) showIfWon();
            
            if (multiplayer == false && gamePlay.getPlayerAtTurn() == 2 && !wonGame)
            {
                showPlayerAtTurn();

                row = gamePlay.checkIfColumnHasEmptySpot(column);
                test(0);
            }
        }

        private void drawToken(int column, int row) {
            if (row > -1) {
                Rectangle circle = new Rectangle((column * size) + 5 + startWidth, ((rows - row - 1) * size) + 5 + startHeight, size - 10, size - 10);
                gr.DrawEllipse(blackPen, circle);

                if (gamePlay.getPlayerAtTurn() == 1)
                {
                    gr.FillEllipse(blueBrush, circle);
                } else {
                    gr.FillEllipse(redBrush, circle);
                }
            }
        }//drawToken

        //private void pnlGame_MouseMove(object sender, MouseEventArgs e)
        //{
        //    lblMouseX.Text = e.X.ToString();
        //    lblMouseY.Text = e.Y.ToString();

        //    //TODO (Jel) : Deftig de hover laten werken
        //    //Pen penOrange = new Pen(Brushes.Orange, 5);
        //    //for (int i = 0; i < columns; i++) {
        //    //    if (e.X >= i * size && e.X <= size * (i + 1)) {
        //    //        gr.DrawRectangle(penOrange, i * size, 0, size + i, size * rows);
        //    //        //gr.FillRectangle(new SolidBrush(Color.FromArgb(128, 255, 128, 0)), i * size, 0, size * i, size * rows);
        //    //    }
        //    //}
        //}//pnlGame_MouseMove

        private void pnlGame_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < columns; i++)
            {
                if ((i * size) + startWidth <= e.X  && e.X <= (size * (i + 1) + startWidth))
                {
                    test(i);
                    break;
                }
            }
        }//pnlGame_MouseClick

        private void showPlayerAtTurn()
        {
            int playerAtTurn = gamePlay.getPlayerAtTurn();
            if (playerAtTurn == 1)
            {
                lblTurnName.Text = namePlayer1;
            }
            else
            {
                lblTurnName.Text = namePlayer2;
            }
        }//showPlayerAtTurn

        private void newGame() {
            gamePlay.nextGame();
            drawGrid();
        }//newGame

		private void calculateSlotSize()
		{
			size = 480 / rows;
        }//calculateSlotSize
        #endregion
    }
}