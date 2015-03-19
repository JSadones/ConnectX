namespace ConnectXLibrary
{
    public class ConnectXInterface
    {
        #region State
        private int scorePlayer1 = 0;
		private int scorePlayer2 = 0;
<<<<<<< Updated upstream
		private int playerAtPlay;

=======
>>>>>>> Stashed changes
        private ConnectX game;
        #endregion

        #region Constructor
        public ConnectXInterface() {
        }
        #endregion

<<<<<<< Updated upstream
		public void newGame()
		{
			game = new ConnectX();

		}
        public void newGame(int players, int rows, int columns) 
		{
            game = new ConnectX(rows, columns);

=======
        #region Methods
        public void newGame() {
            game = new ConnectX();
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
<<<<<<< HEAD
		public void setPlayerAtPlay(int playerAtPlay)
		{
			this.playerAtPlay = playerAtPlay;
		}

		public int getPlayerAtPlay() {
			return playerAtPlay;
		}

		public bool insertToken(int column, int player)
		{
			if (player == playerAtPlay) {
				return game.insertToken(column, player);
			} else return false;
		}
	}
=======
        public void newGame(int p1, int p2, int p3)
        {
=======
        public void newGame(int p1, int p2, int p3) {
>>>>>>> Stashed changes
            throw new System.NotImplementedException();
        }

        public void setPlayerAtPlay(int p) {
            throw new System.NotImplementedException();
        }

        public bool insertToken(int p1, int p2) {
            throw new System.NotImplementedException();
        }

        public int getPlayerAtPlay() {
            throw new System.NotImplementedException();
        }
        #endregion
    }
>>>>>>> 5a2d9398649518b684d7112f323799d6de8d1fd3
}
