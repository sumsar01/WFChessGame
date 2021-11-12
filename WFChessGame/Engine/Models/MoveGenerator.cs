using System.Collections.Generic;

namespace WFChessGame.Engine.Models
{
    public class MoveGenerator : BooleanChecksBaseClass
    {
        private int piece;
        private List<int> moves;
        private bool _isTurn;
        private int pieceType;

        private MovementRules movementRules;

        public MoveGenerator()
        {
            movementRules = new MovementRules();
        }

        ///<summary>
        /// Generate the legal moves of a piece on a given position.
        ///</summary>
        ///<returns>
        /// All possible moves for the piece.
        /// </returns>
        public List<int> GetPseudoLegalMoves(int piece, int location, Board board)
        {
            moves = new List<int>();
            _isTurn = CheckTurn(piece, board);
            pieceType = piece % 8;

            if (_isTurn == true)
            {
                switch (pieceType)
                {
                    case 1:
                        return movementRules.King(location, moves, board);

                    case 2:
                        return movementRules.Pawn(location, moves, board);

                    case 3:
                        return movementRules.Knight(location, moves, board);

                    case 4:
                        return movementRules.Bishop(location, moves, board);

                    case 5:
                        return movementRules.Rook(location, moves, board);

                    case 6:
                        return movementRules.Queen(location, moves, board);

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
        public List<int> GetEnemyMoves(int piece, int location, Board board)
        {
            moves = new List<int>();
            _isTurn = CheckTurn(piece, board);
            pieceType = piece % 8;

            if (_isTurn == false)
            {
                switch (pieceType)
                {
                    case 1:
                        return movementRules.King(location, moves, board);

                    case 2:
                        return movementRules.Pawn(location, moves, board);

                    case 3:
                        return movementRules.Knight(location, moves, board);

                    case 4:
                        return movementRules.Bishop(location, moves, board);

                    case 5:
                        return movementRules.Rook(location, moves, board);

                    case 6:
                        return movementRules.Queen(location, moves, board);

                    default:
                        return moves;
                }
            }

            return moves;
        }

    }
}
