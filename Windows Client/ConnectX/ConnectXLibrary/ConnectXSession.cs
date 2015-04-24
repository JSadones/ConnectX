namespace ConnectXLibrary
{
    public class ConnectXSession {
        #region State
        private int scorePlayer1, scorePlayer2 = 0;
		private int rows;
		private int columns;
		private int streak;
        private ConnectX game;
        #endregion

        #region Constructor
        public ConnectXSession()
        {
            this.rows = ConnectX.GetDefaultNumberOfRows();
            this.columns = ConnectX.GetDefaultNumberOfColumns();
            this.streak = ConnectX.GetDefaultStreak();

            newGame();
        }//ConnectXInterface

        public ConnectXSession(int rows, int columns) {
			this.rows = rows;
			this.columns = columns;
			this.streak = ConnectX.GetDefaultStreak();
            newGame();
        }//ConnectXInterface

		public ConnectXSession(int rows, int columns, int streak)
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

        public bool gameRunning()
        {
            if (game != null)
            {
                return true;
            }
            else return false;
        }//gameRunning

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

		public bool checkIfWon(int column, int player)
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
            return true;
            //ConnectX connectX = new ConnectX();
            //return game.insertTokenByAI();
        }//insertTokenByAI
		#endregion
	}
}