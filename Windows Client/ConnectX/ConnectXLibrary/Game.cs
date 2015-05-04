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
        bool gameChanges = false, multiplayer, gameEnd = false;
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
        //===Drawing methods===
        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            drawGrid();
            drawHud();
        }//pnlGame_Paint

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

        private void calculateSlotSize()
        {
            size = 480 / rows;
        }//calculateSlotSize


        //===Messageboxes methods===
        private void showGameEndMessage(string title)
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
        }//showGameEndMessage

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
        }//showSessionEndMessage

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


        //===GUI Methods===
        private void updateScores()
        {
            lblPointsPlayer1.Text = gamePlay.getScore(1).ToString();
            lblPointsPlayer2.Text = gamePlay.getScore(2).ToString();
        }//updateScores

        private void showPlayerAtTurn()
        {
            int playerAtTurn = gamePlay.getPlayerAtTurn();
            if (playerAtTurn == 1) lblTurnName.Text = namePlayer1;
            else lblTurnName.Text = namePlayer2;
        }//showPlayerAtTurn


        //===Input Methods===
        private void pnlGame_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < columns; i++)
            {
                if (i * size + startWidth <= e.X && e.X <= (size * (i + 1) + startWidth))
                {
                    gameEnd = false;

                    processTurn(i);

                    break;
                }
            }
        }//pnlGame_MouseClick

        private void processTurn(int column)
        {
            int row = gamePlay.selectLowestAvailableRow(column);

            if (gamePlay.insertToken(column, row, gamePlay.getPlayerAtTurn()))
            {
                drawToken(row, column);

                if (!checkTurn(row, column))
                {
                    gamePlay.switchPlayerAtTurn();
                    showPlayerAtTurn();

                    if (!multiplayer && !gameEnd && gamePlay.getPlayerAtTurn() == 2)
                    {
                        insertTokenByAI();
                    }
                }
            }
        }

        private void insertTokenByAI()
        {
            int column = gamePlay.chooseRandomSpot();
            processTurn(column);
        }//insertTokenByAI


        //===Other methods===
        private bool checkTurn(int row, int column)
        {
            string title;
            if (gamePlay.checkWinnerAllDirections(row, column))
            {
                gamePlay.incrementScorePlayer(gamePlay.getPlayerAtTurn());
                updateScores();
                if (gamePlay.getPlayerAtTurn() == 1) title = namePlayer1;
                else title = namePlayer2;
                title += " has won the game.";
                showGameEndMessage(title);
                gameEnd = true;
                if (!gameChanges) gameChanges = true;
                return true;
            }
            else if (gamePlay.rasterIsFull())
            {
                title = "Raster is full.";
                showGameEndMessage(title);
                gameEnd = true;
                return true;
            }
            else return false;
        }//checkTurn

        private void newGame()
        {
            gamePlay.newGame();
            drawGrid();
            showPlayerAtTurn();
        }//newGame
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