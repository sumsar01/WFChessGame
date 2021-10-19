using System;
using WFChessGame.Engine.viewModels;
using System.Collections.Generic;

namespace WFChessGame.Engine.Models
{
    public class Move
    {


        public int LegalMoves(int piece, int location)
        {
            List<int> moves = new List<int>();

            bool _isTurn = CheckTurn(piece);
            if (_isTurn == true)
            {
                int type = piece % 8;
                moves = GetMoves(type, location, moves);
            }


            return -1;
        }

        private bool CheckTurn(int piece)
        {
            int stringLength = Convert.ToString(piece, 2).Length;
            if (stringLength == GameSession.playerTurn.Length)
            {
                return true;
            }

            return false;
        }

        private bool CheckIfEnemy(int piecePos, int enemyPos)
        {
            int pieceColor = Convert.ToString(piecePos, 2).Length;
            int enemyColor = Convert.ToString(enemyPos, 2).Length;
            
            if(pieceColor != enemyColor)
            {
                return true;
            }
            return false;
        }


        // Need moves from other pieces as well
        private List<int> GetMoves(int type, int location, List<int> moves)
        {
            switch (type)
            {
                case 1:
                    int[] input = { location - 9, location - 8, location - 7, location - 1, location + 1, location + 7, location + 8, location + 9 };
                    moves.AddRange(input);
                    return moves;
                case 2:
                    int _isWhitePlayersTurn = 4;

                    if(_isWhitePlayersTurn == GameSession.playerTurn.Length)
                    {
                        // Chicking if white pawn has moved yet
                        // If pawn has not moved allow two forward moves
                        if(8 <= location & location <= 15)
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
                        if (47 <= location & location <= 55)
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
                    break;
                default:
                    return moves;
            }

            return moves;
        }

    }
}
