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
        }//create
        #endregion
    }
}
