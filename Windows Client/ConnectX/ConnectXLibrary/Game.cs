using ConnectXLibrary.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConnectXLibrary
{
    public partial class Game : Form
    {
        #region State
        private int rows, columns, tokenStreak, startWidth, startHeight, size, difficulty;
        private string namePlayer1, namePlayer2;
        bool gameChanges = false, multiplayer, endGame = false;
        private byte PLAYER1 = 1, PLAYER2 = 2;

        ConnectX board;
        AI ai;

        Graphics gr;
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        Pen blackPen = new Pen(Color.Black, 3);
        #endregion

        #region Constructor
        public Game(int difficulty, int columns, int rows, int tokenStreak, string namePlayer1)
        {
            InitializeComponent();
            string cpuName = "Computer";

            this.namePlayer1 = namePlayer1;
            this.namePlayer2 = cpuName;
            this.rows = rows;
            this.columns = columns;
            this.tokenStreak = tokenStreak;
            this.difficulty = difficulty;

            lblPlayer1.Text = namePlayer1;
            lblPlayer2.Text = cpuName;
            lblStreakNumber.Text = tokenStreak.ToString();

            board = new ConnectX(rows, columns, tokenStreak);
            ai = new AI(board);

            showPlayerAtTurn();

        }//Game

        public Game(int difficulty, int columns, int rows, int tokenStreak, string namePlayer1, string namePlayer2)
        {
            InitializeComponent();
            this.namePlayer1 = namePlayer1;
            this.namePlayer2 = namePlayer2;
            this.rows = rows;
            this.columns = columns;
            this.tokenStreak = tokenStreak;
            this.difficulty = difficulty;
            multiplayer = true;

            board = new ConnectX(rows, columns, tokenStreak, multiplayer);

            lblPlayer1.Text = namePlayer1;
            lblPlayer2.Text = namePlayer2;
            lblStreakNumber.Text = tokenStreak.ToString();

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
            startWidth = (pnlGame.Width / 2) - ((size * columns) / 2);
            startHeight = (pnlGame.Height / 2) - ((size * rows) / 2);
            float x = startWidth, y = startHeight;

            Bitmap I = new Bitmap(rows, columns);
            gr = Graphics.FromImage(I);
            gr = pnlGame.CreateGraphics();
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gr.Clear(Color.NavajoWhite);
            Image newImage = Resources.frame;

            Pen myPen = new Pen(Brushes.Black, 1);

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
            Rectangle blueCircle = new Rectangle(85, 10, 35, 35);
            Rectangle redCircle = new Rectangle(85, 55, 35, 35);

            hud.DrawEllipse(blackPen, blueCircle);
            hud.DrawEllipse(blackPen, redCircle);
            hud.FillEllipse(blueBrush, blueCircle);
            hud.FillEllipse(redBrush, redCircle);
        }//drawHud

        private void drawToken(int column, int row, int player)
        {
            Rectangle circle = new Rectangle((column * size) + 5 + startWidth, ((rows - row - 1) * size) + 5 + startHeight, size - 10, size - 10);
            gr.DrawEllipse(blackPen, circle);

            if (player == PLAYER1) gr.FillEllipse(blueBrush, circle);
            else gr.FillEllipse(redBrush, circle);
        }//drawToken


        //===Messageboxes methods===
        private void showGameEndMessage(string title)
        {
            DialogResult dialogResult = MessageBox.Show("Play another one?", title, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) nextGame();
            else showSessionEndMessage();
        }//showGameEndMessage

        private void showSessionEndMessage()
        {
            string message;

            if (board.getScore(PLAYER1) == board.getScore(PLAYER2)) message = "It's a tie!";
            else message = getName(board.getWinnerOfLastSession()) + " won the game!";
            
            DialogResult dialogResult2 = MessageBox.Show(message, "Game over!", MessageBoxButtons.OK);

            if (dialogResult2 == DialogResult.OK)
            {
                endGame = false;
                this.Close();
            }
        }//showSessionEndMessage

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gameChanges && endGame)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to close the game?", "Game is still in progress", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) e.Cancel = true;
                else showSessionEndMessage();
            }
        }//Game_FormClosing

        private void btnBack_Click(object sender, EventArgs e)
        {
			if (gameChanges)
			{
				DialogResult dialogResult = MessageBox.Show("Are you sure you want to close the game?", "Game is still in progress", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes) showSessionEndMessage();
            }
            else this.Close();
        }//btnBack_Click


        //===GUI Methods===
        private void updateScores()
        {
            lblPointsPlayer1.Text = board.getScore(PLAYER1).ToString();
            lblPointsPlayer2.Text = board.getScore(PLAYER2).ToString();
        }//updateScores

        private void showPlayerAtTurn()
        {
            int playerAtTurn = board.getPlayerAtTurn();
            if (playerAtTurn == 1) lblTurnName.Text = namePlayer1;
            else lblTurnName.Text = namePlayer2;
        }//showPlayerAtTurn


        //===Input Methods===
        private void pnlGame_MouseClick(object sender, MouseEventArgs e)
        {
            for (int column = 0; column < columns; column++)
            {
                if (column * size + startWidth <= e.X && e.X <= (size * (column + 1) + startWidth))
                {
                    processTurn(column);
                    break;
                }
            }
        }//pnlGame_MouseClick

        private void processTurn(int column)
        {
            int row;
            int player;
           
            if (!board.isColumnFull(column))
            {
                player = board.getPlayerAtTurn();
                row = board.getLowestAvailableRowInColumn(column);
                board.insertToken(column, row, player);
                drawToken(column, row, player);

                if (!checkTurn())
                {
                    board.switchPlayerAtTurn();
                    showPlayerAtTurn();

                    if (!multiplayer)
                    {
                        player = board.getPlayerAtTurn();
                        int aiColumn = insertTokenByAI();
                        row = board.getLowestAvailableRowInColumn(aiColumn);
                        board.insertToken(aiColumn, row, player);
                        drawToken(aiColumn, row, player);

                        if (!checkTurn())
                        {
                            board.switchPlayerAtTurn();
                            showPlayerAtTurn();
                        }
                    }
                }
            }
        }//processTurn

        private int insertTokenByAI()
        {
            int column = 0;
            switch (difficulty)
            {
                case 1:
                    column = ai.chooseRandomSpot();
                    break;
                case 2:
                    column = ai.makeTurn(2);
                    break;
                case 3:
                    column = ai.makeTurn(4);
                    break;
                case 4:
                    column = ai.makeTurn(8);
                    break;
            }
            return column;
        }//insertTokenByAI


        //===Other methods===
        private bool checkTurn()
        {
            string title;
            if (board.hasWinner())
            {
                board.incrementScoreOfPlayer(board.getPlayerAtTurn());
                updateScores();

                if (board.getPlayerAtTurn() == 1) title = namePlayer1;
                else title = namePlayer2;
                title += " has won the game.";

                showGameEndMessage(title);
                if (!gameChanges) gameChanges = true;
                endGame = true;
                return true;
            }
            else if (board.isTie())
            {
                title = "Raster is full.";
                showGameEndMessage(title);
                endGame = true;
                return true;
            }
            else return false;
        }//checkTurn

        private void nextGame()
        {
            board.nextGame();
            drawGrid();
            showPlayerAtTurn();
            endGame = false;
        }//nextGame

        private void calculateSlotSize()
        {
            size = 480 / rows;
        }//calculateSlotSize
        #endregion
    }
}