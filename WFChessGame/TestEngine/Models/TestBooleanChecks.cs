using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFChessGame.Engine.Models;
using WFChessGame.Engine.viewModels;

namespace TestEngine.Models
{
    [TestClass]
    public class TestBooleanChecks
    {
        BooleanChecksBaseClass booleanChecksBaseClass;
        Board board;

        TestBooleanChecks()
        {
            booleanChecksBaseClass = new BooleanChecksBaseClass();
            Board board = new Board();
        }

        [TestMethod]
        public void TestCheckIfEnemy1()
        {
            board.FreshBoard();

            // Check if enemy is enemy
            int piecePos = 8;
            int enemyPos = 48;
            bool isEnemy = booleanChecksBaseClass.CheckIfEnemy(piecePos, enemyPos, board);

            Assert.IsTrue(isEnemy, "CheckIfEnemy failed: Enemy is not enemy");

        }

        [TestMethod]
        public void TestCheckIfEnemy2()
        {
            board.FreshBoard();

            // Check if friend is enemy
            int piecePos = 8;
            int enemyPos = 9;
            bool isEnemy = booleanChecksBaseClass.CheckIfEnemy(piecePos, enemyPos, board);

            Assert.IsFalse(isEnemy, "CheckIfEnemy failed: Friend is enemy");

        }

        [TestMethod]
        public void TestCheckIfEnemy3()
        {
            board.FreshBoard();

            // Check if empty square is enemy
            int piecePos = 8;
            int enemyPos = 16;
            bool isEnemy = booleanChecksBaseClass.CheckIfEnemy(piecePos, enemyPos, board);

            Assert.IsFalse(isEnemy, "CheckIfEnemy failed: Friend is enemy");
        }

        [TestMethod]
        public void TestIsBlackPiece()
        {
            board.FreshBoard();
            board.SetSquare(5, 18);
            board.SetSquare(8, 19);

            bool isBlack1 = booleanChecksBaseClass.IsBlackPiece(2, board);
            bool isBlack2 = booleanChecksBaseClass.IsBlackPiece(9, board);

            Assert.IsTrue(isBlack1);
            Assert.IsTrue(isBlack2);

        }

        [TestMethod]
        public void TestIsWhitePiece()
        {
            board.SetSquare(2, 9);
            board.SetSquare(9, 10);

            bool isWhite1 = booleanChecksBaseClass.IsWhitePiece(2, board);
            bool isWhite2 = booleanChecksBaseClass.IsWhitePiece(9, board);

            Assert.IsTrue(isWhite1);
            Assert.IsTrue(isWhite2);

        }


        [TestMethod]
        public void TestIsKing()
        {
            board.SetSquare(1, 9);
            int piece = board.GetSquare(1);

            bool isKing = booleanChecksBaseClass.IsKing(piece);
            
            Assert.IsTrue(isKing);
        }

        [TestMethod]
        public void TestCheckTurn()
        {
            board.playerTurn = "1000";
            board.SetSquare(1, 9);
            int piece = board.GetSquare(1);

            bool isTurn = booleanChecksBaseClass.CheckTurn(piece, board);

            Assert.IsTrue(isTurn);
        }
    }
}
