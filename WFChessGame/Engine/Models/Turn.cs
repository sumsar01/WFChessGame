using System;
using WFChessGame.Engine.viewModels;
using System.Collections.Generic;

namespace WFChessGame.Engine.Models
{
    public static class Turn
    {

        ///<summary>
        /// Moves a piece and change turn.
        ///</summary>
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

        ///<summary>
        /// Get all moves and prune the ones not allowed.
        ///</summary>
        public static List<int> GetLegalMoves(int piece, int location)
        {
            List<int> moves = new List<int>();

            bool _isTurn = BooleanChecks.CheckTurn(piece);
            if (_isTurn == true)
            {
                moves = GetMoves(piece, location, moves);
                moves = RemoveOutOfBound(moves);
                moves = BooleanChecks.CheckIfOccupied(moves, piece, location);
            }

            return moves;
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

        ///<summary>
        /// Generate the legal moves of a piece on a given position.
        ///</summary>
        ///<returns>
        /// All possible moves for the piece.
        /// </returns>
        public static List<int> GetMoves(int piece, int location, List<int> moves)
        {
            int type = piece % 8;
            if(BooleanChecks.CheckTurn(piece) == false) return moves;
          

            switch (type)
            {
                case 1:
                    return MovementRules.King(location, moves);

                case 2:
                    if(GameSession.playerTurn == "1000")
                    {
                        return MovementRules.WhitePawn(location, moves);
                    }
                    if (GameSession.playerTurn == "10000")
                    {
                        return MovementRules.BlackPawn(location, moves);
                    }
                    return moves;

                case 3:
                    return MovementRules.Knight(location, moves);

                case 4:
                    return MovementRules.Bishop(location, moves);

                case 5:
                    return MovementRules.Rook(location, moves);

                case 6:
                    return MovementRules.Queen(location, moves);

                default:
                    return moves;
            }
        }

    }
}
