using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFChessGame.Engine.Models;
using WFChessGame.Engine.viewModels;
using System.Collections.Generic;
using System;

namespace TestEngine.Models
{
    [TestClass]
    public class TestCheckMate
    {
        [TestMethod]
        public void TestGenerateEnemyPositions1()
        {
            Board.ClearBoard();
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

        [TestMethod]
        public void TestGenerateEnemyPositions2()
        {
            Board.ClearBoard();
            GameSession.playerTurn = "10000";
            List<int> movesToGet = new List<int>();
            int wrongpos1 = 1;
            int wrongpos2 = 5;
            int wrongpos3 = 8;

            int pos1 = 2;
            int pos2 = 9;

            // Set black pieces
            Board.SetSquare(1, 17);
            Board.SetSquare(5, 18);
            Board.SetSquare(8, 19);

            // set white pieces
            Board.SetSquare(2, 9);
            Board.SetSquare(9, 10);

            movesToGet = CheckMate.GenerateEnemyPositions(movesToGet);

            Assert.IsFalse(movesToGet.Contains(wrongpos1));
            Assert.IsFalse(movesToGet.Contains(wrongpos2));
            Assert.IsFalse(movesToGet.Contains(wrongpos3));

            Assert.IsTrue(movesToGet.Contains(pos1));
            Assert.IsTrue(movesToGet.Contains(pos2));
        }

        [TestMethod]
        public void TestGenerateAllEnemyMoves1()
        {
            Board.ClearBoard();
            GameSession.playerTurn = "1000";
            List<int> enemyMoves = new List<int>();
            List<int> enemy1 = new List<int>();
            List<int> enemy2 = new List<int>();
            List<int> enemy3 = new List<int>();

            // Set black pieces
            Board.SetSquare(9, 17);
            Board.SetSquare(11, 18);
            Board.SetSquare(13, 19);
            enemy1 = Turn.GetMoves(17, 9);
            enemy2 = Turn.GetMoves(18, 11);
            enemy3 = Turn.GetMoves(19, 13);

            enemyMoves = CheckMate.GenerateAllEnemyMoves();

            foreach (int move in enemy1)
            {
                Assert.IsTrue(enemyMoves.Contains(move));
            }

            foreach (int move in enemy2)
            {
                Assert.IsTrue(enemyMoves.Contains(move));
            }

            foreach (int move in enemy3)
            {
                Assert.IsTrue(enemyMoves.Contains(move));
            }
        }


        [TestMethod]
        public void TestGenerateAllEnemyMoves2()
        {
            Board.ClearBoard();
            GameSession.playerTurn = "10000";
            List<int> enemyMoves = new List<int>();
            List<int> enemy1 = new List<int>();
            List<int> enemy2 = new List<int>();
            List<int> enemy3 = new List<int>();

            // Set black pieces
            Board.SetSquare(9, 10);
            Board.SetSquare(11, 11);
            Board.SetSquare(13, 12);
            enemy1 = Turn.GetMoves(10, 9);
            enemy2 = Turn.GetMoves(11, 11);
            enemy3 = Turn.GetMoves(12, 13);

            enemyMoves = CheckMate.GenerateAllEnemyMoves();

            foreach (int move in enemy1)
            {
                Assert.IsTrue(enemyMoves.Contains(move));
            }

            foreach (int move in enemy2)
            {
                Assert.IsTrue(enemyMoves.Contains(move));
            }

            foreach (int move in enemy3)
            {
                Assert.IsTrue(enemyMoves.Contains(move));
            }
        }


        [TestMethod]
        public void TestMate()
        {
            Board.ClearBoard();
            GameSession.playerTurn = "1000";

            Board.SetSquare(0, Piece.White | Piece.King);
            Board.SetSquare(1, Piece.Black | Piece.Queen);

            List<int> enemyMoves = CheckMate.GenerateAllEnemyMoves();

            bool isMate = CheckMate.Mate();

            Assert.IsTrue(isMate);
        }
    }
}
