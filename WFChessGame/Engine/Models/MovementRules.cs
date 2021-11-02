using System.Collections.Generic;
using System.Diagnostics;

namespace WFChessGame.Engine.Models
{
    public static class MovementRules
    {
        static int[] input;
        static int X;
        static int Y;
        static int X1;
        static int Y1;
        static int[] dX;
        static int[] dY;
        static int destination;


        public static List<int> King(int location, List<int> moves)
        {
            dX = new int[] { -1, 0, 1, 1, 1, 0, -1, -1 };
            dY = new int[] { -1, -1, -1, 0, 1, 1, 1, 0 };
            (X, Y) = Transformation.LineToXY(location);

            return GenerateMoves(X, Y, dX, dY, moves);
        }

        // Potentially needs refactoring
        public static List<int> WhitePawn(int location, List<int> moves)
        {
            // Chicking if white pawn has moved yet
            // If pawn has not moved allow two forward moves
            if (48 <= location & location <= 55)
            {
                input = new int[] { location - 8, location - 16 };
                moves.AddRange(input);
            }
            else
            {
                input = new int[] { location - 8 };
                moves.AddRange(input);
            }

            // If enemy in range allow attack move
            bool enemyRight = BooleanChecks.CheckIfEnemy(location, location - 7);
            bool enemyLeft = BooleanChecks.CheckIfEnemy(location, location - 9);

            if (enemyRight == true) moves.Add(location - 7);
            if (enemyLeft == true) moves.Add(location - 9);

            return moves;
        }

        // Potentially needs refactoring
        public static List<int> BlackPawn(int location, List<int> moves)
        {
            // Chicking if black pawn has moved yet
            // If pawn has not moved allow two forward moves
            if (8 <= location & location <= 15)
            {
                input = new int[] { location + 8, location + 16 };
                moves.AddRange(input);
            }
            else
            {
                input = new int[] { location + 8 };
                moves.AddRange(input);
            }

            // If enemy in range allow attack move
            bool enemyRight = BooleanChecks.CheckIfEnemy(location, location + 7);
            bool enemyLeft = BooleanChecks.CheckIfEnemy(location, location + 9);

            if (enemyRight == true) moves.Add(location + 7);
            if (enemyLeft == true) moves.Add(location + 9);

            return moves;
        }

        public static List<int> Knight(int location, List<int> moves)
        {
            dX = new int[] {-1, 1, 2, 2, 1, -1, -2, -2};
            dY = new int[] {-2, -2, -1, 1, 2, 2, 1, -1};
            (X, Y) = Transformation.LineToXY(location);

            return GenerateMoves(X, Y, dX, dY, moves);
        }

        public static List<int> Bishop(int location, List<int> moves)
        {
            dX = new int[] { -7, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 7 };
            dY = new int[] { -7, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 7 };
            (X, Y) = Transformation.LineToXY(location);

            return GenerateMoves(X, Y, dX, dY, moves);
        }

        public static List<int> Rook(int location, List<int> moves)
        {
            return moves;
        }

        public static List<int> Queen(int location, List<int> moves)
        {
            return moves;
        }

        /// <summary>
        /// Auxiliary method that generates and returns a list of moves.
        /// </summary>
        private static List<int> GenerateMoves(int X, int Y, int[] dX, int[] dY, List<int> moves)
        {
            for (int i = 0; i < dX.Length; ++i)
            {
                X1 = X + dX[i];
                Y1 = Y + dY[i];
                if (BooleanChecks.CheckOutOfBound(X1, Y1) == false)
                {
                    destination = Transformation.XYToLine(X1, Y1);
                    moves.Add(destination);
                }
            }

            return moves;
        }
    }
}
