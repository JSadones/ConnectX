namespace XOPeenRijLibrary
{
    public class XOPeenRijInterface
    {
        private XOPeenRij game;

        public XOPeenRijInterface() {
        }

        public void newGame() {
            game = new XOPeenRij();
        }

        public bool gameRunning() {
            if (game != null) {
                return true;
            }
            else return false;
        }
    }
}