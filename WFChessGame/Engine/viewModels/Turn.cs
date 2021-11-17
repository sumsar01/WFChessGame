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
        List<int> allLegalMoves;
        List<int> movesToGet;

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


        /// <summary>
        /// Return all possible legal moves.
        /// </summary>
        public List<int> GenerateAllLegalMoves(Board board)
        {
            allLegalMoves = new List<int>();
            movesToGet = new List<int>();
            moves = new List<int>();

            movesToGet = checkMate.GeneratePositions(movesToGet, board, "friend");

            foreach (int location in movesToGet)
            {
                piece = board.GetSquare(location);
                moves = GetLegalMoves(piece, location, board);

                foreach (int move in moves)
                {
                    allLegalMoves.Add(move);
                }
            }

            return allLegalMoves;
        }

        public bool IsCheckMate(Board board)
        {
            if (checkMate.Mate(board))
            {
                moves = new List<int>();
                moves = GenerateAllLegalMoves(board);

                if (moves.Count == 0) return true;
            }

            return false;
        }

        public void ChangeTurn(Board board)
        {
            /// <summary>
            /// Change turn players turn.
            /// </summary>
            if (board.playerTurn == "1000")
            {
                board.playerTurn = "10000";
            }
            else if (board.playerTurn == "10000")
            {
                board.playerTurn = "1000";
            }
        }
    }
}
