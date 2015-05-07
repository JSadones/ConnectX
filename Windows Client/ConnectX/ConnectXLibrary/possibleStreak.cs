namespace ConnectXLibrary
{
    public class possibleStreak
    {
        #region state
        int player, streak, row, column;
        #endregion

        #region Constructor
        public possibleStreak(int player, int streak, int row, int column)
        {
            this.player = player;
            this.streak = streak;
            this.row = row;
            this.column = column;
        }
        #endregion

        #region Properties
        public int getPlayer() {
            return player;
        }

        public int getStreak()
        {
            return streak;
        }

        public int getRow() {
            return row;
        }

        public int getColumn() {
            return column;
        }
        #endregion
    }
}