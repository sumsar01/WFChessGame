using WFChessGame.Engine.Models;
using System.Collections.Generic;

namespace WFChessGame.Engine.viewModels
{

    /// <summary>
    /// Perform the action taken in a turn.
    /// </summary>
    public class Turn
    {

        private int piece;
        private List<int> moves;
        private Board futureBoard;
        private CheckMate checkMate;
        public MoveGenerator moveGenerator;
        private List<int> LegalMoves;
        private bool whiteIsMate;
        private bool blackIsMate;

        public Turn()
        {
            futureBoard = new Board();
            checkMate = new CheckMate();
            moveGenerator = new MoveGenerator();
        }

        ///<summary>
        /// Moves a piece and change turn.
        ///</summary>
        public void MakeMove(int newLoaction, int oldLocation, Board board)
        {
            piece = board.GetSquare(oldLocation);
            moves = GetLegalMoves(piece, oldLocation, board);

            if (moves.Contains(newLoaction))
            {
                board.SetSquare(newLoaction, piece);
                board.SetSquare(oldLocation, 0);
                ChangeTurn(board);
            }
        }

        /// <summary>
        /// Get all allowed moves for a given piece. This includes only moves that will not put you in mate.
        /// </summary>
        public List<int> GetLegalMoves(int piece, int location, Board board)
        {
            LegalMoves = new List<int>();
            moves = moveGenerator.GetPseudoLegalMoves(piece, location, board);
            futureBoard = new Board();


            // Checks if each move is legal.
            foreach (int move in moves)
            {
                futureBoard.CopyBoard(board);
                futureBoard.SetSquare(move, piece);
                futureBoard.SetSquare(location, 0);

                if (checkMate.Mate(futureBoard) != true)
                {
                    LegalMoves.Add(move);
                }
            }

            return LegalMoves;
        }

        public void ChangeTurn(Board board)
        {
            /// <summary>
            /// Change turn players turn.
            /// </summary>
            if (board.playerTurn == "1000")
            {
                whiteIsMate = checkMate.Mate(board);
                board.playerTurn = "10000";
            }
            else if (board.playerTurn == "10000")
            {
                blackIsMate = checkMate.Mate(board);
                board.playerTurn = "1000";
            }
        }
    }
}
