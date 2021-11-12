using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFChessGame.Engine.Models;
using WFChessGame.Engine.viewModels;
using System.Collections.Generic;
using System;

namespace TestEngine.Models
{
    [TestClass]
    public class TestMove
    {
        [TestMethod]
        public void GetPseudoLegalMoves1()
        {
            Board board = new Board();
            board.playerTurn = "1000";
            board.ClearBoard();
            board.SetSquare(9, Piece.White | Piece.King);

            List<int> moves = Moves.GetPseudoLegalMoves(Piece.White | Piece.King, 9, board);

            Assert.IsTrue(moves.Contains(0));
            Assert.IsTrue(moves.Contains(1));
            Assert.IsTrue(moves.Contains(2));
            Assert.IsTrue(moves.Contains(8));
            Assert.IsTrue(moves.Contains(10));
            Assert.IsTrue(moves.Contains(16));
            Assert.IsTrue(moves.Contains(17));
            Assert.IsTrue(moves.Contains(18));

        }


        [TestMethod]
        public void TestGetLegalMoves1()
        {
            Board board = new Board();
            List<int> moves = new List<int>();
            board.playerTurn = "10000";

            board.FreshBoard();
            board.SetSquare(10, Piece.None);
            board.SetSquare(24, Piece.White | Piece.Queen);


            moves = Moves.GetLegalMoves(Piece.Black | Piece.Pawn, 9, board);


            Assert.IsTrue(moves.Contains(17));
        }

        [TestMethod]
        public void TestGetLegalMoves2()
        {
            Board board = new Board();
            List<int> moves = new List<int>();
            List<int> LegalMoves = new List<int>();
            List<int> enemyMoves = new List<int>();
            board.playerTurn = "10000";
            int piece = Piece.Black | Piece.Pawn;
            int location = 9;

            board.FreshBoard();
            board.SetSquare(10, Piece.None);
            board.SetSquare(24, Piece.White | Piece.Queen);



            moves.Add(17);


            foreach (int move in moves)
            {
                board.CopyBoard(FutureBoard.futureSquare);
                FutureBoard.SetSquare(move, piece);
                FutureBoard.SetSquare(location, 0);


                enemyMoves = CheckMate.GenerateAllEnemyMoves(board);

                for (int i = 0; i < 64; ++i)
                {
                    if (i % 8 == 0) Console.WriteLine("");
                    if (enemyMoves.Contains(i)) Console.Write(String.Format("{0,2} ", 1));
                    else Console.Write(String.Format("{0,2} ", FutureBoard.GetSquare(i)));
                }

                Console.WriteLine("");

                for (int i = 0; i < 64; ++i)
                {
                    if (i % 8 == 0) Console.WriteLine("");
                    if (board.GetSquare(i) != 0) Console.Write(String.Format("{0,2} ", FutureBoard.GetSquare(i)));
                    else if (enemyMoves.Contains(i)) Console.Write(String.Format("{0,2} ", 1));
                    else Console.Write(String.Format("{0,2} ", FutureBoard.GetSquare(i)));
                }

                if (CheckMate.FutureMate(board) != true)
                {
                    LegalMoves.Add(move);
                }
            }


            Assert.IsTrue(LegalMoves.Contains(17));
        }
    }
}
