using System.Collections.Generic;

namespace WFChessGame.Engine.Models
{
    /// <summary>
    /// Checks for mate and checkmate
    /// </summary>
    public class CheckMate : BooleanChecksBaseClass
    {
        private MoveGenerator moveGenerator;

        public CheckMate()
        {
            moveGenerator = new MoveGenerator();
        }


        public bool Mate(Board board)
        {
            List<int> allEnemyMoves = new List<int>();
            int piece;

            allEnemyMoves = GenerateAllEnemyMoves(board);

            foreach (int move in allEnemyMoves)
            {
                piece = board.GetSquare(move);

                if(CheckTurn(piece, board) && IsKing(piece))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Get location of all enemy pieces.
        /// </summary>
        public List<int> GenerateEnemyPositions(List<int> movesToGet, Board board)
        {
            if (board.playerTurn == "1000")
            {
                for (int location = 0; location < 64; ++location)
                {
                    if (IsBlackPiece(location, board))
                    {
                        movesToGet.Add(location);
                    }
                }
            }
            // If black players turn. Get location of white pieces
            if (board.playerTurn == "10000")
            {
                for (int location = 0; location < 64; ++location)
                {
                    if (IsWhitePiece(location, board))
                    {
                        movesToGet.Add(location);
                    }
                }
            }

            return movesToGet;
        }

        /// <summary>
        /// Return all possible moves made by the enemy.
        /// </summary>
        public List<int> GenerateAllEnemyMoves(Board board)
        {
            List<int> enemyMoves = new List<int>();
            List<int> movesToGet = new List<int>();
            List<int> moves = new List<int>();
            int piece;

            movesToGet = GenerateEnemyPositions(movesToGet, board);

            foreach(int location in movesToGet)
            {
                piece = board.GetSquare(location);
                moves = moveGenerator.GetEnemyMoves(piece, location, board);

                foreach(int move in moves)
                {
                    enemyMoves.Add(move);
                }
            }

            return enemyMoves;
        }
    }
}
