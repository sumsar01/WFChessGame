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
            Board board = new Board();
            board.ClearBoard();
            GameSession.playerTurn = "1000";
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
            Board board = new Board();
            board.ClearBoard();
            GameSession.playerTurn = "10000";
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
            Board board = new Board();
            board.ClearBoard();
            GameSession.playerTurn = "1000";
            List<int> enemyMoves = new List<int>();
            List<int> enemy1 = new List<int>();
            List<int> enemy2 = new List<int>();
            List<int> enemy3 = new List<int>();

            // Set black pieces
            board.SetSquare(9, 17);
            board.SetSquare(11, 18);
            board.SetSquare(13, 19);
            enemy1 = WFChessGame.Engine.Models.Moves.GetPseudoLegalMoves(17, 9);
            enemy2 = WFChessGame.Engine.Models.Moves.GetPseudoLegalMoves(18, 11);
            enemy3 = WFChessGame.Engine.Models.Moves.GetPseudoLegalMoves(19, 13);

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
            Board board = new Board();
            board.ClearBoard();
            GameSession.playerTurn = "10000";
            List<int> enemyMoves = new List<int>();
            List<int> enemy1 = new List<int>();
            List<int> enemy2 = new List<int>();
            List<int> enemy3 = new List<int>();

            // Set black pieces
            board.SetSquare(9, 10);
            board.SetSquare(11, 11);
            board.SetSquare(13, 12);
            enemy1 = WFChessGame.Engine.Models.Moves.GetPseudoLegalMoves(10, 9);
            enemy2 = WFChessGame.Engine.Models.Moves.GetPseudoLegalMoves(11, 11);
            enemy3 = WFChessGame.Engine.Models.Moves.GetPseudoLegalMoves(12, 13);

            enemyMoves = CheckMate.GenerateAllEnemyMoves();

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
            Board.ClearBoard();
            GameSession.playerTurn = "1000";

            Board.SetSquare(0, Piece.White | Piece.King);
            Board.SetSquare(1, Piece.Black | Piece.Queen);


            bool isMate = CheckMate.Mate();

            Assert.IsTrue(isMate);
        }

        [TestMethod]
        public void TestMate2()
        {
            Board.ClearBoard();
            GameSession.playerTurn = "10000";

            Board.FreshBoard();
            Board.SetSquare(10, Piece.None);
            Board.SetSquare(3, Piece.Black | Piece.King);
            Board.SetSquare(17, Piece.Black | Piece.Pawn);
            Board.SetSquare(24, Piece.White | Piece.Queen);

            bool isMate = CheckMate.Mate();

            Assert.IsFalse(isMate);
        }

        [TestMethod]
        public void TestFutureMate()
        {
            Board.ClearBoard();
            GameSession.playerTurn = "10000";

            Board.FreshBoard();
            Board.CopyBoard(FutureBoard.futureSquare);
            FutureBoard.SetSquare(10, Piece.None);
            FutureBoard.SetSquare(3, Piece.Black | Piece.King);
            FutureBoard.SetSquare(17, Piece.Black | Piece.Pawn);
            FutureBoard.SetSquare(24, Piece.White | Piece.Queen);

            bool isMate = CheckMate.FutureMate();

            Assert.IsFalse(isMate);
        }
    }
}
