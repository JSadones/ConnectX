namespace ConnectXLibrary
{
    public class ConnectXInterface
    {
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
    }
}
