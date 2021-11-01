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
            Board.NewGame();

            // Check if enemy is enemy
            int piecePos = 8;
            int enemyPos = 48;
            bool isEnemy = BooleanChecks.CheckIfEnemy(piecePos, enemyPos);

            Assert.IsTrue(isEnemy, "CheckIfEnemy failed: Enemy is not enemy");

        }

        [TestMethod]
        public void TestCheckIfEnemy2()
        {

            // Check if friend is enemy
            int piecePos = 8;
            int enemyPos = 9;
            bool isEnemy = BooleanChecks.CheckIfEnemy(piecePos, enemyPos);

            Assert.IsFalse(isEnemy, "CheckIfEnemy failed: Friend is enemy");

        }

        [TestMethod]
        public void TestCheckIfEnemy3()
        {

            // Check if empty square is enemy
            int piecePos = 8;
            int enemyPos = 16;
            bool isEnemy = BooleanChecks.CheckIfEnemy(piecePos, enemyPos);

            Assert.IsFalse(isEnemy, "CheckIfEnemy failed: Friend is enemy");
        }



    }
}
