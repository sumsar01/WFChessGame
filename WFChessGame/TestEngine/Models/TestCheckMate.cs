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
        Board board;
        CheckMate checkMate;
        MoveGenerator moveGenerator;

        TestCheckMate()
        {
            board = new Board();
            checkMate = new CheckMate();
            moveGenerator = new MoveGenerator();
        }

        [TestMethod]
        public void TestGenerateEnemyPositions1()
        {
            board.ClearBoard();
            board.playerTurn = "1000";
            List<int> movesToGet = new List<int>();
            int pos1 = 1;
            int pos2 = 5;
            int pos3 = 8;

            int wrongpos1 = 2;
            int wrongpos2 = 9;

            // Set black pieces
            board.SetSquare(1, 17);
            board.SetSquare(5, 18);
            board.SetSquare(8, 19);

            // set white pieces
            board.SetSquare(2, 9);
            board.SetSquare(9, 6);

            movesToGet = checkMate.GenerateEnemyPositions(movesToGet, board);

            Assert.IsTrue(movesToGet.Contains(pos1));
            Assert.IsTrue(movesToGet.Contains(pos2));
            Assert.IsTrue(movesToGet.Contains(pos3));

            Assert.IsFalse(movesToGet.Contains(wrongpos1));
            Assert.IsFalse(movesToGet.Contains(wrongpos2));
        }

        [TestMethod]
        public void TestGenerateEnemyPositions2()
        {
            board.ClearBoard();
            board.playerTurn = "10000";
            List<int> movesToGet = new List<int>();
            int wrongpos1 = 1;
            int wrongpos2 = 5;
            int wrongpos3 = 8;

            int pos1 = 2;
            int pos2 = 9;

            // Set black pieces
            board.SetSquare(1, 17);
            board.SetSquare(5, 18);
            board.SetSquare(8, 19);

            // set white pieces
            board.SetSquare(2, 9);
            board.SetSquare(9, 10);

            movesToGet = checkMate.GenerateEnemyPositions(movesToGet, board);

            Assert.IsFalse(movesToGet.Contains(wrongpos1));
            Assert.IsFalse(movesToGet.Contains(wrongpos2));
            Assert.IsFalse(movesToGet.Contains(wrongpos3));

            Assert.IsTrue(movesToGet.Contains(pos1));
            Assert.IsTrue(movesToGet.Contains(pos2));
        }

        [TestMethod]
        public void TestGenerateAllEnemyMoves1()
        {
            board.ClearBoard();
            board.playerTurn = "1000";
            List<int> enemyMoves = new List<int>();
            List<int> enemy1 = new List<int>();
            List<int> enemy2 = new List<int>();
            List<int> enemy3 = new List<int>();

            // Set black pieces
            board.SetSquare(9, 17);
            board.SetSquare(11, 18);
            board.SetSquare(13, 19);
            enemy1 = moveGenerator.GetPseudoLegalMoves(17, 9, board);
            enemy2 = moveGenerator.GetPseudoLegalMoves(18, 11, board);
            enemy3 = moveGenerator.GetPseudoLegalMoves(19, 13, board);

            enemyMoves = checkMate.GenerateAllEnemyMoves(board);


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
            board.ClearBoard();
            board.playerTurn = "10000";
            List<int> enemyMoves = new List<int>();
            List<int> enemy1 = new List<int>();
            List<int> enemy2 = new List<int>();
            List<int> enemy3 = new List<int>();

            // Set black pieces
            board.SetSquare(9, 10);
            board.SetSquare(11, 11);
            board.SetSquare(13, 12);
            enemy1 = moveGenerator.GetPseudoLegalMoves(10, 9, board);
            enemy2 = moveGenerator.GetPseudoLegalMoves(11, 11, board);
            enemy3 = moveGenerator.GetPseudoLegalMoves(12, 13, board);

            enemyMoves = checkMate.GenerateAllEnemyMoves(board);

            for (int i = 0; i < 64; ++i)
            {
                if (i % 8 == 0) Console.WriteLine("");
                if (enemyMoves.Contains(i)) Console.Write(String.Format("{0,2} ", 1));
                else Console.Write(String.Format("{0,2} ", board.GetSquare(i)));
            }

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
        public void TestMate1()
        {
            board.ClearBoard();
            board.playerTurn = "1000";

            board.SetSquare(0, Piece.White | Piece.King);
            board.SetSquare(1, Piece.Black | Piece.Queen);


            bool isMate = checkMate.Mate(board);

            Assert.IsTrue(isMate);
        }

        [TestMethod]
        public void TestMate2()
        {
            board.ClearBoard();
            board.playerTurn = "10000";

            board.FreshBoard();
            board.SetSquare(10, Piece.None);
            board.SetSquare(3, Piece.Black | Piece.King);
            board.SetSquare(17, Piece.Black | Piece.Pawn);
            board.SetSquare(24, Piece.White | Piece.Queen);

            bool isMate = checkMate.Mate(board);

            Assert.IsFalse(isMate);
        }
    }
}
