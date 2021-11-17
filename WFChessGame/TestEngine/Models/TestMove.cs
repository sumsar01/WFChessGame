using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFChessGame.Engine.Models;
using System.Collections.Generic;

namespace TestEngine.Models
{
    [TestClass]
    public class TestMove
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
        public void GetPseudoLegalMoves1()
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
    }
}
