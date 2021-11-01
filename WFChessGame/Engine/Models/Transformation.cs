using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFChessGame.Engine.Models
{
    /// <summary>
    /// Transform coordinates from one coordinate system to another one
    /// </summary>
    public static class Transformation
    {

        /// <summary>
        /// Transform (X, Y) into [X1, X2, ..., XN] type of coordinate, used by board.
        /// </summary>

        public static int XYToLine(int X, int Y)
        {
            int coordinate = Y * 8 + X;

            return coordinate;
        }

        /// <summary>
        /// Transform [X1, X2, ..., XN] into (X, Y) type of coordinate.
        /// </summary>
        public static (int, int) LineToXY(int location)
        {
            int X = location % 8;
            int Y = (location - X) / 8;

            return (X, Y);
        }
    }
}
