﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using ConnectXLibrary.Properties;

namespace ConnectXLibrary
{
    public partial class Game : Form
    {
        #region State
        private int rows, columns, tokenStreak, startWidth, startHeight, size, difficulty;
        private string namePlayer1, namePlayer2;
        bool gameChanges = false, multiplayer, gameEnd = false;
        Bitmap I;
        Graphics gr;
        ConnectX board;
        Pen myPen;
        AI ai;
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        Pen blackPen = new Pen(Color.Black, 3);
        bool turn = true;
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
            //multiplayer = false;

            //board = new ConnectX(rows, columns, tokenStreak, multiplayer);
            //ai = new AI(board);
            ////nextGame();

            lblPlayer1.Text = namePlayer1;
            lblPlayer2.Text = cpuName;
            lblStreakNumber.Text = tokenStreak.ToString();
            //showPlayerAtTurn();
            board = new ConnectX(rows, columns, tokenStreak);
            ai = new AI(board);

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
            //nextGame();

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
            Rectangle blueCircle = new Rectangle(85, 10, 35, 35);
            Rectangle redCircle = new Rectangle(85, 55, 35, 35);
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

                if (board.getPlayerAtTurn() == 1)
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

        private void drawToken2(int row, int column, int player)
        {
            if (row > -1)
            {
                //Point location = new Point((column * size) + startWidth, -1 * rows + startHeight);
                Rectangle circle = new Rectangle((column * size) + 5 + startWidth, ((rows - row - 1) * size) + 5 + startHeight, size - 10, size - 10);
                gr.DrawEllipse(blackPen, circle);

                if (player == 1)
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
                nextGame();
            }
            else
            {
                showSessionEndMessage();
            }
        }//showGameEndMessage

        private void showSessionEndMessage()
        {
            string message;
            if (board.getScore(1) == board.getScore(2)) message = "It's a tie!";
            else
            {
                message = getName(board.getWinnerOfLastSession()) + " won the game!";
            }
            DialogResult dialogResult2 = MessageBox.Show(message, "Game over!", MessageBoxButtons.OK);

            if (dialogResult2 == DialogResult.OK)
            {
                Menu menu = new Menu();
                menu.Show();
                this.Close();
            }
        }//showSessionEndMessage

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gameChanges)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to close the game?", "Game is still in progress", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No) e.Cancel = true;
                else showSessionEndMessage();
            }
        }//Game_FormClosing

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Visible = true;
        }//btnBack_Click


        //===GUI Methods===
        private void updateScores()
        {
            lblPointsPlayer1.Text = board.getScore(1).ToString();
            lblPointsPlayer2.Text = board.getScore(2).ToString();
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
            if (board.isValidMove(column))
            {
                int testsdf = board.getLowestAvailableRowInColumn2(column);
                board.makeMovePlayer(column);
                drawToken2(testsdf, column, 1);
                checkTurn(testsdf, column);
            }
            if (!multiplayer)
            {
                int aiColumn = insertTokenByAI();
                int testsdfa = board.getLowestAvailableRowInColumn2(aiColumn);
                drawToken2(testsdfa, aiColumn, 2);
                board.makeMoveAI(aiColumn);
                checkTurn(testsdfa, column);
            }
        }//processTurn

        private int insertTokenByAI()
        {
            int column = 0;
            switch(difficulty)
            {
                case 1:
                    column = board.chooseRandomSpot();
                    break;
                case 2:
                    Random rnd = new Random();
                    int chance = rnd.Next(0, 10);

                    if (chance < 3) column = ai.makeTurn();
                    else board.chooseRandomSpot();
                    break;
                case 3:
                    column = ai.makeTurn();
                    break;
            }
            return column;
        }//insertTokenByAI


        //===Other methods===
        private bool checkTurn(int row, int column)
        {
            string title;
            if (board.isCurrentGameWon(row, column))
            {
                board.incrementScoreOfPlayer(board.getPlayerAtTurn());
                updateScores();
                if (board.getPlayerAtTurn() == 1) title = namePlayer1;
                else title = namePlayer2;
                title += " has won the game.";
                showGameEndMessage(title);
                gameEnd = true;
                if (!gameChanges) gameChanges = true;
                return true;
            }
            else if (board.isTie())
            {
                title = "Raster is full.";
                showGameEndMessage(title);
                gameEnd = true;
                return true;
            }
            else return false;
        }//checkTurn

        private void nextGame()
        {
            board.nextGame();
            drawGrid();
            showPlayerAtTurn();
        }//nextGame
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