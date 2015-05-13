using System;

namespace ConnectXLibrary
{
    class AI {
	    static int MAX_DEPTH = 8;
	    static float WIN_REVENUE = 1f;
	    static float LOSE_REVENUE = -1f;
	    static float UNCERTAIN_REVENUE = 0f;
	    ConnectX board;

	    public AI(ConnectX board) {
		    this.board = board;
	    }

	    public int makeTurn() {
		    double maxValue = 2.0 * Int32.MinValue;
		    int move = 0;

		    for (int column = 0; column < board.getColumns(); column++) {
			    if (board.isValidMove(column)) {
				    double value = moveValue(column);
				    if (value > maxValue) {
					    maxValue = value;
					    move = column;
					    if (value == WIN_REVENUE) {
						    break;
					    }
				    }
			    }
		    }
		    //board.makeMoveAI(move);
		    return move;
	    }

	    double moveValue(int column) {
		    board.makeMoveAI(column);
		    double val = alphabeta(MAX_DEPTH, Int32.MinValue, Int32.MaxValue, false);
		    board.undoMoveAI(column);
		    return val;
	    }

	    double alphabeta(int depth, double alpha, double beta, bool maximizingPlayer) {
		    bool hasWinner = board.hasWinner();
		    if (depth == 0 || hasWinner) {
			    double score = 0;
			    if (hasWinner) {
				    score = board.playerIsWinner() ? LOSE_REVENUE : WIN_REVENUE;
			    } else {
				    score = UNCERTAIN_REVENUE;
			    }
			    return score
			            / (MAX_DEPTH - depth + 1);
		    }

		    if (maximizingPlayer) {
			    for (int column = 0; column < board.getColumns(); column++) {
				    if (board.isValidMove(column)) {
					    board.makeMoveAI(column);
					    alpha = Math.Max(alpha, alphabeta(depth - 1, alpha, beta, false));
					    board.undoMoveAI(column);
					    if (beta <= alpha) {
						    break;
					    }
				    }
			    }
			    return alpha;
		    } else {
			    for (int column = 0; column < board.getColumns(); column++) {
				    if (board.isValidMove(column)) {
					    board.makeMovePlayer(column);
					    beta = Math.Min(beta, alphabeta(depth - 1, alpha, beta, true));
					    board.undoMovePlayer(column);
					    if (beta <= alpha) {
						    break;
					    }
				    }
			    }
			    return beta;
		    }
	    }
    }
}