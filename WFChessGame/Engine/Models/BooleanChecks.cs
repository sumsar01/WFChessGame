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

        public static List<int> CheckIfOccupied(List<int> moves, int piece, int location)
        {
            List<int> occupiedMoves = new List<int>();
            foreach (int move in moves)
            {
                int destinationSquare = Board.GetSquare(move);
                if (destinationSquare != 0)
                {
                    if (CheckIfEnemy(location, move) != true)
                    {
                        occupiedMoves.Add(move);
                    }
                }
            }

            foreach (int move in occupiedMoves)
            {
                moves.Remove(move);
            }

            return moves;
        }

        public static bool CheckOutOfBound(int X, int Y)
        {
            if (X >= 8 || Y >= 8) return true;
            if (X < 0 || Y < 0) return true;

            return false;
        }
    }
}
