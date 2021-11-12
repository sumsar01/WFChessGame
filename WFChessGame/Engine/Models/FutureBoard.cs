using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFChessGame.Engine.Models
{
    public class FutureBoard
    {
        public static int[] futureSquare;

        public static int GetSquare(int location)
        {
            if (location >= 0 & 63 >= location)
            {
                return futureSquare[location];
            }

            return -1;
        }
        public static void SetSquare(int location, int piece)
        {
            if (location >= 0 & 63 >= location && piece != futureSquare[location])
            {
                futureSquare[location] = piece;
            }
        }

        static FutureBoard()
        {
            futureSquare = new int[64];

        }

    }
}
