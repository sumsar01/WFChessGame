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

            List<int> moves = Moves.GetPseudoLegalMoves(Piece.White | Piece.Pawn, 50);

            Assert.IsTrue(moves.Contains(42));
            Assert.IsTrue(moves.Contains(34));
        }
    }
}
