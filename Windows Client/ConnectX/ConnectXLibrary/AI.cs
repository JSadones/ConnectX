﻿using System;

namespace ConnectXLibrary
{
    class AI
    {
        #region State
	    static int MaxDepth = 8; //The AI does think MAX_DEPTH moves ahead.

	    static float WinRevenue = 1f; //The score given to a state that leads to a win.

	    static float LoseRevenue = -1f; //The score given to a state that leads to a lose.

	    static float UncertainRevenue = 0f; //The score given to a state that leads to a loss in the next turn

	    ConnectX board;
        #endregion

        #region Constructor
	    public AI(ConnectX board) {
		    this.board = board;
	    }
        #endregion

        #region Methods
	    /**
	    * Makes a turn.
	    * 
	    * @return The column where the turn was made.
	    *         Please note that the turn was
	    *         already made and doesn't have to be
	    *         done again.
	    */
	    public int makeTurn()
        {
            double maxValue = 2.0 * Int32.MinValue;
		    int move = 0;

		    // Search all columns for the one that has
		    // the best value
		    // The best score possible is WIN_REVENUE.
		    // So if we find a move that has this
		    // score, the search can be stopped.

		    for (int column = 0; column < board.getColumns(); column++)
            {
			    if (!board.isColumnFull(column))
                {
				    // Compare the score of this
				    // particular move with the
				    // previous max
				    double value = moveValue(column);
				    if (value > maxValue)
                    {
					    maxValue = value;
					    move = column;
					    if (value == WinRevenue) break;
				    }
			    }
		    }
		    // Make the move
		    board.makeMoveAI(move);
		    return move;
	    }//makeTurn

	    double moveValue(int column)
        {
		    // To determine the value of a move, first
		    // make the move, estimate that state and
		    // then undo the move again.
		    board.makeMoveAI(column);
		    double val = alphabeta(MaxDepth, Int32.MinValue, Int32.MaxValue, false);
		    board.undoMoveAI(column);
		    return val;
	    }//moveValue

        double alphabeta(int depth, double alpha, double beta, bool maximizingPlayer)
            {
		    bool hasWinner = board.hasWinner();
		    // All these conditions lead to a
		    // termination of the recursion
		    if (depth == 0 || hasWinner)
            {
			    double score = 0;
			    if (hasWinner) score = board.playerIsWinner() ? LoseRevenue : WinRevenue;
                else score = UncertainRevenue;

			    // Note that depth in this
			    // implementation starts at a high
			    // value and is decreased in every
			    // recursive call. This means that the
			    // deeper the recursion is, the
			    // greater MAX_DEPTH - depth will
			    // become and thus the smaller the
			    // result will become.
			    // This is done as a tweak, simply
			    // spoken, something bad happening in
			    // the next turn is worse than it
			    // happening in let's say five steps.
			    // Analogously something good
			    // happening in the next turn is
			    // better than it happening in five
			    // steps.
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