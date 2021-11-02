using System;
using WFChessGame.Engine.viewModels;
using System.Collections.Generic;

namespace WFChessGame.Engine.Models
{
    public static class Turn
    {
        static List<int> moves;

        ///<summary>
        /// Moves a piece and change turn.
        ///</summary>
        public static void MakeMove(int newLoaction, int oldLocation)
        {
            int piece = Board.GetSquare(oldLocation);
            moves = new List<int>();

            bool _isTurn = BooleanChecks.CheckTurn(piece);
            if (_isTurn == true)
            {
                moves = GetMoves(piece, oldLocation, moves);
            }

            if (moves.Contains(newLoaction))
            {
                Board.SetSquare(newLoaction, piece);
                Board.SetSquare(oldLocation, 0);
                GameSession.ChangeTurn();
            }
        }

        ///<summary>
        /// Generate the legal moves of a piece on a given position.
        ///</summary>
        ///<returns>
        /// All possible moves for the piece.
        /// </returns>
        public static List<int> GetMoves(int piece, int location, List<int> moves)
        {
            int pieceType = piece % 8;

            switch (pieceType)
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
