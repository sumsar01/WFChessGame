using System.Collections.Generic;

namespace WFChessGame.Engine.Models
{
    /// <summary>
    /// Checks for mate and checkmate
    /// </summary>
    public class CheckMate : BooleanChecksBaseClass
    {
        private MoveGenerator moveGenerator;
        private List<int> allEnemyMoves;
        private List<int> enemyMoves;
        private List<int> movesToGet;
        private List<int> moves;
        private int piece;

        public CheckMate()
        {
            moveGenerator = new MoveGenerator();
        }

        public bool Mate(Board board)
        {
            allEnemyMoves = new List<int>();
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
        public List<int> GeneratePositions(List<int> movesToGet, Board board, string team = "enemy")
        {
            if(team == "friend")
            {
                if (board.playerTurn == "10000")
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
                if (board.playerTurn == "1000")
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
            enemyMoves = new List<int>();
            movesToGet = new List<int>();
            moves = new List<int>();
            
            movesToGet = GeneratePositions(movesToGet, board);

            foreach(int location in movesToGet)
            {
                piece = board.GetSquare(location);
                moves = moveGenerator.GetEnemyMoves(location, board);

                foreach(int move in moves)
                {
                    enemyMoves.Add(move);
                }
            }

            return enemyMoves;
        }
    }
}
