using System.Collections.Generic;
using WFChessGame.Engine.viewModels;

namespace WFChessGame.Engine.Models
{
    public class MovementRules : BooleanChecks
    {
        private int X;
        private int Y;
        private int X1;
        private int Y1;
        private int[] dX;
        private int[] dY;
        private int destination;


        public List<int> King(int location, List<int> moves, Board board)
        {
            dX = new int[] { -1, 0, 1, 1, 1, 0, -1, -1 };
            dY = new int[] { -1, -1, -1, 0, 1, 1, 1, 0 };

            return GenerateJumps(location, dX, dY, moves, board);
        }

        // Potentially needs refactoring
        private List<int> WhitePawn(int location, List<int> moves, Board board)
        {
            // Chicking if white pawn has moved yet
            // If pawn has not moved allow two forward moves
            if (48 <= location & location <= 55)
            {
                dX = new int[] { 0, 0 };
                dY = new int[] { -1, -2 };
                moves = GenerateMoves(location, dX, dY, moves, board);
            }
            else
            {
                dX = new int[] { 0 };
                dY = new int[] { -1 };
                moves = GenerateMoves(location, dX, dY, moves, board);
            }

            moves = RemoveIfBlocked(moves, board);

            // If enemy in range allow attack move
            bool enemyRight = CheckIfEnemy(location, location - 7, board);
            bool enemyLeft = CheckIfEnemy(location, location - 9, board);

            if (enemyRight == true)
            {
                dX = new int[] { 1 };
                dY = new int[] { -1 };
                moves = GenerateMoves(location, dX, dY, moves, board);
            }
            if (enemyLeft == true)
            {
                dX = new int[] { -1 };
                dY = new int[] { -1 };
                moves = GenerateMoves(location, dX, dY, moves, board);
            }


            return moves;
        }

        // Potentially needs refactoring
        private List<int> BlackPawn(int location, List<int> moves, Board board)
        {
            // Chicking if black pawn has moved yet
            // If pawn has not moved allow two forward moves
            if (8 <= location & location <= 15)
            {
                dX = new int[] { 0, 0 };
                dY = new int[] { 1, 2 };
                moves = GenerateMoves(location, dX, dY, moves, board);
            }
            else
            {
                dX = new int[] { 0 };
                dY = new int[] { 1 };
                moves = GenerateMoves(location, dX, dY, moves, board);
            }

            moves = RemoveIfBlocked(moves, board);

            // If enemy in range allow attack move
            bool enemyRight = CheckIfEnemy(location, location + 7, board);
            bool enemyLeft = CheckIfEnemy(location, location + 9, board);

            if (enemyRight == true)
            {
                dX = new int[] { -1 };
                dY = new int[] { 1  };
                moves = GenerateMoves(location, dX, dY, moves, board);
            }

            if (enemyLeft == true)
            {
                dX = new int[] { 1 };
                dY = new int[] { 1 };
                moves = GenerateMoves(location, dX, dY, moves, board);
            }

            return moves;
        }

        public List<int> Pawn(int location, List<int> moves, Board board)
        {
            if (board.playerTurn == "1000")
            {
                return WhitePawn(location, moves, board);
            }
            if (board.playerTurn == "10000")
            {
                return BlackPawn(location, moves, board);
            }
            return moves;
        }

        public List<int> Knight(int location, List<int> moves, Board board)
        {
            dX = new int[] {-1, 1, 2, 2, 1, -1, -2, -2};
            dY = new int[] {-2, -2, -1, 1, 2, 2, 1, -1};

            return GenerateJumps(location, dX, dY, moves, board);
        }

        public List<int> Bishop(int location, List<int> moves, Board board)
        {

            // Generate moves for each of the four possible paths.
            // Allows tracking of blocked paths.
            dX = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            dY = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            moves = GenerateMoves(location, dX, dY, moves, board);

            dX = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            dY = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            moves = GenerateMoves(location, dX, dY, moves, board);

            dX = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            dY = new int[] {  1,  2,  3,  4,  5,  6,  7 };
            moves = GenerateMoves(location, dX, dY, moves, board);

            dX = new int[] {  1,  2,  3,  4,  5,  6,  7 };
            dY = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            moves = GenerateMoves(location, dX, dY, moves, board);

            return moves;
        }

        public List<int> Rook(int location, List<int> moves, Board board)
        {

            // Generate moves for each of the four possible paths.
            // Allows tracking of blocked paths.
            dX = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            dY = new int[] {  0,  0,  0,  0,  0,  0,  0 };
            moves = GenerateMoves(location, dX, dY, moves, board);

            dX = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            dY = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            moves = GenerateMoves(location, dX, dY, moves, board);

            dX = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            dY = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            moves = GenerateMoves(location, dX, dY, moves, board);

            dX = new int[] {  0,  0,  0,  0,  0,  0,  0 };
            dY = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            moves = GenerateMoves(location, dX, dY, moves, board);

            return moves;
        }

        public List<int> Queen(int location, List<int> moves, Board board)
        {
            // Generate moves for each of the four possible paths.
            // Allows tracking of blocked paths.
            // Bishop moves.
            dX = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            dY = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            moves = GenerateMoves(location, dX, dY, moves, board);

            dX = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            dY = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            moves = GenerateMoves(location, dX, dY, moves, board);

            dX = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            dY = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            moves = GenerateMoves(location, dX, dY, moves, board);

            dX = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            dY = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            moves = GenerateMoves(location, dX, dY, moves, board);

            // Rook moves
            dX = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            dY = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            moves = GenerateMoves(location, dX, dY, moves, board);

            dX = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            dY = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            moves = GenerateMoves(location, dX, dY, moves, board);

            dX = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            dY = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            moves = GenerateMoves(location, dX, dY, moves, board);

            dX = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            dY = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            moves = GenerateMoves(location, dX, dY, moves, board);

            return moves;
        }

        /// <summary>
        /// Auxiliary method that generates and returns a list of moves.
        /// </summary>
        private List<int> GenerateMoves(int location, int[] dX, int[] dY, List<int> moves, Board board)
        {
            (X, Y) = LineToXY(location);
            for (int i = 0; i < dX.Length; ++i)
            {
                X1 = X + dX[i];
                Y1 = Y + dY[i];
                if (CheckOutOfBound(X1, Y1) == false)
                {
                    destination = XYToLine(X1, Y1);
                    if (CheckIfOccupied(location, destination, board)) break;

                    moves.Add(destination);

                    if (CheckIfEnemy(location, destination, board)) break;
                }
            }

            moves = RemoveIfOccupied(moves, location, board);

            return moves;
        }

        /// <summary>
        /// Auxiliary method that generates and returns a list of moves for the knight and the king.
        /// </summary>
        private List<int> GenerateJumps(int location, int[] dX, int[] dY, List<int> moves, Board board)
        {
            (X, Y) = LineToXY(location);
            for (int i = 0; i < dX.Length; ++i)
            {
                X1 = X + dX[i];
                Y1 = Y + dY[i];
                if (CheckOutOfBound(X1, Y1) == false)
                {
                    destination = XYToLine(X1, Y1);
                    moves.Add(destination);
                }
            }

            moves = RemoveIfOccupied(moves, location, board);

            return moves;
        }

        /// <summary>
        /// Remove moves occupied by allies from list of moves.
        /// </summary>
        /// <param name="moves">List of possible moves</param>
        /// <param name="location">Location of the piece about to move</param>
        private List<int> RemoveIfOccupied(List<int> moves, int location, Board board)
        {
            int piece = board.GetSquare(location);
            List<int> occupiedMoves = new List<int>();
            foreach (int move in moves)
            {
                if (CheckIfOccupied(location, move, board))
                {
                    occupiedMoves.Add(move);
                }
            }

            foreach (int move in occupiedMoves)
            {
                moves.Remove(move);
            }

            return moves;
        }

        private List<int> RemoveIfBlocked(List<int> moves, Board board)
        {
            for(int i = 0; i < moves.Count; ++i)
            {
                int move = moves[i];
                if (IsBlocked(move, board))
                {
                    moves.Remove(move);
                }
            }

            return moves;
        }

        /// <summary>
        /// Transform (X, Y) into [X1, X2, ..., XN] type of coordinate, used by board.
        /// </summary>
        private int XYToLine(int X, int Y)
        {
            int coordinate = Y * 8 + X;

            return coordinate;
        }

        /// <summary>
        /// Transform [X1, X2, ..., XN] into (X, Y) type of coordinate.
        /// </summary>
        private (int, int) LineToXY(int location)
        {
            int X = location % 8;
            int Y = (location - X) / 8;

            return (X, Y);
        }
    }
}
