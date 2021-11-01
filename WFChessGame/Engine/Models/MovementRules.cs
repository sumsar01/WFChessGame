using System.Collections.Generic;

namespace WFChessGame.Engine.Models
{
    public static class MovementRules
    {
        static int[] input;
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


    }
}
