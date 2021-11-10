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
        public static bool Mate()
        {
            List<int> allEnemyMoves = new List<int>();
            int piece;

            allEnemyMoves = GenerateAllEnemyMoves();

            foreach (int move in allEnemyMoves)
            {
                piece = Board.GetSquare(move);

                if(BooleanChecks.CheckTurn(piece) && BooleanChecks.IsKing(piece))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool FutureMate()
        {
            List<int> allEnemyMoves = new List<int>();
            int piece;

            allEnemyMoves = GenerateAllEnemyMoves();

            foreach (int move in allEnemyMoves)
            {
                piece = FutureBoard.GetSquare(move);

                if (BooleanChecks.CheckTurn(piece) && BooleanChecks.IsKing(piece))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Get location of all enemy pieces.
        /// </summary>
        public static List<int> GenerateEnemyPositions(List<int> movesToGet)
        {
            if (GameSession.playerTurn == "1000")
            {
                for (int location = 0; location < 64; ++location)
                {
                    if (BooleanChecks.IsBlackPiece(location))
                    {
                        movesToGet.Add(location);
                    }
                }
            }
            // If black players turn. Get location of white pieces
            if (GameSession.playerTurn == "10000")
            {
                for (int location = 0; location < 64; ++location)
                {
                    if (BooleanChecks.IsWhitePiece(location))
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
        public static List<int> GenerateAllEnemyMoves()
        {
            List<int> enemyMoves = new List<int>();
            List<int> movesToGet = new List<int>();
            List<int> moves = new List<int>();
            int piece;

            movesToGet = GenerateEnemyPositions(movesToGet);

            foreach(int location in movesToGet)
            {
                piece = Board.GetSquare(location);
                moves = Moves.GetEnemyMoves(piece, location);

                foreach(int move in moves)
                {
                    enemyMoves.Add(move);
                }
            }

            return enemyMoves;
        }
    }
}
