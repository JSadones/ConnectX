namespace ConnectXLibrary
{
    public class ConnectXInterface
    {
		private int scorePlayer1 = 0;
		private int scorePlayer2 = 0;

        private ConnectX game;

        public ConnectXInterface() {
        }

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
	}
}
