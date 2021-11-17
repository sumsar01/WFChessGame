using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFChessGame.Engine.Models;
using WFChessGame.Engine.viewModels;
using System.Collections.Generic;
using System;

namespace TestEngine.Models
{
    [TestClass]
    public class TestMovementRules
    {
        Board board;
        MoveGenerator moveGenerator;

        [TestInitialize]
        public void Initalize()
        {
            board = new Board();
            moveGenerator = new MoveGenerator();
        }


        [TestMethod]
        public void TestKing()
        {
            board.playerTurn = "1000";
            board.SetSquare(9, Piece.White | Piece.King);

            List<int> moves = moveGenerator.GetPseudoLegalMoves(Piece.White | Piece.King, 9, board);

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
        public void TestPawn1()
        {
            board.playerTurn = "1000";
            board.SetSquare(9, Piece.White | Piece.Pawn);
            board.SetSquare(0, Piece.Black | Piece.Pawn);
            board.SetSquare(2, Piece.Black | Piece.Pawn);

            List<int> moves = moveGenerator.GetPseudoLegalMoves(Piece.White | Piece.Pawn, 9, board);

            Assert.IsTrue(moves.Contains(1));
        }

        [TestMethod]
        public void TestPawn2()
        {
            board.playerTurn = "1000";
            board.SetSquare(50, Piece.White | Piece.Pawn);
            board.SetSquare(10, Piece.Black | Piece.Pawn);

            List<int> moves = moveGenerator.GetPseudoLegalMoves(Piece.White | Piece.Pawn, 50, board);

            Assert.IsTrue(moves.Contains(42));
            Assert.IsTrue(moves.Contains(34));

            board.playerTurn = "10000";

            moves = moveGenerator.GetPseudoLegalMoves(Piece.Black | Piece.Pawn, 10, board);

            Assert.IsTrue(moves.Contains(18));
            Assert.IsTrue(moves.Contains(26));
        }

        [TestMethod]
        public void Testknight()
        {
            board.playerTurn = "1000";
            board.SetSquare(29, Piece.White | Piece.Knight);

            List<int> moves = moveGenerator.GetPseudoLegalMoves(Piece.White | Piece.Knight, 29, board);

            Assert.IsTrue(moves.Contains(12));
            Assert.IsTrue(moves.Contains(14));
            Assert.IsTrue(moves.Contains(23));
            Assert.IsTrue(moves.Contains(39));
            Assert.IsTrue(moves.Contains(46));
            Assert.IsTrue(moves.Contains(44));
            Assert.IsTrue(moves.Contains(35));
            Assert.IsTrue(moves.Contains(19));
        }

        [TestMethod]
        public void TestBishop1()
        {
            board.playerTurn = "1000";
            board.SetSquare(29, Piece.White | Piece.Knight);

            List<int> moves = moveGenerator.GetPseudoLegalMoves(Piece.White | Piece.Bishop, 29, board);

            Assert.IsTrue(moves.Contains(22));
            Assert.IsTrue(moves.Contains(15));
            Assert.IsTrue(moves.Contains(36));
            Assert.IsTrue(moves.Contains(43));
            Assert.IsTrue(moves.Contains(50));

            Assert.IsTrue(moves.Contains(38));
            Assert.IsTrue(moves.Contains(47));
            Assert.IsTrue(moves.Contains(20));
            Assert.IsTrue(moves.Contains(11));
            Assert.IsTrue(moves.Contains(2));
        }

        [TestMethod]
        public void TestBishop2()
        {
            board.playerTurn = "1000";
            board.SetSquare(36, Piece.Black | Piece.Pawn);
            board.SetSquare(29, Piece.White | Piece.Bishop);


            List<int> moves = moveGenerator.GetPseudoLegalMoves(Piece.White | Piece.Bishop, 29, board);

            Assert.IsTrue(moves.Contains(36));
            Assert.IsFalse(moves.Contains(43));
            Assert.IsFalse(moves.Contains(50));
        }

        [TestMethod]
        public void TestBishop3()
        {
            board.playerTurn = "1000";
            board.SetSquare(36, Piece.White | Piece.Pawn);
            board.SetSquare(29, Piece.White | Piece.Bishop);

            List<int> moves = moveGenerator.GetPseudoLegalMoves(Piece.White | Piece.Bishop, 29, board);

            Assert.IsTrue(moveGenerator.CheckIfOccupied(29, 36, board));

            Assert.IsFalse(moves.Contains(36));
            Assert.IsFalse(moves.Contains(43));
            Assert.IsFalse(moves.Contains(50));
        }
    }
}
