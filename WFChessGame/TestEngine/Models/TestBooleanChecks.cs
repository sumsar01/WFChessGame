using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFChessGame.Engine.Models;
using WFChessGame.Engine.viewModels;

namespace TestEngine.Models
{
    [TestClass]
    public class TestBooleanChecks
    {
        [TestMethod]
        public void TestCheckIfEnemy1()
        {
            Board board = new Board();
            board.FreshBoard();

            // Check if enemy is enemy
            int piecePos = 8;
            int enemyPos = 48;
            bool isEnemy = BooleanChecks.CheckIfEnemy(piecePos, enemyPos, board);

            Assert.IsTrue(isEnemy, "CheckIfEnemy failed: Enemy is not enemy");

        }

        [TestMethod]
        public void TestCheckIfEnemy2()
        {
            Board board = new Board();
            board.FreshBoard();

            // Check if friend is enemy
            int piecePos = 8;
            int enemyPos = 9;
            bool isEnemy = BooleanChecks.CheckIfEnemy(piecePos, enemyPos, board);

            Assert.IsFalse(isEnemy, "CheckIfEnemy failed: Friend is enemy");

        }

        [TestMethod]
        public void TestCheckIfEnemy3()
        {
            Board board = new Board();
            board.FreshBoard();

            // Check if empty square is enemy
            int piecePos = 8;
            int enemyPos = 16;
            bool isEnemy = BooleanChecks.CheckIfEnemy(piecePos, enemyPos, board);

            Assert.IsFalse(isEnemy, "CheckIfEnemy failed: Friend is enemy");
        }

        [TestMethod]
        public void TestIsBlackPiece()
        {
            Board board = new Board();
            board.FreshBoard();
            board.SetSquare(5, 18);
            board.SetSquare(8, 19);

            bool isBlack1 = BooleanChecks.IsBlackPiece(2, board);
            bool isBlack2 = BooleanChecks.IsBlackPiece(9, board);

            Assert.IsTrue(isBlack1);
            Assert.IsTrue(isBlack2);

        }

        [TestMethod]
        public void TestIsWhitePiece()
        {
            Board board = new Board();
            board.SetSquare(2, 9);
            board.SetSquare(9, 10);

            bool isWhite1 = BooleanChecks.IsWhitePiece(2, board);
            bool isWhite2 = BooleanChecks.IsWhitePiece(9, board);

            Assert.IsTrue(isWhite1);
            Assert.IsTrue(isWhite2);

        }


        [TestMethod]
        public void TestIsKing()
        {
            Board board = new Board();
            board.SetSquare(1, 9);
            int piece = board.GetSquare(1);

            bool isKing = BooleanChecks.IsKing(piece);
            
            Assert.IsTrue(isKing);
        }

        [TestMethod]
        public void TestCheckTurn()
        {
            Board board = new Board();
            board.playerTurn = "1000";
            board.SetSquare(1, 9);
            int piece = board.GetSquare(1);

            bool isTurn = BooleanChecks.CheckTurn(piece, board);

            Assert.IsTrue(isTurn);
        }
    }
}
