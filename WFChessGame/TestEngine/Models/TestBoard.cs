using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFChessGame.Engine.Models;
using System;

namespace TestEngine.Models
{
    [TestClass]
    public class TestBoard
    {
        Board board;
        Board futureBoard;

        [TestInitialize]
        public void Initalize()
        {
            board = new Board();
        }

        [TestMethod]
        public void TestNewBoardIsEmpty()
        {
            for(int i = 0; i < 64; ++i)
            {
                Assert.IsTrue(board.GetSquare(i) == 0);
            }
        }

        [TestMethod]
        public void TestCopyBoard()
        {
            futureBoard = new Board();

            board.FreshBoard();
            futureBoard.CopyBoard(board);

            for (int i = 0; i < 64; ++i)
            {
                Assert.IsTrue(board.GetSquare(i) == futureBoard.GetSquare(i));
            }

        }
    }
}
