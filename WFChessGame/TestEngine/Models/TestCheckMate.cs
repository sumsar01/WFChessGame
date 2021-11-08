using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFChessGame.Engine.Models;
using WFChessGame.Engine.viewModels;
using System.Collections.Generic;

namespace TestEngine.Models
{
    [TestClass]
    public class TestCheckMate
    {
        [TestMethod]
        public void TestGenerateEnemyPositions()
        {
            GameSession.playerTurn = "1000";
            List<int> movesToGet = new List<int>();
            int pos1 = 1;
            int pos2 = 5;
            int pos3 = 8;

            int wrongpos1 = 2;
            int wrongpos2 = 9;

            // Set black pieces
            Board.SetSquare(1, 17);
            Board.SetSquare(5, 18);
            Board.SetSquare(8, 19);

            // set white pieces
            Board.SetSquare(2, 9);
            Board.SetSquare(9, 6);

            movesToGet = CheckMate.GenerateEnemyPositions(movesToGet);

            Assert.IsTrue(movesToGet.Contains(pos1));
            Assert.IsTrue(movesToGet.Contains(pos2));
            Assert.IsTrue(movesToGet.Contains(pos3));

            Assert.IsFalse(movesToGet.Contains(wrongpos1));
            Assert.IsFalse(movesToGet.Contains(wrongpos2));
        }
    }
}
