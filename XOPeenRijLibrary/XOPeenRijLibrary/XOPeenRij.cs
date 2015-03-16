namespace XOPeenRijLibrary
{
    public class XOPeenRij
    {
        #region State
        private bool won;
        private int[,] raster;
        private int rijen = 6;
        private int kolommen = 7;
        #endregion State

        #region Constructor
        public XOPeenRij()
        {
            won = false;
            raster = new int[rijen, kolommen];
            for (int i = 0; i < rijen; i++) {
                for (int j = 0; j < kolommen; j++) {
                    raster[i, j] = 0;
                }
            }
        }
        #endregion

        #region Properties
        
        #endregion

        #region Methods
        public bool exists()
        {
            return true;
        }

        public bool rasterExists()
        {
            return true;
        }

        public bool isRasterInitializedWithZeros()
        {
            for (int i = 0; i < rijen; i++) {
                for (int j = 0; j < kolommen; j++) {
                    if (raster[i, j] != 0) {
                        return false;
                    }
                }
            }
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
        #endregion
    }
}