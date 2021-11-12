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
                board.ChangeTurn();
            }
        }


        public List<int> GetLegalMoves(int piece, int location, Board board)
        {
            List<int> LegalMoves = new List<int>();
            List<int> moves = moveGenerator.GetPseudoLegalMoves(piece, location, board);

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
    }
}
