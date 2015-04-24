using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectXLibrary
{
    public partial class Game : Form
    {
        #region State
        private int rows, columns, winstreak, startWidth, startHeight;
        private string namePlayer1, namePlayer2;
        private static int size = 60;
        Bitmap I;
        Graphics gr, hr;
        ConnectXSession session;
        Pen myPen;
		SolidBrush redBrush = new SolidBrush(Color.Red);
		SolidBrush blueBrush = new SolidBrush(Color.Blue);
		Pen blackPen = new Pen(Color.Black, 3);
        #endregion

        #region Constructor
        public Game(string namePlayer1, string namePlayer2, int columns, int rows, int winstreak) {
            InitializeComponent();
            this.namePlayer1 = namePlayer1;
            this.namePlayer2 = namePlayer2;
            this.rows = rows;
            this.columns = columns;
            this.winstreak = winstreak;

            session = new ConnectXSession(rows, columns, winstreak);
            session.newGame();

            lblPlayer1.Text = namePlayer1;
            lblPlayer2.Text = namePlayer2;
            showPlayerAtTurn();
        }//Game
        #endregion

        #region Properties
        private string getName(int number)
        {
            if (number == 1) return namePlayer1;
            else return namePlayer2;
        }
        #endregion

        #region Methods
        private void updateScores() {
            lblPointsPlayer1.Text = session.getScore(1).ToString();
            lblPointsPlayer2.Text = session.getScore(2).ToString();
        }//updateScores

        private void showIfWon() {
			string title = "";
			bool won = false;
            if (session.isCurrentGameWon()) {
				if (session.getCurrentGameWonPlayer() == 1) title = namePlayer1;
				else title = namePlayer2;
				title += " has won the game.";
				won = true;
			}
            else if (session.isRasterFull()){
				title = "Raster is full.";
				won = true;
			}
			if (won)
			{
				gr.Clear(Color.White);
				updateScores();
				DialogResult dialogResult = MessageBox.Show("Play another one?", title, MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					session.newGame();
					drawGrid();
				}
				else if (dialogResult == DialogResult.No)
				{
					string message;
					if (session.getOverallWonPlayer() == 0)
						message = "It's a tie!";
					else
						message = getName(session.getOverallWonPlayer()) + " won the game!";

					DialogResult dialogResult2 = MessageBox.Show(message, "Game over!", MessageBoxButtons.OK);

					if (dialogResult2 == DialogResult.OK)
					{
						this.Hide();
					}
				}
			}
        }//checkIfWon

        private void drawGrid() {
            I = new Bitmap(rows, columns);
            gr = Graphics.FromImage(I);
            gr.Clear(Color.White);
            gr = pnlGame.CreateGraphics();
            hr = pnlGame.CreateGraphics();
            hr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            myPen = new Pen(Brushes.Black, 1);
            startWidth = (pnlGame.Width / 2) - ((size * columns) / 2);
            startHeight = (pnlGame.Height / 2) - ((size * rows) / 2);

            float x = startWidth;
            float y = startHeight;

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Image newImage = Image.FromFile("C:/frame.png");
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

        private void drawToken(int column) {
            Rectangle circle = new Rectangle((column * size) + 5 + startWidth, ((rows - emptySpotFree(column)) * size) + 5 + startHeight, size - 10, size - 10);
            gr.DrawEllipse(blackPen, circle);

            if (session.getPlayerAtPlay() == 1) {
                hr.FillEllipse(redBrush, circle);
            } else {
                hr.FillEllipse(blueBrush, circle);
            }
        }//drawToken

        private void pnlGame_MouseMove(object sender, MouseEventArgs e)
        {
            lblMouseX.Text = e.X.ToString();
            lblMouseY.Text = e.Y.ToString();

            //TODO (Jel) : Deftig de hover laten werken
            //Pen penOrange = new Pen(Brushes.Orange, 5);
            //for (int i = 0; i < columns; i++) {
            //    if (e.X >= i * size && e.X <= size * (i + 1)) {
            //        hr.DrawRectangle(penOrange, i * size, 0, size + i, size * rows);
            //        //gr.FillRectangle(new SolidBrush(Color.FromArgb(128, 255, 128, 0)), i * size, 0, size * i, size * rows);
            //    }
            //}
        }//pnlGame_MouseMove

        private void pnlGame_MouseClick(object sender, MouseEventArgs e)
        {
            int playerAtPlay = session.getPlayerAtPlay();
            for (int i = 0; i < columns; i++)
            {
                if ((i * size) + startWidth <= e.X  && e.X <= (size * (i + 1) + startWidth))
                {
                    drawToken(i);
                    session.checkIfWon(i, playerAtPlay);
                    break;
                }
            }
            showIfWon();
            showPlayerAtTurn();
        }//pnlGame_MouseClick

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            drawGrid();
			drawHud();
        }//pnlGame_MouseClick

        private int emptySpotFree(int column) {
            int row = 0;
            int[,] raster = session.getRaster();
            while (row < rows)
            {
                if (raster[row, column] == 0) return row;
                row++;
            }
            return rows;
        }//emptySpotFree

        private void showPlayerAtTurn()
        {
            int playerAtTurn = session.getPlayerAtPlay();
            if (playerAtTurn == 1) lblTurnName.Text = namePlayer1;
            else lblTurnName.Text = namePlayer2;
        }//showPlayerAtTurn
        #endregion
    }
}