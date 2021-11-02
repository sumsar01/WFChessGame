using System.Collections.Generic;
using WFChessGame.Engine.viewModels;

namespace WFChessGame.Engine.Models
{
    public static class MovementRules
    {
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

            return GenerateMoves(location, dX, dY, moves);
        }

        // Potentially needs refactoring
        public static List<int> WhitePawn(int location, List<int> moves)
        {
            // Chicking if white pawn has moved yet
            // If pawn has not moved allow two forward moves
            if (48 <= location & location <= 55)
            {
                dX = new int[] { 0, 0 };
                dY = new int[] { -1, -2 };
                moves = GenerateMoves(location, dX, dY, moves);
            }
            else
            {
                dX = new int[] { 0 };
                dY = new int[] { -1 };
                moves = GenerateMoves(location, dX, dY, moves);
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
                dX = new int[] { 0, 0 };
                dY = new int[] { 1, 2 };
                moves = GenerateMoves(location, dX, dY, moves);
            }
            else
            {
                dX = new int[] { 0 };
                dY = new int[] { 1 };
                moves = GenerateMoves(location, dX, dY, moves);
            }

            // If enemy in range allow attack move
            bool enemyRight = BooleanChecks.CheckIfEnemy(location, location + 7);
            bool enemyLeft = BooleanChecks.CheckIfEnemy(location, location + 9);

            if (enemyRight == true) moves.Add(location + 7);
            if (enemyLeft == true) moves.Add(location + 9);

            return moves;
        }

        public static List<int> Pawn(int location, List<int> moves)
        {
            if (GameSession.playerTurn == "1000")
            {
                return MovementRules.WhitePawn(location, moves);
            }
            if (GameSession.playerTurn == "10000")
            {
                return MovementRules.BlackPawn(location, moves);
            }
            return moves;
        }

        public static List<int> Knight(int location, List<int> moves)
        {
            dX = new int[] {-1, 1, 2, 2, 1, -1, -2, -2};
            dY = new int[] {-2, -2, -1, 1, 2, 2, 1, -1};

            return GenerateJumps(location, dX, dY, moves);
        }

        public static List<int> Bishop(int location, List<int> moves)
        {

            // Generate moves for each of the four possible paths.
            // Allows tracking of blocked paths.
            dX = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            dY = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            moves = GenerateMoves(location, dX, dY, moves);

            dX = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            dY = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            moves = GenerateMoves(location, dX, dY, moves);

            dX = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            dY = new int[] {  1,  2,  3,  4,  5,  6,  7 };
            moves = GenerateMoves(location, dX, dY, moves);

            dX = new int[] {  1,  2,  3,  4,  5,  6,  7 };
            dY = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            moves = GenerateMoves(location, dX, dY, moves);

            return moves;
        }

        public static List<int> Rook(int location, List<int> moves)
        {

            // Generate moves for each of the four possible paths.
            // Allows tracking of blocked paths.
            dX = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            dY = new int[] {  0,  0,  0,  0,  0,  0,  0 };
            moves = GenerateMoves(location, dX, dY, moves);

            dX = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            dY = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            moves = GenerateMoves(location, dX, dY, moves);

            dX = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            dY = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            moves = GenerateMoves(location, dX, dY, moves);

            dX = new int[] {  0,  0,  0,  0,  0,  0,  0 };
            dY = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            moves = GenerateMoves(location, dX, dY, moves);

            return moves;
        }

        public static List<int> Queen(int location, List<int> moves)
        {
            // Generate moves for each of the four possible paths.
            // Allows tracking of blocked paths.
            // Bishop moves.
            dX = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            dY = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            moves = GenerateMoves(location, dX, dY, moves);

            dX = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            dY = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            moves = GenerateMoves(location, dX, dY, moves);

            dX = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            dY = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            moves = GenerateMoves(location, dX, dY, moves);

            dX = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            dY = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            moves = GenerateMoves(location, dX, dY, moves);

            // Rook moves
            dX = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            dY = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            moves = GenerateMoves(location, dX, dY, moves);

            dX = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            dY = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            moves = GenerateMoves(location, dX, dY, moves);

            dX = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            dY = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            moves = GenerateMoves(location, dX, dY, moves);

            dX = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            dY = new int[] { -1, -2, -3, -4, -5, -6, -7 };
            moves = GenerateMoves(location, dX, dY, moves);

            return moves;
        }

        /// <summary>
        /// Auxiliary method that generates and returns a list of moves.
        /// </summary>
        private static List<int> GenerateMoves(int location, int[] dX, int[] dY, List<int> moves)
        {
            (X, Y) = Transformation.LineToXY(location);
            for (int i = 0; i < dX.Length; ++i)
            {
                X1 = X + dX[i];
                Y1 = Y + dY[i];
                if (BooleanChecks.CheckOutOfBound(X1, Y1) == false)
                {
                    destination = Transformation.XYToLine(X1, Y1);
                    if (BooleanChecks.CheckIfOccupied(location, destination)) break;

                    moves.Add(destination);

                    if (BooleanChecks.CheckIfEnemy(location, destination)) break;
                }
            }

            moves = RemoveIfOccupied(moves, location);

            return moves;
        }

        /// <summary>
        /// Auxiliary method that generates and returns a list of moves for the knight.
        /// </summary>
        private static List<int> GenerateJumps(int location, int[] dX, int[] dY, List<int> moves)
        {
            (X, Y) = Transformation.LineToXY(location);
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

            moves = RemoveIfOccupied(moves, location);

            return moves;
        }

        /// <summary>
        /// Remove moves occupied by allies from list of moves.
        /// </summary>
        /// <param name="moves">List of possible moves</param>
        /// <param name="location">Location of the piece about to move</param>
        public static List<int> RemoveIfOccupied(List<int> moves, int location)
        {
            int piece = Board.GetSquare(location);
            List<int> occupiedMoves = new List<int>();
            foreach (int move in moves)
            {
                if (BooleanChecks.CheckIfOccupied(location, move))
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

    }
}
