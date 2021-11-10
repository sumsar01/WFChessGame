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
        public void TestGetLegalMoves1()
        {
            List<int> moves = new List<int>();
            GameSession.playerTurn = "10000";

            Board.FreshBoard();
            Board.SetSquare(10, Piece.None);
            Board.SetSquare(24, Piece.White | Piece.Queen);


            moves = Moves.GetLegalMoves(Piece.Black | Piece.Pawn, 9);


            Assert.IsTrue(moves.Contains(17));
        }
    }
}
