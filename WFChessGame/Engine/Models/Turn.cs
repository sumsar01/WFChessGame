using System;
using WFChessGame.Engine.viewModels;
using System.Collections.Generic;

namespace WFChessGame.Engine.Models
{
    public static class Turn
    {

        public static void MakeMove(int newLoaction, int oldLocation)
        {
            ///<summary>
            /// Moves a piece and change turn
            ///</summary>
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

        // Need moves from other pieces as well
        // Should probably refactor
        public static List<int> GetMoves(int piece, int location, List<int> moves)
        {
            int type = piece % 8;
            if(BooleanChecks.CheckTurn(piece) == false) return moves;
          

            switch (type)
            {
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

                default:
                    return moves;
            }
        }

    }
}
