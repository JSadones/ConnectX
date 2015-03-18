namespace ConnectXLibrary
{
    public class XOPeenRijInterface
    {
        private ConnectX game;

        public XOPeenRijInterface() {
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
    }
}