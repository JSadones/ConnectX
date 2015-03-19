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
            float xMargin = pnlGame.Width / columns;
            float yMargin = pnlGame.Height / rows;

            Font myFont = new Font("Arial", (pnlGame.Width <= pnlGame.Height) ? xMargin / 3 : yMargin / 3);

            //Vertical lines
            for (int i = 0; i < columns + 1; i++) {
                gr.DrawLine(myPen, x, y, x, yMargin * columns);
                x += xMargin;
            }

            x = 0f;
            //Horizontal lines
            for (int i = 0; i < rows + 1; i++) {
                gr.DrawLine(myPen, x, y, xMargin * columns, y);
                y += yMargin;
            }

            x = 0f;
            y = 0f;
            int counter = 1;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    gr.DrawString(Convert.ToString(counter), myFont, Brushes.Black, x + myFont.Size, y + myFont.Size);
                    x += xMargin;
                    counter++;
                }
                y += yMargin;
                x = 0;
            }
        }
        #endregion
    }
}
