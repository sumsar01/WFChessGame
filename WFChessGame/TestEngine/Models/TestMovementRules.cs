﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFChessGame.Engine.Models;
using WFChessGame.Engine.viewModels;
using System.Collections.Generic;
using System;

namespace TestEngine.Models
{
    [TestClass]
    public class TestMovementRules
    {
        [TestMethod]
        public void TestKing()
        {
            GameSession.playerTurn = "1000";
            Board.ClearBoard();
            Board.SetSquare(9, Piece.White | Piece.King);

            List<int> moves = Moves.GetPseudoLegalMoves(Piece.White | Piece.King, 9);

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
            GameSession.playerTurn = "1000";
            Board.ClearBoard();
            Board.SetSquare(9, Piece.White | Piece.Pawn);
            Board.SetSquare(0, Piece.Black | Piece.Pawn);
            Board.SetSquare(2, Piece.Black | Piece.Pawn);

            List<int> moves = Moves.GetPseudoLegalMoves(Piece.White | Piece.Pawn, 9);

            Assert.IsTrue(moves.Contains(1));
        }

        [TestMethod]
        public void TestPawn2()
        {
            GameSession.playerTurn = "1000";
            Board.ClearBoard();
            Board.SetSquare(50, Piece.White | Piece.Pawn);
            Board.SetSquare(10, Piece.Black | Piece.Pawn);

            List<int> moves = Moves.GetPseudoLegalMoves(Piece.White | Piece.Pawn, 50);

            Assert.IsTrue(moves.Contains(42));
            Assert.IsTrue(moves.Contains(34));

            GameSession.playerTurn = "10000";

            moves = Moves.GetPseudoLegalMoves(Piece.Black | Piece.Pawn, 10);

            Assert.IsTrue(moves.Contains(18));
            Assert.IsTrue(moves.Contains(26));
        }

        [TestMethod]
        public void Testknight()
        {
            GameSession.playerTurn = "1000";
            Board.ClearBoard();
            Board.SetSquare(29, Piece.White | Piece.Knight);

            List<int> moves = Moves.GetPseudoLegalMoves(Piece.White | Piece.Knight, 29);

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
            GameSession.playerTurn = "1000";
            Board.ClearBoard();
            Board.SetSquare(29, Piece.White | Piece.Knight);

            List<int> moves = Moves.GetPseudoLegalMoves(Piece.White | Piece.Bishop, 29);

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
            GameSession.playerTurn = "1000";
            Board.ClearBoard();
            Board.SetSquare(36, Piece.Black | Piece.Pawn);
            Board.SetSquare(29, Piece.White | Piece.Bishop);


            List<int> moves = Moves.GetPseudoLegalMoves(Piece.White | Piece.Bishop, 29);

            Assert.IsTrue(moves.Contains(36));
            Assert.IsFalse(moves.Contains(43));
            Assert.IsFalse(moves.Contains(50));
        }

        [TestMethod]
        public void TestBishop3()
        {
            GameSession.playerTurn = "1000";
            Board.ClearBoard();
            Board.SetSquare(36, Piece.White | Piece.Pawn);
            Board.SetSquare(29, Piece.White | Piece.Bishop);

            List<int> moves = Moves.GetPseudoLegalMoves(Piece.White | Piece.Bishop, 29);

            Assert.IsTrue(BooleanChecks.CheckIfOccupied(29, 36));

            Assert.IsFalse(moves.Contains(36));
            Assert.IsFalse(moves.Contains(43));
            Assert.IsFalse(moves.Contains(50));
        }
    }
}
