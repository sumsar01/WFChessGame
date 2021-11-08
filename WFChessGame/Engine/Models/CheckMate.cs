using WFChessGame.Engine.viewModels;
using System.Collections.Generic;


namespace WFChessGame.Engine.Models
{
    /// <summary>
    /// Checks for mate and checkmate
    /// </summary>
    public static class CheckMate
    {
        public static bool Mate()
        {
            return false;
        }

        /// <summary>
        /// Get location of all enemy pieces.
        /// </summary>
        /// <param name="movesToGet"></param>
        /// <returns></returns>
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
            else
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

            movesToGet = GenerateEnemyPositions(movesToGet);

            return enemyMoves;
        }
    }
}
