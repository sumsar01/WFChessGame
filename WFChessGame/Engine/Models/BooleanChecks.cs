using System;
using WFChessGame.Engine.viewModels;
using System.Collections.Generic;

namespace WFChessGame.Engine.Models
{
    public static class BooleanChecks
    {
        public static bool IsBlackPiece(int location)
        {
            int piece = Board.GetSquare(location);
            int stringLength = Convert.ToString(piece, 2).Length;
            
            if (stringLength == 5)
            {
                return true;
            }

            return false;
        }

        public static bool IsWhitePiece(int location)
        {
            int piece = Board.GetSquare(location);
            int stringLength = Convert.ToString(piece, 2).Length;
            
            if (stringLength == 4)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Return true if the piece is a king.
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        public static bool IsKing(int piece)
        {
            if (piece % 8 == 1) return true;
            return false;
        }

        /// <summary>
        /// Return true is it the owner of the peice's turn.
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
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
        /// Check if square is blocked by enemy. Used by pawns
        /// </summary>
        public static bool IsBlocked(int destination)
        {

            int destinationSquare = Board.GetSquare(destination);
            if (destinationSquare != 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if a square is occupied by a friendly piece, and returns true if it is the case.
        /// </summary>
        public static bool CheckIfOccupied(int piecePos, int destination)
        {

            int destinationSquare = Board.GetSquare(destination);
            if (destinationSquare != 0)
            {
                if (CheckIfEnemy(piecePos, destination) == false)
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
