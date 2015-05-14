using ConnectXLibrary.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectXLibrary
{
    class token : PictureBox
    {
        #region State
        Timer t;
        Random r = new Random();
        int row, rows, size, startHeight;
        bool completed = false;
        #endregion

        #region Constructor
        public token()
        {
            move();
        }//token
        #endregion

        #region Methods
        public void create(int player, int size, Point location, Panel pnlGame, int row, int rows, int startHeight)
        {
            this.row = row;
            this.rows = rows;
            this.size = size;
            this.startHeight = startHeight;

            this.Parent = pnlGame;
            this.Location = location;
            this.Size = new Size(size, size);
            this.BackColor = Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            if (player == 1) this.BackgroundImage = Resources.blueToken;
            else this.BackgroundImage = Resources.redToken;
            while (completed)
            {
                System.Diagnostics.Debug.WriteLine("KANKERHOMOS");
            }
        }//create

        private void move()
        {
            t = new Timer();
            t.Interval = 10;

            t.Tick += new EventHandler(t_Tick);

            t.Start();
        }//move

        private void t_Tick(object sender, EventArgs e)
        {
            this.Location += new Size(0, 5);
            if (this.Location.Y > ((rows - row - 1) * size) + startHeight)
            {
                completed = !completed;
                t.Stop();
            }
        }//t_Tick
        #endregion
    }
}
