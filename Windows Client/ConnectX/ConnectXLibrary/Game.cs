using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectXLibrary
{
    public partial class Game : Form
    {
        #region State
        private int rows, columns, winstreak;
        private string namePlayer1, namePlayer2;
        private static int size = 60;
        Bitmap I;
        Graphics gr;
        Graphics hr;
        ConnectXSession session;
        Pen myPen;
        Font myFont;
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

            newSession();
            session.newGame();
        }//Game
        #endregion

        #region Methods
        private void newSession()
        {
            session = new ConnectXSession(rows, columns, winstreak);
            session.setName(1, namePlayer1);
            session.setName(2, namePlayer2);

            lblPlayer1.Text = session.getName(1);
            lblPlayer2.Text = session.getName(2);

            updateScores();
        }//newSession

        private void updateScores() {
            lblPointsPlayer1.Text = session.getScore(1).ToString();
            lblPointsPlayer2.Text = session.getScore(2).ToString();
        }//updateScores

        private void checkIfWon() {
			string title = "";
			bool won = false;
            if (session.isCurrentGameWon()) {
				if (session.getCurrentGameWonPlayer() == 1) title = namePlayer1;
				else title = namePlayer2;
				title += " has won the game.";
				won = true;
			}else if (session.isRasterFull()){
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
						message = session.getName(session.getOverallWonPlayer()) + " won the game!";

					DialogResult dialogResult2 = MessageBox.Show(message, "Game over!", MessageBoxButtons.OK);

					if (dialogResult2 == DialogResult.OK)
					{
						this.Hide();
					}
				}
			}
        }//checkIfWon

        private void drawGrid() {
            I = new Bitmap(columns, rows);
            gr = Graphics.FromImage(I);

            gr.Clear(Color.White);

            gr = pnlGame.CreateGraphics();
            hr = pnlGame.CreateGraphics();
            hr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            myPen = new Pen(Brushes.Black, 1);
            myFont = new Font("Arial", 10);
            

            float x = 0;
            float y = 0;

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    gr.DrawRectangle(myPen, x, y, size, size);
                    x += size;
                }
                x = 0;
                y += size;
            }
        }//drawGrid

		private void drawHud()
		{
			Graphics hud = this.CreateGraphics();
			Rectangle blueCircle = new Rectangle(235, 20, 45, 45);
			Rectangle redCircle = new Rectangle(235, 80, 45, 45);
			hud.DrawEllipse(blackPen, blueCircle);
			hud.DrawEllipse(blackPen, redCircle);
			hud.FillEllipse(blueBrush, blueCircle);
			hud.FillEllipse(redBrush, redCircle);
		}

        private void drawToken(int column) {
            int freeSpot = emptySpotFree(column);
            
            Rectangle circle = new Rectangle((column * size) + 5, ((rows - freeSpot) * size) + 5, size - 10, size - 10);
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

            //TODO (Jel) : Defig de hover laten werken
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
                if (e.X >= i * size && e.X <= size * (i + 1))
                {
                    session.insertToken(i, playerAtPlay);
                    drawToken(i);
                }
            }
            checkIfWon();
            showPlayerAtTurn();
        }//pnlGame_MouseClick

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            drawGrid();
            showPlayerAtTurn();
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