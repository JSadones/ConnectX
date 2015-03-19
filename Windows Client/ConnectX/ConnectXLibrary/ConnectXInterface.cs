namespace ConnectXLibrary
{
    public class ConnectXInterface
    {
		private int scorePlayer1 = 0;
		private int scorePlayer2 = 0;
		private int playerAtPlay;

        private ConnectX game;

        public ConnectXInterface() {
        }

		public void newGame()
		{
			game = new ConnectX();

		}
        public void newGame(int players, int rows, int columns) 
		{
            game = new ConnectX(rows, columns);

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
}
