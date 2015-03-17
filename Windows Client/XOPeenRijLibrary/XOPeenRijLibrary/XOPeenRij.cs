namespace XOPeenRijLibrary
{
    public class XOPeenRij
    {
        #region State
        private bool won;
        private int[,] raster;
        private int rows = 6;
        private int columns = 7;
        private int tokenStreak = 4;
        #endregion State

        #region Constructor
        public XOPeenRij()
        {
            won = false;
            raster = new int[rows, columns];
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
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
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    if (raster[i, j] != 0) {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool isWon() {

            if (isWonVertical())
            {
                won = true;
                return won;
                // ToDo, Winnende Speler Opvangen
            }

            if (isWonDiagonal())
            {
                won = true;
                return won;
                // ToDo, Winnende Speler Opvangen
            }

            // Indien we hier belanden, is het spel duidelijk niet gewonnen
            won = false;
            return won;
              
        }


        public bool isWonVertical() {

            // De tellers voor de streaks te zoeken, voor elk van de spelers afzonderlijk
            int counterPlayer1 = 0;
            int counterPlayer2 = 0;

            // EERSTE TEST: STREAK IN VERTICALE RICHTING

            // We passeren indien nodig iedere kolom 
            for (int i = 0; i < columns; i++)
            {
                // Daarna lopen we van beneden af iedere rij af
                for (int j = 0; j < rows; j++)
                {
                    // Indien we een 0 vinden, gaan we naar de bovenliggende rij
                    // TODO: Code moet netter, zodat we meteen naar de volgende kolom kunnen
                    if (raster[j, i] == 0)
                    {
                        break;
                    }

                    // Indien we een één vinden, verhogen we de streakteller van speler 1
                    if (raster[j, i] == 1)
                    {
                        counterPlayer1++;
                    }
                    // Indien we geen één vinden, moet de streakteller terug op 0
                    else counterPlayer1 = 0;

                    // Indien we een 2 vinden, verhogen we de streakteller van speler 2
                    if (raster[j, i] == 2)
                    {
                        counterPlayer2++;
                    }
                    // Indien we geen 2 vinden, moet de streakteller terug op 0
                    else counterPlayer2 = 0;

                    // Indien speler 1 de streak behaald heeft, is het spel gewonnen
                    if (counterPlayer1 == tokenStreak)
                    {
                        won = true;
                        return won;
                        // TODO: Score speler 1 verhogen
                    }

                    // Indien speler 2 de streak behaald heeft, is het spel gewonnen
                    if (counterPlayer2 == tokenStreak)
                    {
                        won = true;
                        return won;
                        // TODO: Score speler 2 verhogen
                    }
                }
            
            }

            // Indien we hier belanden, is het spel niet gewonnen. 
			won = false;
            return won;

        }


        public bool isWonDiagonal()
        {
			// De tellers voor de streaks te zoeken, voor elk van de spelers afzonderlijk
			int counterPlayer1 = 0;
			int counterPlayer2 = 0;
			int counterRow;
			int counterColumn;

			// De kolommen worden afgelopen van rechts naar links
			for (int i = columns - 1; i >= 0; i--)
			{
				counterRow = 0;
				counterColumn = i;
				while (counterColumn < columns && counterRow < rows)
				{
					if (raster[counterColumn, counterRow] == 1)
					{
						counterPlayer1++;
					}

					else
					{
						counterPlayer1 = 0;
					}

					if (raster[counterColumn, counterRow] == 2)
					{
						counterPlayer2++;
					}

					else
					{
						counterPlayer2 = 0;
					}

					counterRow++;
					counterColumn++;

					if (counterPlayer1 == tokenStreak)
					{
						won = true;
						return won;
						// TODO: Score speler 1 verhogen
					}

					// Indien speler 2 de streak behaald heeft, is het spel gewonnen
					if (counterPlayer2 == tokenStreak)
					{
						won = true;
						return won;
						// TODO: Score speler 2 verhogen
					}
				}
			}
			// Indien we hier belanden, is het spel niet gewonnen. 
			won = false;
			return won;
        }

        public bool TestTrueIsWonAndFalseIsNotWon()
        {
            return false;
        }

        public void insertToken(int column, int player)
        {
            int row = 0;
            while (row < rows) {
                if (raster[row, column] == 0) {
                    raster[row, column] = player;
                    break;
                }
                row++;
            }
        }

        public bool hasNotCrashed()
        {
            return false;
        }

        public bool rasterIsFull()
        {
            for (int i = 0; i < columns; i++) {
                if (raster[rows - 1, i] == 0) {
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}