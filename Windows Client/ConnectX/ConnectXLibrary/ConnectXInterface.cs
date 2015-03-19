namespace ConnectXLibrary
{
    public class ConnectXInterface {
        #region State
        private int scorePlayer1 = 0;
		private int scorePlayer2 = 0;
		private int playerAtPlay;
        private ConnectX game;
        #endregion

        #region Constructor
        public ConnectXInterface() {
        }
        #endregion

        public void newGame(int players, int rows, int columns) {
            game = new ConnectX(rows, columns);
        }
        #region Methods
        public void newGame() {
            game = new ConnectX();
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

		public void setPlayerAtPlay(int playerAtPlay) {
			this.playerAtPlay = playerAtPlay;
		}

		public int getPlayerAtPlay() {
			return playerAtPlay;
		}

		public bool insertToken(int column, int player) {
			if (player == playerAtPlay) {
				return game.insertToken(column, player);
			} else return false;
		}

        public void finish() {
            throw new System.NotImplementedException();
        }

        public bool isFinished { get; set; }

        public bool isCurrentGameWon { get; set; }

        public void newGame(int p1, int p2, int p3, int p4) {
            throw new System.NotImplementedException();
        }

        public void reset() {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
