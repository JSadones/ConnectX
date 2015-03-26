using System;

namespace Connect4_Algorithm
{
    class Algorithm
    {
        public bool haswon(int[,] board)
        {
            Int64 y = board & (board >> 7);
            if (y & (y >> 2 * 7)) // check \ diagonal
                return true;
            y = board & (board >> 8);
            if (y & (y >> 2 * 8)) // check horizontal -
                return true;
            y = board & (board >> 9);
            if (y & (y >> 2 * 9)) // check / diagonal
                return true;
            y = board & (board >> 1);
            if (y & (y >> 2))     // check vertical |
                return true;
            return false;
        }
    }
}