using System;
using System.Collections.Generic;

namespace XOPeenRijLibrary
{
    public class XOPeenRij
    {
        #region State
        private bool won;
        private int[,] raster;
        private int rows;
        private int columns;
        private int tokenStreak;
        #endregion State

        #region Constructor
        public XOPeenRij(): this(6, 7, 4) {
        }

        public XOPeenRij(int rows, int columns, int tokenStreak) {
            this.rows = rows;
            this.columns = columns;
            this.tokenStreak = tokenStreak;

            won = false;
            raster = new int[rows, columns];
            clearRaster();
        }
        #endregion

        #region Properties
        public int getRows() {
            return rows;
        }

        public int getColumns() {
            return columns;
        }

        public int getStreakToReach() {
            return tokenStreak;
        }
        #endregion

        #region Methods
        public bool exists() {
            return true;
        }

        public bool rasterExists() {
            return true;
        }

        public bool isRasterInitializedWithZeros() {
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
            if (isWonVertical()) {
                return true;
                // ToDo, Winnende Speler Opvangen
            }else 
            if (isWonDiagonal45()) {
                return true;
                // ToDo, Winnende Speler Opvangen
            }else 
			if (isWonDiagonal135()) {
				return true;
				// ToDo, Winnende Speler Opvangen
			}
            return false;
        }

        public bool isWonVertical() {
            int counterPlayer1 = 0;
            int counterPlayer2 = 0;

            for (int i = 0; i < columns; i++) {
                for (int j = 0; j < rows; j++) {
                    // TODO: Code moet netter, zodat we meteen naar de volgende kolom kunnen
                    if (raster[j, i] == 0) {
                        break;
                    }
                    if (raster[j, i] == 1) {
                        counterPlayer1++;
                    } else counterPlayer1 = 0;
                    
                    if (raster[j, i] == 2) {
                        counterPlayer2++;
                    } else counterPlayer2 = 0;
                    if (counterPlayer1 == tokenStreak) {
                        won = true;
                        return won;
                        // TODO: Score speler 1 verhogen
                    }
                    if (counterPlayer2 == tokenStreak) {
                        won = true;
                        return won;
                        // TODO: Score speler 2 verhogen
                    }
                }
            }
			won = false;
            return won;
        }

		public bool isWonHorizontal()
		{
			int counterPlayer1 = 0;
			int counterPlayer2 = 0;

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					if (raster[i, j] == 0) 
					{
						break;
					}

					if (raster[i, j] == 1)
					{
						counterPlayer1++;
					} else counterPlayer1 = 0;

					if (raster[i, j] == 2)
					{
						counterPlayer2++;
					} else counterPlayer2 = 0;

					if (counterPlayer1 == tokenStreak)
					{
						won = true;
						return won;
					}

					if (counterPlayer2 == tokenStreak)
					{
						won = true;
						return won;
					}
				}
			}
			won = false;
			return won;
		}

        public bool isWonDiagonal45() {
			// De tellers voor de streaks te zoeken, voor elk van de spelers afzonderlijk
			int counterPlayer1 = 0;
			int counterPlayer2 = 0;
			int counterRow;
			int counterColumn;

			// 45°: De kolommen worden afgelopen van rechts naar links
			for (int i = columns - 1; i >= 0; i--)
			{
				counterRow = 0;
				counterColumn = i;
				while (counterColumn < columns && counterRow < rows)
				{
                    if (raster[counterRow, counterColumn] == 1)
					{
						counterPlayer1++;
					} else counterPlayer1 = 0;

                    if (raster[counterRow, counterColumn] == 2)
					{
						counterPlayer2++;
					} else counterPlayer2 = 0;

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


			// 45°: De rijen worden afgelopen vanaf de tweede rij, eerste kolom naar boven
			for (int i = 1; i < rows; i++)
			{
				counterRow = i;
				counterColumn = 0;

				while (counterColumn < columns && counterRow < rows)
				{
					if (raster[counterRow, counterColumn] == 1)
					{
						counterPlayer1++;
					}

					else
					{
						counterPlayer1 = 0;
					}

					if (raster[counterRow, counterColumn] == 2)
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

		public bool isWonDiagonal135()
		{
			// De tellers voor de streaks te zoeken, voor elk van de spelers afzonderlijk
			int counterPlayer1 = 0;
			int counterPlayer2 = 0;
			int counterRow;
			int counterColumn;

			// 135°: De kolommen worden afgelopen van links naar rechts
			for (int i = 0; i < columns; i++)
			{
				counterRow = 0;
				counterColumn = i;
				while (counterColumn > 0 && counterRow < rows)
				{
					// Als er een token van player1 gevonden wordt, teller van player2 vermeerderen met 1
					if (raster[counterRow, counterColumn] == 1)
					{
						counterPlayer1++;
					}

					// Als er geen token van player1 gevonden wordt, teller terug op 0 zetten
					else
					{
						counterPlayer1 = 0;
					}

					// Als er een token van player2 gevonden wordt, teller van player2 vermeerderen met 1
					if (raster[counterRow, counterColumn] == 2)
					{
						counterPlayer2++;
					}

					// Als er geen token van player2 gevonden wordt, teller terug op 0 zetten
					else
					{
						counterPlayer2 = 0;
					}

					counterRow++;
					counterColumn--;

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

			// 135°: De rijen worden afgelopen vanaf de tweede rij, laatste kolom naar boven
			for (int i = 1; i < rows; i++)
			{
				counterRow = i;
				counterColumn = columns - 1;

				while (counterColumn < columns && counterRow < rows)
				{
					if (raster[counterRow, counterColumn] == 1)
					{
						counterPlayer1++;
					}

					else
					{
						counterPlayer1 = 0;
					}

					if (raster[counterRow, counterColumn] == 2)
					{
						counterPlayer2++;
					}

					else
					{
						counterPlayer2 = 0;
					}

					counterRow++;
					counterColumn--;

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
 
			won = false;
			return won;
		}

        public bool TestTrueIsWonAndFalseIsNotWon() {
            return false;
        }

        private List<byte> checkEmptySpotInColumn() {
            List<byte> empySpots = new List<byte>();

            for (byte i = 0; i < columns; i++) {
                if (raster[rows - 1, i] == 0) {
                    empySpots.Add(i);
                }
            }
            return empySpots;
        }

        public void insertToken(int column, int player) {
            int row = 0;
            while (row < rows) {
                if (raster[row, column] == 0) {
                    raster[row, column] = player;
                    break;
                }
                row++;
            }
        }

        public bool hasNotCrashed() {
            return false;
        }

        public bool rasterIsFull() {
            for (int i = 0; i < columns; i++) {
                if (raster[rows - 1, i] == 0) {
                    return false;
                }
            }
            return true;
        }

        public void insertTokenByAI() {
            List<byte> emptySpots;
            Random rnd = new Random();
            emptySpots = checkEmptySpotInColumn();
            int length = emptySpots.Count;
            int spot = rnd.Next(0, length);

            //TODO : Hoe weet je dat player 2 AI is? of insertToken(item) gebruiken?
            insertToken(emptySpots[spot], 2);
        }
        
        public int getWonPlayer() {
            if (isWon()) { 
                //TODO : Speler is gewonnen
            }
            //TODO : Speler is niet gewonnen

            //TODO : Speler returnen die gewonnen is
            return 1;
        }

        public void clearRaster() {
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    raster[i, j] = 0;
                }
            }
        }
        #endregion
    }
}