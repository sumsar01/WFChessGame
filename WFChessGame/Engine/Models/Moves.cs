using System;
using WFChessGame.Engine.viewModels;
using System.Collections.Generic;

namespace WFChessGame.Engine.Models
{
    public static class Moves
    {
        static int piece;
        static List<int> moves;
        static bool _isTurn;
        static int pieceType;

        ///<summary>
        /// Moves a piece and change turn.
        ///</summary>
        public static void MakeMove(int newLoaction, int oldLocation, Board board)
        {
            piece = board.GetSquare(oldLocation);
            moves = GetLegalMoves(piece, oldLocation);

            if (moves.Contains(newLoaction))
            {
                board.SetSquare(newLoaction, piece);
                board.SetSquare(oldLocation, 0);
                GameSession.ChangeTurn();
            }
        }


        public static List<int> GetLegalMoves(int piece, int location)
        {
            List<int> LegalMoves = new List<int>();
            List<int> moves = GetPseudoLegalMoves(piece, location);

            foreach (int move in moves)
            {
                Board.CopyBoard(FutureBoard.futureSquare);
                FutureBoard.SetSquare(move, piece);
                FutureBoard.SetSquare(location, 0);

                if (CheckMate.FutureMate() != true)
                {
                    LegalMoves.Add(move);
                }
            }

            return LegalMoves;
        }


        ///<summary>
        /// Generate the legal moves of a piece on a given position.
        ///</summary>
        ///<returns>
        /// All possible moves for the piece.
        /// </returns>
        public static List<int> GetPseudoLegalMoves(int piece, int location)
        {
            moves = new List<int>();
            _isTurn = BooleanChecks.CheckTurn(piece);
            pieceType = piece % 8;

            if (_isTurn == true)
            {
                switch (pieceType)
                {
                    case 1:
                        return MovementRules.King(location, moves);

                    case 2:
                        return MovementRules.Pawn(location, moves);

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

            return moves;
        }


        ///<summary>
        /// Generate the legal moves of an enemy piece on a given position.
        ///</summary>
        ///<returns>
        /// All possible moves for the piece.
        /// </returns>
        public static List<int> GetEnemyMoves(int piece, int location)
        {
            moves = new List<int>();
            _isTurn = BooleanChecks.CheckTurn(piece);
            pieceType = piece % 8;

            if (_isTurn == false)
            {
                switch (pieceType)
                {
                    case 1:
                        return MovementRules.King(location, moves);

                    case 2:
                        return MovementRules.Pawn(location, moves);

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

            return moves;
        }

    }
}
