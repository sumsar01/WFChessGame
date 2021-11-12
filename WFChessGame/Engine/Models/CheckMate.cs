using WFChessGame.Engine.viewModels;
using System.Collections.Generic;
using System;


namespace WFChessGame.Engine.Models
{
    /// <summary>
    /// Checks for mate and checkmate
    /// </summary>
    public static class CheckMate
    {
        public static bool Mate(Board board)
        {
            List<int> allEnemyMoves = new List<int>();
            int piece;

            allEnemyMoves = GenerateAllEnemyMoves(board);

            foreach (int move in allEnemyMoves)
            {
                piece = board.GetSquare(move);

                if(BooleanChecks.CheckTurn(piece, board) && BooleanChecks.IsKing(piece))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool FutureMate(Board board)
        {
            List<int> allEnemyMoves = new List<int>();
            int piece;

            allEnemyMoves = GenerateAllEnemyMoves(board);

            foreach (int move in allEnemyMoves)
            {
                piece = FutureBoard.GetSquare(move);

                if (BooleanChecks.CheckTurn(piece, board) && BooleanChecks.IsKing(piece))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Get location of all enemy pieces.
        /// </summary>
        public static List<int> GenerateEnemyPositions(List<int> movesToGet, Board board)
        {
            if (board.playerTurn == "1000")
            {
                for (int location = 0; location < 64; ++location)
                {
                    if (BooleanChecks.IsBlackPiece(location, board))
                    {
                        movesToGet.Add(location);
                    }
                }
            }
            // If black players turn. Get location of white pieces
            if (board.playerTurn == "10000")
            {
                for (int location = 0; location < 64; ++location)
                {
                    if (BooleanChecks.IsWhitePiece(location, board))
                    {
                        movesToGet.Add(location);
                    }
                }
            }

            return movesToGet;
        }

        /// <summary>
        /// Return all possible moves made by the enemy.
        /// </summary>
        public static List<int> GenerateAllEnemyMoves(Board board)
        {
            List<int> enemyMoves = new List<int>();
            List<int> movesToGet = new List<int>();
            List<int> moves = new List<int>();
            int piece;

            movesToGet = GenerateEnemyPositions(movesToGet, board);

            foreach(int location in movesToGet)
            {
                piece = board.GetSquare(location);
                moves = Moves.GetEnemyMoves(piece, location, board);

                foreach(int move in moves)
                {
                    enemyMoves.Add(move);
                }
            }

            return enemyMoves;
        }
    }
}
