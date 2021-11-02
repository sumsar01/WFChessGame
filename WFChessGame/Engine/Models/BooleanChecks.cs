using System;
using WFChessGame.Engine.viewModels;
using System.Collections.Generic;

namespace WFChessGame.Engine.Models
{
    public static class BooleanChecks
    {

        public static bool CheckTurn(int piece)
        {
            int stringLength = Convert.ToString(piece, 2).Length;
            if (stringLength == GameSession.playerTurn.Length)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if a piece is an enemy and returns true if it is the case.
        /// </summary>
        public static bool CheckIfEnemy(int piecePos, int enemyPos)
        {
            int piece = Board.GetSquare(piecePos);
            int enemyPiece = Board.GetSquare(enemyPos);

            // Return false if no piece occupy square.
            if (enemyPiece == 0) return false;

            int pieceColor = Convert.ToString(piece, 2).Length;
            int enemyColor = Convert.ToString(enemyPiece, 2).Length;

            if (pieceColor != enemyColor)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if a square is occupied by a friendly piece, and returns true if it is the case.
        /// </summary>
        static int destinationSquare;
        public static bool CheckIfOccupied(int move, int piece, int location)
        {

            destinationSquare = Board.GetSquare(move);
            if (destinationSquare != 0)
            {
                if (CheckIfEnemy(location, move) == false)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool CheckOutOfBound(int X, int Y)
        {
            if (X >= 8 || Y >= 8) return true;
            if (X < 0 || Y < 0) return true;

            return false;
        }
    }
}
