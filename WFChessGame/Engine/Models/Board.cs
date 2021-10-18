using System.IO;
using System;
using System.ComponentModel;


namespace WFChessGame.Models
{
    public static class Board
    {
        public static int[] Square;
        static int intRep;

        public static int getSquare(int index)
        {
            return Square[index];
        }

        public static void setSquare(int index, int value)
        {
            if (value != Square[index])
            {
                Square[index] = value;
                OnValueChanged(null);
            }
        }

        static Board()
        {
            Square = new int[64];

            // Readies fresh game
            NewGame();

        }

        [Category("Action")]
        [Description("Fires when the value is changed")]
        public static event EventHandler ValueChanged;
        static void OnValueChanged(EventArgs e)
        {
            if(ValueChanged != null)
            {
                ValueChanged(Board.Square, e);
            }
        }

        public static string GetPieceImg(int piecePosition)
        {
            intRep = Square[piecePosition];

            switch(intRep)
            {
                case 9:
                    string WhiteKingPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Engine\\Images\\WhiteKing.png";
                    return WhiteKingPath;
                case 10:
                    string WhitePawnPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Engine\\Images\\WhitePawn.png";
                    return WhitePawnPath;
                case 11:
                    string WhiteKnightPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Engine\\Images\\WhiteKnight.png";
                    return WhiteKnightPath;
                case 12:
                    string WhiteBishopPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Engine\\Images\\WhiteBishop.png";
                    return WhiteBishopPath;
                case 13:
                    string WhiteRookPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Engine\\Images\\WhiteRook.png";
                    return WhiteRookPath;
                case 14:
                    string WhiteQueenPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Engine\\Images\\WhiteQueen.png";
                    return WhiteQueenPath;
                case 17:
                    string BlackKingPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Engine\\Images\\BlackKing.png";
                    return BlackKingPath;
                case 18:
                    string BlackPawnPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Engine\\Images\\BlackPawn.png";
                    return BlackPawnPath;
                case 19:
                    string BlackKnightPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Engine\\Images\\BlackKnight.png";
                    return BlackKnightPath;
                case 20:
                    string BlackBishopPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Engine\\Images\\BlackBishop.png";
                    return BlackBishopPath;
                case 21:
                    string BlackRookPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Engine\\Images\\BlackRook.png";
                    return BlackRookPath;
                case 22:
                    string BlackQueenPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Engine\\Images\\BlackQueen.png";
                    return BlackQueenPath;



            }

            string EmptySquare = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Engine\\Images\\EmptySquare.png";
            return EmptySquare;
        }

        static void NewGame()
        {
            // Black side first
            Square[0] = Piece.Black | Piece.Rook;
            Square[1] = Piece.Black | Piece.Knight;
            Square[2] = Piece.Black | Piece.Bishop;
            Square[3] = Piece.Black | Piece.King;
            Square[4] = Piece.Black | Piece.Queen;
            Square[5] = Piece.Black | Piece.Bishop;
            Square[6] = Piece.Black | Piece.Knight;
            Square[7] = Piece.Black | Piece.Rook;

            Square[8] = Piece.Black | Piece.Pawn;
            Square[9] = Piece.Black | Piece.Pawn;
            Square[10] = Piece.Black | Piece.Pawn;
            Square[11] = Piece.Black | Piece.Pawn;
            Square[12] = Piece.Black | Piece.Pawn;
            Square[13] = Piece.Black | Piece.Pawn;
            Square[14] = Piece.Black | Piece.Pawn;
            Square[15] = Piece.Black | Piece.Pawn;

            // Readies white side
            Square[48] = Piece.White | Piece.Pawn;
            Square[49] = Piece.White | Piece.Pawn;
            Square[50] = Piece.White | Piece.Pawn;
            Square[51] = Piece.White | Piece.Pawn;
            Square[52] = Piece.White | Piece.Pawn;
            Square[53] = Piece.White | Piece.Pawn;
            Square[54] = Piece.White | Piece.Pawn;
            Square[55] = Piece.White | Piece.Pawn;

            Square[56] = Piece.White | Piece.Rook;
            Square[57] = Piece.White | Piece.Knight;
            Square[58] = Piece.White | Piece.Bishop;
            Square[59] = Piece.White | Piece.King;
            Square[60] = Piece.White | Piece.Queen;
            Square[61] = Piece.White | Piece.Bishop;
            Square[62] = Piece.White | Piece.Knight;
            Square[63] = Piece.White | Piece.Rook;

        }
    }
}
