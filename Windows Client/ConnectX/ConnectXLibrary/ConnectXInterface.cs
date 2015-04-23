﻿namespace ConnectXLibrary
{
    public class ConnectXInterface {
        #region State
        private int scorePlayer1 = 0;
		private int scorePlayer2 = 0;
		private string namePlayer1;
		private string namePlayer2;
		private int rows;
		private int columns;
		private int streak;
        private ConnectX game;
        #endregion

        #region Constructor
        public ConnectXInterface()
        {
            this.rows = ConnectX.GetDefaultNumberOfRows();
            this.columns = ConnectX.GetDefaultNumberOfColumns();
            this.streak = ConnectX.GetDefaultStreak();

            newGame();
        }//ConnectXInterface

        public ConnectXInterface(int rows, int columns) {
			this.rows = rows;
			this.columns = columns;
			this.streak = ConnectX.GetDefaultStreak();
            newGame();
        }//ConnectXInterface

		public ConnectXInterface(int rows, int columns, int streak)
		{
			this.rows = rows;
			this.columns = columns;
			this.streak = streak;
		}//ConnectXInterface
        #endregion

        #region Properties
        public int getRows()
        {
            return game.getRows();
        }//getRows

        public int[,] getRaster()
        {
            return game.getRaster();
        }//getRaster

        public string getName(int player)
        {
            if (player == 1)
            {
                return namePlayer1;
            }
            else if (player == 2)
            {
                return namePlayer2;
            }
            else return "";
        }//getName

        public int getOverallWonPlayer()
        {
            if (scorePlayer1 > scorePlayer2)
            {
                return 1;
            }
            else if (scorePlayer1 < scorePlayer2)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }//getOverallWonPlayer

        public int getToken(int row, int column)
        {
            return game.getToken(row, column);
        }//getToken

        public int getCurrentGameWonPlayer()
        {
            return game.getCurrentGameWonPlayer();
        }//getCurrentGameWonPlayer

        public int getScore(int player)
        {
            if (player == 1)
            {
                return scorePlayer1;
            }
            else return scorePlayer2;
        }//getScore

        public int getColumns()
        {
            return game.getColumns();
        }//getColumns

        public int getPlayerAtPlay()
        {
            return game.getPlayerAtTurn();
        }//getPlayerAtPlay
        #endregion

        #region Methods
        public void newGame()
        {
            game = new ConnectX(rows, columns, streak);
        }//newGame

		public void newGame(int players, int rows, int columns, int tokenStreak)
        {
			game = new ConnectX(rows, columns, tokenStreak);
		}//newGame

        public bool gameRunning()
        {
            if (game != null)
            {
                return true;
            }
            else return false;
        }//gameRunning

        public void setName(int playerNumber, string playerName)
        {
            if (playerNumber == 1)
            {
                namePlayer1 = playerName;
            }
            else if (playerNumber == 2)
            {
                namePlayer2 = playerName;
            }
        }//setName

        public bool isCurrentGameWon()
        {
            return game.isWon();
        }//isCurrentGameWon

        public bool isColumnFull(int column)
        {
            return game.isColumnFull(column);
        }//isColumnFull

        public bool isRasterFull()
        {
            return game.rasterIsFull();
        }//isRasterFull

		public bool insertToken(int column, int player)
        {
			if (player == game.getPlayerAtTurn())
            {
				if (game.insertToken(column, player))
                {
                    if (game.isWon())
                    {
                        incrementScorePlayer(game.getCurrentGameWonPlayer());
                    }
					return true;
				}
				else return false;
			} else return false;			
		}//insertToken

        public void incrementScorePlayer(int player)
        {
            switch (player)
            {
                case 1:
                    scorePlayer1++;
                    break;

                case 2:
                    scorePlayer2++;
                    break;
            }
        }//incrementScorePlayer

        public bool insertTokenByAI()
        {
            ConnectX connectX = new ConnectX();
            return game.insertTokenByAI();
        }//insertTokenByAI
		#endregion
	}
}