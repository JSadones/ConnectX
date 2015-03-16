namespace XOPeenRijLibrary
{
    public class XOPeenRij
    {
        private bool won;

        #region Properties
        public XOPeenRij()
        {
            won = false;
        }
        #endregion

        public bool exists()
        {
            return true;
        }

        public bool rasterExists()
        {
            return true;
        }

        public bool isWon() {
            if (won)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public bool isNotWon() {
            if (won)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool TestTrueIsWonAndFalseIsNotWon()
        {
            return false;
        }

        public void setWon(bool value) {
            won = value;
        }
    }
}