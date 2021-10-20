using System;
using WFChessGame.Engine.viewModels;
using System.Collections.Generic;

namespace WFChessGame.Engine.Models
{
    public static class Turn
    {

        public static void MakeMove(int newLoaction, int oldLocation)
        {
            int piece = Board.GetSquare(oldLocation);
            List<int> moves = GetLegalMoves(piece, oldLocation);

            if (moves.Contains(newLoaction))
            {
                Board.SetSquare(newLoaction, piece);
                Board.SetSquare(oldLocation, 0);
                GameSession.ChangeTurn();
            }
        }


        public static List<int> GetLegalMoves(int piece, int location)
        {
            List<int> moves = new List<int>();

            bool _isTurn = CheckTurn(piece);
            if (_isTurn == true)
            {
                moves = GetMoves(piece, location, moves);
                moves = RemoveOutOfBound(moves);
                moves = CheckIfOccupied(moves, piece, location);
            }

            return moves;
        }

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
            
            if(pieceColor != enemyColor)
            {
                return true;
            }
            return false;
        }

        // Prune any move that would take the piece of the grid.
        public static List<int> RemoveOutOfBound(List<int> moves)
        {
            foreach(int move in moves)
            {
                if(move < 0 & 63 < move)
                {
                    moves.Remove(move);
                }
            }

            return moves;
        }

        public static List<int> CheckIfOccupied(List<int> moves, int piece, int location)
        {
            List<int> occupiedMoves = new List<int>();
            foreach(int move in moves)
            {
                int destinationSquare = Board.GetSquare(move);
                if(destinationSquare != 0)
                {
                    if(CheckIfEnemy(location, move) != true)
                    {
                        occupiedMoves.Add(move);
                    }
                }
            }

            foreach(int move in occupiedMoves)
            {
                moves.Remove(move);
            }

            return moves;
        }

        // Need moves from other pieces as well
        // Should probably refactor
        public static List<int> GetMoves(int piece, int location, List<int> moves)
        {
            int type = piece % 8;
            int[] input;
            switch (type)
            {
                case 2:
                    int _isWhitePlayersTurn = 4;

                    if(_isWhitePlayersTurn == GameSession.playerTurn.Length)
                    {
                        // Chicking if white pawn has moved yet
                        // If pawn has not moved allow two forward moves
                        if(48 <= location & location <= 55)
                        {
                            input = new int[] { location - 8, location - 16 };
                            moves.AddRange(input);
                        }
                        else
                        {
                            input = new int[] { location - 8};
                            moves.AddRange(input);
                        }

                        // If enemy in range allow attack move
                        bool enemyRight = CheckIfEnemy(location, location-7);
                        bool enemyLeft = CheckIfEnemy(location, location - 9);

                        if (enemyRight == true) moves.Add(location - 7);
                        if (enemyLeft == true) moves.Add(location - 9);

                        return moves;
                    }
                    else
                    {
                        // Chicking if black pawn has moved yet
                        // If pawn has not moved allow two forward moves
                        if (8 <= location & location <= 15)
                        {
                            input = new int[] { location + 8, location + 16 };
                            moves.AddRange(input);
                        }
                        else
                        {
                            input = new int[] { location + 8 };
                            moves.AddRange(input);
                        }

                        // If enemy in range allow attack move
                        bool enemyRight = CheckIfEnemy(location, location + 7);
                        bool enemyLeft = CheckIfEnemy(location, location + 9);

                        if (enemyRight == true) moves.Add(location + 7);
                        if (enemyLeft == true) moves.Add(location + 9);

                        return moves;
                    }
                default:
                    return moves;
            }
        }

    }
}
