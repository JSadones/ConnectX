using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectXLibrary
{
    public partial class Game : Form
    {
        #region State
        private int rows, columns;
        private string namePlayer1, namePlayer2;
        private float size = 60;

        ConnectXInterface session;

        Graphics gr;
        Pen myPen;
        Font myFont;
        #endregion

        #region Constructor
        public Game() {
            InitializeComponent();

            namePlayer1 = "test";
            namePlayer2 = "test2";

            newSession();
            session.newGame();
            rows = session.getRows();
            columns = session.getColumns();
        }
        #endregion

        #region Methods
        private void updateScores()
        {
            lblPointsPlayer1.Text = session.getScore(1).ToString();
            lblPointsPlayer2.Text = session.getScore(2).ToString();
        }

        private void newSession() {

            session = new ConnectXInterface();
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


            //pnlGame.Invalidate();
            //gr.Clear(Color.White);
            drawGrid();

            if (session.isCurrentGameWon() || session.isRasterFull())
            {
                gr.Clear(Color.White);
                updateScores();

                DialogResult dialogResult = MessageBox.Show("Play another game?", "?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    session.newGame();
                    drawGrid();
                } else if (dialogResult == DialogResult.No) {
                    string message;
                    if (session.getOverallWonPlayer() == 0)
                        message = "It's a tie!";
                    else
                        message = session.getName(session.getOverallWonPlayer()) + " won the game!";

                    DialogResult dialogResult2 = MessageBox.Show(message, "YeeHOO", MessageBoxButtons.OK);

                    if (dialogResult2 == DialogResult.OK)
                    {
                        this.Hide();
                    }
                }

            }

        }

        private void drawGrid() {
            gr = pnlGame.CreateGraphics();
            gr.Clear(Color.White);
            float x = 0;
            float y = 0;
            
            myPen = new Pen(Brushes.Black, 1);
            myFont = new Font("Arial", 10);


            //Vertical lines
            for (int i = 0; i < columns; i++) {
                gr.DrawLine(myPen, x, y, x, size * columns);
                x += size;
            }

            x = 0;
            //Horizontal lines
            for (int i = 0; i < rows; i++) {
                gr.DrawLine(myPen, x, y, size * columns, y);
                y += size;
            }

            x = 0f;
            y = 0f;
            int counter = 1;

            //Counter
            int[,] raster = session.getRaster();

            y = size * rows;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    gr.DrawString(Convert.ToString(raster[r, c]), myFont, Brushes.Black, x + myFont.Size, y + myFont.Size);
                    x += size;
                    counter++;
                }
                y -= size;
                x = 0;
            }

            //drawCircles();
        }

        private void btnDrawGrid_Click(object sender, EventArgs e) {
            drawGrid();
        }
        #endregion
    }
}