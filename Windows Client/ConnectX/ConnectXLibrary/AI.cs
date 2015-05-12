using System;

namespace ConnectXLibrary
{
    class AI
    {
        #region State
	    static int MaxDepth = 8;
	    static float WinRevenue = 1f;
	    static float LoseRevenue = -1f;
	    static float UncertainRevenue = 0f;

	    ConnectX board;
        #endregion

        #region Constructor
	    public AI(ConnectX board) {
		    this.board = board;
	    }
        #endregion

        #region Methods
	    public int makeTurn()
        {
            double maxValue = 2.0 * Int32.MinValue;
		    int move = 0;

		    for (int column = 0; column < board.getColumns(); column++)
            {
			    if (!board.isColumnFull(column))
                {
				    double value = moveValue(column);
				    if (value > maxValue)
                    {
					    maxValue = value;
					    move = column;
					    if (value == WinRevenue) break;
				    }
			    }
		    }
		    board.makeMoveAI(move);
		    return move;
	    }//makeTurn

        private double moveValue(int column)
        {
		    board.makeMoveAI(column);
		    double val = alphabeta(MaxDepth, Int32.MinValue, Int32.MaxValue, false);
		    board.undoMoveAI(column);
		    return val;
	    }//moveValue

        private double alphabeta(int depth, double alpha, double beta, bool maximizingPlayer)
        {
		    bool hasWinner = board.hasWinner();
		    if (depth == 0 || hasWinner)
            {
			    double score = 0;

			    if (hasWinner) score = board.playerIsWinner() ? LoseRevenue : WinRevenue;
                else score = UncertainRevenue;

			    return score / (MaxDepth - depth + 1);
		    }

		    if (maximizingPlayer)
            {
			    for (int column = 0; column < board.getColumns(); column++)
                {
				    if (!board.isColumnFull(column))
                    {
					    board.makeMoveAI(column);
					    alpha = Math.Max(alpha, alphabeta(depth - 1, alpha, beta, false));
					    board.undoMoveAI(column);
					    if (beta <= alpha) break;
				    }
			    }
			    return alpha;
		    }
            else
            {
			    for (int column = 0; column < board.getColumns(); column++)
                {
                    if (!board.isColumnFull(column))
                    {
					    board.makeMovePlayer(column);
					    beta = Math.Min(beta, alphabeta(depth - 1, alpha, beta, true));
					    board.undoMovePlayer(column);
					    if (beta <= alpha) break;
				    }
			    }
			    return beta;
		    }
        }//alphabeta
        #endregion
    }
}