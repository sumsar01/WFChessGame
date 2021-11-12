using System;

namespace WFChessGame.Engine.Models
{
    public class BooleanChecksBaseClass
    {
        public bool IsBlackPiece(int location, Board board)
        {
            int piece = board.GetSquare(location);
            int stringLength = Convert.ToString(piece, 2).Length;
            
            if (stringLength == 5)
            {
                return true;
            }

            return false;
        }

        public bool IsWhitePiece(int location, Board board)
        {
            int piece = board.GetSquare(location);
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
        public bool IsKing(int piece)
        {
            if (piece % 8 == 1) return true;
            return false;
        }

        /// <summary>
        /// Return true is it the owner of the peice's turn.
        /// </summary>
        /// <param name="piece"></param>
        /// <returns></returns>
        public bool CheckTurn(int piece, Board board)
        {
            int stringLength = Convert.ToString(piece, 2).Length;
            if (stringLength == board.playerTurn.Length)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if a piece is an enemy and returns true if it is the case.
        /// </summary>
        public bool CheckIfEnemy(int piecePos, int enemyPos, Board board)
        {
            int piece = board.GetSquare(piecePos);
            int enemyPiece = board.GetSquare(enemyPos);

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
        public bool IsBlocked(int destination, Board board)
        {

            int destinationSquare = board.GetSquare(destination);
            if (destinationSquare != 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if a square is occupied by a friendly piece, and returns true if it is the case.
        /// </summary>
        public bool CheckIfOccupied(int piecePos, int destination, Board board)
        {

            int destinationSquare = board.GetSquare(destination);
            if (destinationSquare != 0)
            {
                if (CheckIfEnemy(piecePos, destination, board) == false)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CheckOutOfBound(int X, int Y)
        {
            if (X >= 8 || Y >= 8) return true;
            if (X < 0 || Y < 0) return true;

            return false;
        }
    }
}
