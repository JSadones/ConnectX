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
        bool gameChanges = false, multiplayer;
        string title;
        Bitmap I;
        Graphics gr;
        ConnectX gamePlay;
        Pen myPen;
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        Pen blackPen = new Pen(Color.Black, 3);
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

        public Game(int columns, int rows, int tokenStreak, string namePlayer1, string namePlayer2)
        {
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

        private void updateScores()
        {
            lblPointsPlayer1.Text = gamePlay.getScore(1).ToString();
            lblPointsPlayer2.Text = gamePlay.getScore(2).ToString();
        }//updateScores

        private void showGameEndMessage()
        {
            updateScores();
            DialogResult dialogResult = MessageBox.Show("Play another one?", title, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                newGame();
            }
            else
            {
                showSessionEndMessage();
            }
        }

        private void showSessionEndMessage()
        {
            string message;
            if (gamePlay.getScore(1) == gamePlay.getScore(2)) message = "It's a tie!";
            else
            {
                message = getName(gamePlay.getWinnerOfLastSession()) + " won the game!";
            }
            DialogResult dialogResult2 = MessageBox.Show(message, "Game over!", MessageBoxButtons.OK);

            if (dialogResult2 == DialogResult.OK)
            {
                this.Hide();
            }
        }

        private void drawGrid()
        {
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

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
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

        private void switchPlayer(int column)
        {
            int row;
            if (multiplayer == false && gamePlay.getPlayerAtTurn() == 1)
            {
                row = gamePlay.checkIfColumnHasEmptySpot(column);
                gamePlay.insertToken(column, gamePlay.getPlayerAtTurn());
                drawToken(row, column);
                gamePlay.switchPlayerAtTurn();
            }
            else if (multiplayer == false & gamePlay.getPlayerAtTurn() == 2)
            {
                int spot = gamePlay.chooseRandomSpot();
                row = gamePlay.checkIfColumnHasEmptySpot(spot);
                gamePlay.insertToken(spot, gamePlay.getPlayerAtTurn());
                drawToken(spot, row);
                gamePlay.switchPlayerAtTurn();
            }
            else
            {
                row = gamePlay.checkIfColumnHasEmptySpot(column);
                if(row > -1)
                {
                    gamePlay.insertToken(column, gamePlay.getPlayerAtTurn());
                    drawToken(row, column);
                    gamePlay.switchPlayerAtTurn();
                    showPlayerAtTurn();
                }
                
                if (gamePlay.isLineStartingAt(row, column))
                {
                    gamePlay.incrementScorePlayer(gamePlay.getPlayerAtTurn());
                    updateScores();
                    if (gamePlay.getPlayerAtTurn() == 1) title = namePlayer1;
                    else title = namePlayer2;
                    title += " has won the game.";
                    if (!gameChanges) gameChanges = true;
                    showGameEndMessage();
                }
                else if(gamePlay.rasterIsFull())
                {
                    updateScores();
                    title = "Raster is full.";
                    showGameEndMessage();
                }
                
                
            }
            
            if (multiplayer == false && gamePlay.getPlayerAtTurn() == 2)
            {
                showPlayerAtTurn();
                row = gamePlay.checkIfColumnHasEmptySpot(column);
                switchPlayer(row);
            }
        }

        private void drawToken(int row, int column)
        {
            if (row > -1)
            {
                //Point location = new Point((column * size) + startWidth, -1 * rows + startHeight);
                Rectangle circle = new Rectangle((column * size) + 5 + startWidth, ((rows - row - 1) * size) + 5 + startHeight, size - 10, size - 10);
                gr.DrawEllipse(blackPen, circle);

                if (gamePlay.getPlayerAtTurn() == 1)
                {
                    //token token = new token();
                    //token.create(1, size, location, pnlGame);
                    //pnlGame.Controls.Add(token);
                    gr.FillEllipse(blueBrush, circle);
                }
                else
                {
                    //token token = new token();
                    //token.create(2, size, location, pnlGame);
                    //pnlGame.Controls.Add(token);
                    gr.FillEllipse(redBrush, circle);
                }
            }
        }//drawToken

        private void pnlGame_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < columns; i++)
            {
                if ((i * size) + startWidth <= e.X && e.X <= (size * (i + 1) + startWidth))
                {
                    switchPlayer(i);
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

        private void newGame()
        {
            gamePlay.nextGame();
            gamePlay.switchPlayerAtTurn();
            drawGrid();
            showPlayerAtTurn();
        }//newGame

        private void calculateSlotSize()
        {
            size = 480 / rows;
        }//calculateSlotSize

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gameChanges)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to close the game?", "Game is still in progress", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    showSessionEndMessage();
                }
            }
        }//Game_FormClosing
        #endregion
    }

    class token : PictureBox
    {
        #region State
        Random r = new Random();
        #endregion

        #region Constructor
        public token()
        {
            move();
        }//token
        #endregion

        #region Methods
        public void create(int player, int size, Point location, Panel pnlGame)
        {
            this.Parent = pnlGame;
            this.Location = location;
            //this.MinimumSize = new Size(7, 7);
            this.Size = new Size(size, size);
            this.BackColor = Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            if (player == 1) this.BackgroundImage = Resources.blueToken;
            else this.BackgroundImage = Resources.redToken;
        }//create

        private void move()
        {
            Timer t = new Timer();
            t.Interval = 10;

            t.Tick += new EventHandler(t_Tick);
            
            t.Start();
        }//move

        private void t_Tick(object sender, EventArgs e)
        {
            this.Location += new Size(0, 5);
        }//t_Tick
        #endregion
    }
}