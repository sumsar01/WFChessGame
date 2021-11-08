using System.IO;
using System;
using System.ComponentModel;


namespace WFChessGame.Engine.Models
{
    public static class Board
    {
        private static int[] _square;
        static int intRep;

        public static int GetSquare(int location)
        {
            if(location >= 0 & 63 >= location)
            {
                return _square[location];
            }

            return -1;
        }
        public static void SetSquare(int location, int piece)
        {
            if (piece != _square[location] & location >= 0 & 63 >= location)
            {
                _square[location] = piece;
                OnValueChanged(null);
            }
        }

        static Board()
        {
            _square = new int[64];


        }

        [Category("Action")]
        [Description("Fires when the value is changed")]
        public static event EventHandler ValueChanged;
        static void OnValueChanged(EventArgs e)
        {
            if(ValueChanged != null)
            {
                ValueChanged(Board._square, e);
            }
        }

        public static string GetPieceImg(int piecePosition)
        {
            intRep = _square[piecePosition];

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

        public static void FreshBoard()
        {
            // Black side first
            _square[0] = Piece.Black | Piece.Rook;
            _square[1] = Piece.Black | Piece.Knight;
            _square[2] = Piece.Black | Piece.Bishop;
            _square[3] = Piece.Black | Piece.King;
            _square[4] = Piece.Black | Piece.Queen;
            _square[5] = Piece.Black | Piece.Bishop;
            _square[6] = Piece.Black | Piece.Knight;
            _square[7] = Piece.Black | Piece.Rook;

            _square[8] = Piece.Black | Piece.Pawn;
            _square[9] = Piece.Black | Piece.Pawn;
            _square[10] = Piece.Black | Piece.Pawn;
            _square[11] = Piece.Black | Piece.Pawn;
            _square[12] = Piece.Black | Piece.Pawn;
            _square[13] = Piece.Black | Piece.Pawn;
            _square[14] = Piece.Black | Piece.Pawn;
            _square[15] = Piece.Black | Piece.Pawn;

            // Readies white side
            _square[48] = Piece.White | Piece.Pawn;
            _square[49] = Piece.White | Piece.Pawn;
            _square[50] = Piece.White | Piece.Pawn;
            _square[51] = Piece.White | Piece.Pawn;
            _square[52] = Piece.White | Piece.Pawn;
            _square[53] = Piece.White | Piece.Pawn;
            _square[54] = Piece.White | Piece.Pawn;
            _square[55] = Piece.White | Piece.Pawn;

            _square[56] = Piece.White | Piece.Rook;
            _square[57] = Piece.White | Piece.Knight;
            _square[58] = Piece.White | Piece.Bishop;
            _square[59] = Piece.White | Piece.King;
            _square[60] = Piece.White | Piece.Queen;
            _square[61] = Piece.White | Piece.Bishop;
            _square[62] = Piece.White | Piece.Knight;
            _square[63] = Piece.White | Piece.Rook;
        }

        public static void ClearBoard()
        {
            for(int i = 0; i < 64; ++i)
            {
                _square[i] = 0;
            }
        }
    }
}
