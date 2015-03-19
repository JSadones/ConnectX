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
        #endregion

        #region Constructor
        public Game() {
            InitializeComponent();

            Graphics gr = pnlGame.CreateGraphics();
            ConnectX game = new ConnectX();
            rows = game.getRows();
            columns = game.getColumns();
        }
        #endregion

        #region Methods
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = pnlGame.CreateGraphics();
            Pen myPen = new Pen(Brushes.Black, 1);
            
            float x = 0f;
            float y = 0f;
            float size = 80;

            Font myFont = new Font("Arial", (pnlGame.Width <= pnlGame.Height) ? size / 3 : size / 3);

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

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    gr.DrawString(Convert.ToString(counter), myFont, Brushes.Black, x + myFont.Size, y + myFont.Size);
                    x += size;
                    counter++;
                }
                y += size;
                x = 0;
            }

            drawCircles();
        }

        //###### IN GAME.DESIGNER DIT OOK UNCOMMENTEN ######
        //private void Game_FormClosing(object sender, FormClosingEventArgs e) {
        //    Menu menu = new Menu();
        //    menu.StartPosition = FormStartPosition.Manual;
        //    menu.Location = new Point(this.Location.X, this.Location.Y);
        //    menu.Show();
        //    this.Hide();
        //}

        private void drawCircles() {
            System.Drawing.Graphics graphics = this.CreateGraphics();
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(75, 75, 100, 100);
            graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
            graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);
        }
        #endregion
    }
}
