using Microsoft.VisualStudio.TestTools.UnitTesting;
using WFChessGame.Engine.Models;
using WFChessGame.Engine.viewModels;
using System.Collections.Generic;
using System;

namespace TestEngine.viewModels
{
    [TestClass]
    public class TestTurn
    {
        Board board;
        Board futureBoard;
        MoveGenerator moveGenerator;
        Turn turn;
        CheckMate checkMate;

        TestTurn()
        {
            board = new Board();
            futureBoard = new Board();
            moveGenerator = new MoveGenerator();
            turn = new Turn();
            checkMate = new CheckMate();
        }

        [TestMethod]
        public void TestGetLegalMoves1()
        {
            List<int> moves = new List<int>();
            board.playerTurn = "10000";

            board.FreshBoard();
            board.SetSquare(10, Piece.None);
            board.SetSquare(24, Piece.White | Piece.Queen);


            moves = turn.GetLegalMoves(Piece.Black | Piece.Pawn, 9, board);


            Assert.IsTrue(moves.Contains(17));
        }

        [TestMethod]
        public void TestGetLegalMoves2()
        {
            Board board = new Board();
            List<int> moves = new List<int>();
            List<int> LegalMoves = new List<int>();
            List<int> enemyMoves = new List<int>();
            board.playerTurn = "10000";
            int piece = Piece.Black | Piece.Pawn;
            int location = 9;

            board.FreshBoard();
            board.SetSquare(10, Piece.None);
            board.SetSquare(24, Piece.White | Piece.Queen);



            moves.Add(17);


            foreach (int move in moves)
            {
                board.FreshBoard();
                futureBoard.CopyBoard(board);
                futureBoard.SetSquare(move, piece);
                futureBoard.SetSquare(location, 0);


                enemyMoves = checkMate.GenerateAllEnemyMoves(board);

                for (int i = 0; i < 64; ++i)
                {
                    if (i % 8 == 0) Console.WriteLine("");
                    if (enemyMoves.Contains(i)) Console.Write(String.Format("{0,2} ", 1));
                    else Console.Write(String.Format("{0,2} ", futureBoard.GetSquare(i)));
                }

                Console.WriteLine("");

                for (int i = 0; i < 64; ++i)
                {
                    if (i % 8 == 0) Console.WriteLine("");
                    if (board.GetSquare(i) != 0) Console.Write(String.Format("{0,2} ", futureBoard.GetSquare(i)));
                    else if (enemyMoves.Contains(i)) Console.Write(String.Format("{0,2} ", 1));
                    else Console.Write(String.Format("{0,2} ", futureBoard.GetSquare(i)));
                }

                if (checkMate.Mate(futureBoard) != true)
                {
                    LegalMoves.Add(move);
                }
            }


            Assert.IsTrue(LegalMoves.Contains(17));
        }
    }
}
