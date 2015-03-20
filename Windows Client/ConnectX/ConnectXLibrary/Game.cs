using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectXLibrary
{
    public partial class Game : Form
    {
        #region State
        private int rows;
        private int columns;
        private float size = 80;
        ConnectXInterface game;

        Graphics gr;
        Pen myPen;
        Font myFont;

        string namePlayer1, namePlayer2;

        #endregion

        #region Constructor
        public Game() {
            InitializeComponent();

            namePlayer1 = showDialog("Naam Speler 1","");
            namePlayer2 = showDialog("Naam Speler 2", "");

            gr = pnlGame.CreateGraphics();
            myPen = new Pen(Brushes.Black, 1);
            myFont = new Font("Arial", (pnlGame.Width <= pnlGame.Height) ? size / 3 : size / 3);

            newSession();

            game.newGame();
            rows = game.getRows();
            columns = game.getColumns();
            drawGrid();
        }
        #endregion

        #region Methods

        //###### IN GAME.DESIGNER DIT OOK UNCOMMENTEN ######
        //private void Game_FormClosing(object sender, FormClosingEventArgs e) {
        //    Menu menu = new Menu();
        //    menu.StartPosition = FormStartPosition.Manual;
        //    menu.Location = new Point(this.Location.X, this.Location.Y);
        //    menu.Show();
        //    this.Hide();
        //}

        //private void drawCircles() {
        //    System.Drawing.Graphics graphics = this.CreateGraphics();
        //    System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(75, 75, 100, 100);
        //    graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
        //    graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);
        //}
        #endregion

        private void updateScores()
        {
            lblPointsPlayer1.Text = game.getScore(1).ToString();
            lblPointsPlayer2.Text = game.getScore(2).ToString();
        }

        private void newSession()
        {

            game = new ConnectXInterface();
            game.setName(1, namePlayer1);
            game.setName(2, namePlayer2);

            lblPlayer1.Text = game.getName(1);
            lblPlayer2.Text = game.getName(2);

            updateScores();
            
        }



        private string showDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 500;
            prompt.Height = 150;
            prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
            prompt.Text = caption;
            prompt.StartPosition = FormStartPosition.CenterScreen;
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.ShowDialog();
            return textBox.Text;
        }

        private void pnlGame_MouseClick(object sender, MouseEventArgs e) {
            //MessageBox.Show("X : " + e.X);
            //Zorgen dat dynamisch is en niet hardgecodeerd
            int playerAtPlay = game.getPlayerAtPlay();
            if (e.X >= 0 && e.X <= 80) {

                game.insertToken(0, playerAtPlay);
            }
            else if (e.X >= 80 && e.X <= 160) {
                game.insertToken(1, playerAtPlay);
            }
            else if (e.X >= 160 && e.X <= 240) {
                game.insertToken(2, playerAtPlay);
            }
            else if (e.X >= 240 && e.X <= 320) {
                game.insertToken(3, playerAtPlay);
            }
            else if (e.X >= 320 && e.X <= 400) {
                game.insertToken(4, playerAtPlay);
            }
            else if (e.X >= 400 && e.X <= 480) {
                game.insertToken(5, playerAtPlay);
            }
            else if (e.X >= 480 && e.X <= 560) {
                game.insertToken(6, playerAtPlay);
            }

            //pnlGame.Invalidate();
            drawGrid();

            if (game.isCurrentGameWon() || game.isRasterFull())
            {
             //   gr.Clear(Color.White);
                updateScores();

                DialogResult dialogResult = MessageBox.Show("Play another game?", "?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    game.newGame();
                }
                else if (dialogResult == DialogResult.No)
                {
                    newSession();
                }

            }

        }
        private void drawGrid() {
            //TODO : Array wordt van boven naar beneden gerenderd

            gr.Clear(Color.White);

            float x = 0;
            float y = 0;



            //Vertical lines
            for (int i = 0; i < columns + 1; i++) {
                gr.DrawLine(myPen, x, y, x, size * columns);
                x += size;
            }

            x = 0f;
            //Horizontal lines
            for (int i = 0; i < rows + 1; i++) {
                gr.DrawLine(myPen, x, y, size * columns, y);
                y += size;
            }

            x = 0f;
            y = 0f;
            int counter = 1;

            //Counter
            int[,] raster = game.getRaster();

            y = size * rows;
            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < columns; c++) {
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
    }
}
