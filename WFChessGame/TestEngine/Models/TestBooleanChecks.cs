using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFChessGame.Engine.Models;

namespace TestEngine.Models
{
    [TestClass]
    public class TestBooleanChecks
    {
        [TestMethod]
        public void TestCheckIfEnemy1()
        {
            Board.FreshBoard();

            // Check if enemy is enemy
            int piecePos = 8;
            int enemyPos = 48;
            bool isEnemy = BooleanChecks.CheckIfEnemy(piecePos, enemyPos);

            Assert.IsTrue(isEnemy, "CheckIfEnemy failed: Enemy is not enemy");

        }

        [TestMethod]
        public void TestCheckIfEnemy2()
        {
            Board.FreshBoard();

            // Check if friend is enemy
            int piecePos = 8;
            int enemyPos = 9;
            bool isEnemy = BooleanChecks.CheckIfEnemy(piecePos, enemyPos);

            Assert.IsFalse(isEnemy, "CheckIfEnemy failed: Friend is enemy");

        }

        [TestMethod]
        public void TestCheckIfEnemy3()
        {
            Board.FreshBoard();

            // Check if empty square is enemy
            int piecePos = 8;
            int enemyPos = 16;
            bool isEnemy = BooleanChecks.CheckIfEnemy(piecePos, enemyPos);

            Assert.IsFalse(isEnemy, "CheckIfEnemy failed: Friend is enemy");
        }

        [TestMethod]
        public void TestIsBlackPiece()
        {
            Board.SetSquare(5, 18);
            Board.SetSquare(8, 19);

            bool isBlack1 = BooleanChecks.IsBlackPiece(2);
            bool isBlack2 = BooleanChecks.IsBlackPiece(9);

            Assert.IsTrue(isBlack1);
            Assert.IsTrue(isBlack2);

        }

        [TestMethod]
        public void TestIsWhitePiece()
        {
            Board.SetSquare(2, 9);
            Board.SetSquare(9, 10);

            bool isWhite1 = BooleanChecks.IsWhitePiece(2);
            bool isWhite2 = BooleanChecks.IsWhitePiece(9);

            Assert.IsTrue(isWhite1);
            Assert.IsTrue(isWhite2);

        }

    }
}
