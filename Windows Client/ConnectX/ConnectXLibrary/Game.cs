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
        private static float size = 60;
        Bitmap I;
        Graphics gr;
        Graphics hr;
        ConnectXInterface session;
        Pen myPen;
        Font myFont;
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
        }
        #endregion

        #region Methods
        private void updateScores() {
            lblPointsPlayer1.Text = session.getScore(1).ToString();
            lblPointsPlayer2.Text = session.getScore(2).ToString();
        }

        private void newSession() {
            session = new ConnectXInterface(rows,columns, winstreak);
            session.setName(1, namePlayer1);
            session.setName(2, namePlayer2);

            lblPlayer1.Text = session.getName(1);
            lblPlayer2.Text = session.getName(2);

            updateScores();
        }

        private void pnlGame_MouseClick(object sender, MouseEventArgs e) {
            int playerAtPlay = session.getPlayerAtPlay();

            for (int i = 0; i < columns; i++) { 
                if(e.X >= i * size && e.X <= size * (i + 1)){
                    session.insertToken(i, playerAtPlay);
                }
            }
            drawGrid();
            checkIfWon();
        }

        private void checkIfWon() {
            if (session.isCurrentGameWon() || session.isRasterFull()) {
                gr.Clear(Color.White);
                updateScores();

                DialogResult dialogResult = MessageBox.Show("Play another game?", "?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) {
                    session.newGame();
                    drawGrid();
                } else if (dialogResult == DialogResult.No) {
                    string message;
                    if (session.getOverallWonPlayer() == 0)
                        message = "It's a tie!";
                    else
                        message = session.getName(session.getOverallWonPlayer()) + " won the game!";

                    DialogResult dialogResult2 = MessageBox.Show(message, "YeeHOO", MessageBoxButtons.OK);

                    if (dialogResult2 == DialogResult.OK) {
                        this.Hide();
                    }
                }
            }
        }

        private void drawGrid() {
            I = new Bitmap(columns, rows);
            gr = Graphics.FromImage(I);

            gr = pnlGame.CreateGraphics();
            hr = pnlGame.CreateGraphics();
            hr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            myPen = new Pen(Brushes.Black, 1);
            myFont = new Font("Arial", 10);
            
            gr.Clear(Color.White);

            float x = 0;
            float y = 0;

            //Grid tekenen
            //TODO (Jel) : Dynamisch volgens panel de grootte van de 
            //size aanpassen
            for (int i = 0; i < columns; i++) {
                for (int j = 0; j < rows; j++) {
                    gr.DrawRectangle(myPen, x, y, size, size);
                    x += size;
                }
                x = 0;
                y += size;
            }
            drawCounter();
        }

        private void drawCounter() {
            //Counter
            float x = 0;
            float y = 0;
            int counter = 1;
            int[,] raster = session.getRaster();

            //TODO (Jel) : Waarom - 1 hier doen? UITZOEKEN PLS
            y = size * (rows - 1);
            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < columns; c++) {
                    gr.DrawString(Convert.ToString(raster[r, c]), myFont, Brushes.Black, x + myFont.Size, y + myFont.Size);
                    x += size;
                    counter++;
                }
                y -= size;
                x = 0;
            }

            Pen blackPen = new Pen(Color.Black, 1);

            Rectangle circle = new Rectangle(0, 0, 30, 30);

            gr.DrawEllipse(blackPen, circle);
        }

        private void pnlGame_MouseMove(object sender, MouseEventArgs e) {
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
        }
        #endregion
    }
}