namespace ConnectXLibrary
{
    public class ConnectXInterface {
        #region State
        private int scorePlayer1 = 0;
		private int scorePlayer2 = 0;
		private string namePlayer1;
		private string namePlayer2;
        private ConnectX game;
        #endregion

        #region Constructor
        public ConnectXInterface() {
            newGame();
        }
        #endregion

        #region Properties
        #endregion

        #region Methods
        public void newGame(int players, int rows, int columns) {
            game = new ConnectX(rows, columns);
        }

        public void newGame() {
            game = new ConnectX();
        }

		public void newGame(int players, int rows, int columns, int tokenStreak)
		{
			game = new ConnectX(rows, columns, tokenStreak);
		}

        public bool gameRunning() {
            if (game != null) {
                return true;
            }
            else return false;
        }

		public void setScorePlayer(int player) {
			switch (player) {
				case 1:
					scorePlayer1++;
					break;

				case 2:
					scorePlayer2++;
					break;
			}
		}

		public int getScore(int player) {
			if (player == 1) {
				return scorePlayer1;
			}
			else return scorePlayer2;
		}

        public int[,] getRaster()
        {
            return game.getRaster();
        }

        public int getRows()
        {
            return game.getRows();
        }

        public int getColumns()
        {
            return game.getColumns();
        }

		public int getPlayerAtPlay() {
			return game.getPlayerAtTurn();
		}

		public bool insertToken(int column, int player) {
			if (player == game.getPlayerAtTurn()) {
				if (game.insertToken(column, player)) {
                    if (game.isWon())
                    {
                        setScorePlayer(game.getCurrentGameWonPlayer());
                    }
					return true;
				}
				else return false;
			} else return false;

			
		}

		
        public bool isCurrentGameWon() {
			return game.isWon();
		}

        public bool isColumnFull(int column)
        {
            return game.isColumnFull(column);
        }

        public bool isRasterFull()
        {
            return game.rasterIsFull();
        }

        public void reset() {
			game = null;
			scorePlayer1 = 0;
			scorePlayer2 = 0;
			// ToDo: breng terug naar startscherm
        }

        public int getToken(int row, int column) {
			return game.getToken(row, column);
		}

        public int getCurrentGameWonPlayer()
        {
            return game.getCurrentGameWonPlayer();
        }

		public void setName(int playerNumber, string playerName)
		{
			if (playerNumber == 1) {
				namePlayer1 = playerName;
			} else if (playerNumber == 2) {
				namePlayer2 = playerName;
			}
		}
        public string getName(int player)
        {
			if (player == 1) {
				return namePlayer1;
			} else if (player == 2) {
				return namePlayer2;
			} else return "";
		}

		#endregion
	}
}
