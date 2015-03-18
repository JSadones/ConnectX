namespace Connect4_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 7;
            int length = 7;
            //int tokenStreak = 4;
            int[,] board;

            board = new int[length, width];

            Algorithm game = new Algorithm();

            bool test = game.haswon(board);
            #region tokenInsteken

            #endregion
        }
    }
}