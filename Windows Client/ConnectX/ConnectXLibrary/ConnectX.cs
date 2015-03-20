using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConnectXLibrary
{
    public class ConnectX
    {
        #region State
        private int[,] raster;
        private int rows;
        private int columns;
        private int tokenStreak;
		private int playerAtTurn;
        private int winningPlayer;
        #endregion State

        #region Constructor
        public ConnectX(): this(6, 7, 4) {
        }

        public ConnectX(int rows, int columns): this (rows, columns, 4) {
        }

        public ConnectX(int rows, int columns, int tokenStreak) {
            this.rows = rows;
            this.columns = columns;
            this.tokenStreak = tokenStreak;
            playerAtTurn = 1;

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

        public int[,] getRaster() {
            return raster;
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
         if (isWonVertical() || isWonDiagonal45() || isWonDiagonal135() || isWonHorizontal()) 
            {
    
                return true;
            }
            return false;
        }

        public bool isWonVertical() {
            int counterPlayer1 = 0;
            int counterPlayer2 = 0;

            for (int i = 0; i < columns; i++) {

                int j = 0;
                counterPlayer1 = 0;
                counterPlayer2 = 0;

                while (j < rows && raster[j,i] != 0) {

                   
                    if (raster[j, i] == 1) {
                        counterPlayer1++;
                    } else counterPlayer1 = 0;
                    
                    if (raster[j, i] == 2) {
                        counterPlayer2++;
                    } else counterPlayer2 = 0;

                    if (counterPlayer1 == tokenStreak) {
                        winningPlayer = 1;
                        return true;
                    }

                    if (counterPlayer2 == tokenStreak) {
                        winningPlayer = 2;
                        return true;
                    }

                    j++;
                }
            }
            return false;
        }

		public bool isWonHorizontal() {
			int counterPlayer1 = 0;
			int counterPlayer2 = 0;

			for (int i = 0; i < rows; i++) {
				for (int j = 0; j < columns; j++) {

					if (raster[i, j] == 1) {
						counterPlayer1++;
					} else counterPlayer1 = 0;

					if (raster[i, j] == 2) {
						counterPlayer2++;
					} else counterPlayer2 = 0;

					if (counterPlayer1 == tokenStreak) {
                        winningPlayer = 1;
						return true;
					}

					if (counterPlayer2 == tokenStreak) {
                        winningPlayer = 2;
						return true;
					}
				}
			}
			return false;
		}

        public bool isWonDiagonal45() {
			// De tellers voor de streaks te zoeken, voor elk van de spelers afzonderlijk
			int counterPlayer1 = 0;
			int counterPlayer2 = 0;
			int counterRow;
			int counterColumn;

			// 45°: De kolommen worden afgelopen van rechts naar links
			for (int i = columns - 1; i >= 0; i--) {
				counterRow = 0;
				counterColumn = i;
				while (counterColumn < columns && counterRow < rows) {
                    if (raster[counterRow, counterColumn] == 1) {
						counterPlayer1++;
					} else counterPlayer1 = 0;

                    if (raster[counterRow, counterColumn] == 2) {
						counterPlayer2++;
					} else counterPlayer2 = 0;

					counterRow++;
					counterColumn++;

					if (counterPlayer1 == tokenStreak) {
                        winningPlayer = 1;
						return true;
						// TODO: Score speler 1 verhogen
					}

					// Indien speler 2 de streak behaald heeft, is het spel gewonnen
					if (counterPlayer2 == tokenStreak) {
                        winningPlayer = 2;
						return true;
						// TODO: Score speler 2 verhogen
					}
				}
			}


			// 45°: De rijen worden afgelopen vanaf de tweede rij, eerste kolom naar boven
			for (int i = 1; i < rows; i++) {
				counterRow = i;
				counterColumn = 0;

				while (counterColumn < columns && counterRow < rows) {
					if (raster[counterRow, counterColumn] == 1) {
						counterPlayer1++;
					} else counterPlayer1 = 0;

					if (raster[counterRow, counterColumn] == 2) {
						counterPlayer2++;
					} else counterPlayer2 = 0;

					counterRow++;
					counterColumn++;

					if (counterPlayer1 == tokenStreak) {
						return true;
						// TODO: Score speler 1 verhogen
					}

					// Indien speler 2 de streak behaald heeft, is het spel gewonnen
					if (counterPlayer2 == tokenStreak) {
						return true;
						// TODO: Score speler 2 verhogen
					}
				}
			}
			// Indien we hier belanden, is het spel niet gewonnen.
			return false;
        }

		public bool isWonDiagonal135() {
			// De tellers voor de streaks te zoeken, voor elk van de spelers afzonderlijk
			int counterPlayer1 = 0;
			int counterPlayer2 = 0;
			int counterRow;
			int counterColumn;

			// 135°: De kolommen worden afgelopen van links naar rechts
			for (int i = 0; i < columns; i++) {
				counterRow = 0;
				counterColumn = i;
				while (counterColumn > 0 && counterRow < rows) {
					// Als er een token van player1 gevonden wordt, teller van player2 vermeerderen met 1
					if (raster[counterRow, counterColumn] == 1) {
						counterPlayer1++;
					} else counterPlayer1 = 0;

					// Als er een token van player2 gevonden wordt, teller van player2 vermeerderen met 1
					if (raster[counterRow, counterColumn] == 2) {
						counterPlayer2++;
					} else counterPlayer2 = 0;

					counterRow++;
					counterColumn--;

					// Indien speler 1 de streak behaald heeft, is het spel gewonnen
					if (counterPlayer1 == tokenStreak) {
                        winningPlayer = 1;
						return true;
						// TODO: Score speler 1 verhogen
					}

					// Indien speler 2 de streak behaald heeft, is het spel gewonnen
					if (counterPlayer2 == tokenStreak) {
                        winningPlayer = 2;
                        return true;
						// TODO: Score speler 2 verhogen
					}
				}
			}

			// 135°: De rijen worden afgelopen vanaf de tweede rij, laatste kolom naar boven
			for (int i = 1; i < rows; i++) {
				counterRow = i;
				counterColumn = columns - 1;

				while (counterColumn < columns && counterRow < rows) {
					if (raster[counterRow, counterColumn] == 1) {
						counterPlayer1++;
					} else counterPlayer1 = 0;

					if (raster[counterRow, counterColumn] == 2) {
						counterPlayer2++;
					} else counterPlayer2 = 0;

					counterRow++;
					counterColumn--;

					if (counterPlayer1 == tokenStreak) {
                        winningPlayer = 1;
                        return true;
						// TODO: Score speler 1 verhogen
					}

					// Indien speler 2 de streak behaald heeft, is het spel gewonnen
					if (counterPlayer2 == tokenStreak) {
                        winningPlayer = 2;
                        return true;
						// TODO: Score speler 2 verhogen
					}
				}
			}
 
			return false;
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

        public bool insertToken(int column, int player) {
			if (1 <= player && player <= 2) {
				int row = 0;
				while (row < rows) {
					if (raster[row, column] == 0) {
						raster[row, column] = player;
						break;
					}
					row++;
				}

				if (player == 1) {
					playerAtTurn = 2;
				}
				else playerAtTurn = 1;
				return true;
			}
			else return false;
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
            return winningPlayer;
        }

        public void clearRaster() {
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < columns; j++) {
                    raster[i, j] = 0;
                }
            }
        }

		public int getPlayerAtTurn() {
			return playerAtTurn;
		}

        public bool isColumnFull(int column)
        {
            if (raster[rows - 1, column] != 0)
            {
                return true;
            }
            else { return false; }
        }

		public int getToken(int row, int column) {
			return raster[row, column];
		}

        #endregion


    }

}