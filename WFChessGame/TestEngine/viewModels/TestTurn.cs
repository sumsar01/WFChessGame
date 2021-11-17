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
        List<int> moves;

        [TestInitialize]
        public void Initalize()
        {
            board = new Board();
            futureBoard = new Board();
            moveGenerator = new MoveGenerator();
            turn = new Turn();
            checkMate = new CheckMate();
            moves = new List<int>();
        }

        [TestMethod]
        public void TestGetLegalMoves1()
        {
            board.playerTurn = "10000";

            board.FreshBoard();
            board.SetSquare(10, Piece.None);
            board.SetSquare(24, Piece.White | Piece.Queen);


            moves = turn.GetLegalMoves(Piece.Black | Piece.Pawn, 9, board);


            Assert.IsTrue(moves.Contains(17));
            Assert.IsFalse(moves.Contains(25));
        }

        [TestMethod]
        public void TestGetLegalMoves2()
        {
            board.playerTurn = "1000";

            board.SetSquare(0, Piece.Black | Piece.Rook);
            board.SetSquare(9, Piece.White | Piece.King);


            moves = turn.GetLegalMoves(Piece.White | Piece.King, 9, board);


            Assert.IsTrue(moves.Contains(0));
            Assert.IsTrue(moves.Contains(10));
            Assert.IsTrue(moves.Contains(18));
            Assert.IsTrue(moves.Contains(17));
            Assert.IsFalse(moves.Contains(1));
            Assert.IsFalse(moves.Contains(2));
            Assert.IsFalse(moves.Contains(8));
            Assert.IsFalse(moves.Contains(16));
        }

        [TestMethod]
        public void TestGetLegalMoves3()
        {
            board.playerTurn = "1000";

            board.SetSquare(28, Piece.Black | Piece.Pawn);
            board.SetSquare(44, Piece.White | Piece.King);


            moves = turn.GetLegalMoves(Piece.White | Piece.King, 9, board);

            Assert.IsFalse(moves.Contains(35));
            Assert.IsFalse(moves.Contains(37));

        }

        [TestMethod]
        public void TestGenerateAllLegalMoves1()
        {
            board.playerTurn = "10000";
            List<int> allLegalMoves = new List<int>();

            board.FreshBoard();
            board.SetSquare(10, Piece.None);
            board.SetSquare(24, Piece.White | Piece.Queen);

            allLegalMoves = turn.GenerateAllLegalMoves(board);

            Assert.IsTrue(allLegalMoves.Contains(17));

        }

        [TestMethod]
        public void TestIsCheckMate()
        {
            board.playerTurn = "10000";


            board.SetSquare(0, Piece.Black | Piece.King);
            board.SetSquare(17, Piece.White | Piece.Queen);
            board.SetSquare(16, Piece.White | Piece.Queen);

            bool isCheckMate = turn.IsCheckMate(board);

            Assert.IsTrue(isCheckMate);

        }

        [TestMethod]
        public void TestGetLegalMovesExtra()
        {
            List<int> LegalMoves = new List<int>();
            List<int> enemyMoves = new List<int>();
            board.playerTurn = "1000";
            int piece = Piece.White | Piece.King;
            int location = 44;

            board.SetSquare(28, Piece.Black | Piece.Pawn);
            board.SetSquare(location, piece);

            moves.Add(35);
            moves.Add(37);



            foreach (int move in moves)
            {
                futureBoard.ClearBoard();
                futureBoard.CopyBoard(board);
                futureBoard.SetSquare(move, piece);
                futureBoard.SetSquare(location, 0);


                enemyMoves = checkMate.GenerateAllEnemyMoves(futureBoard);
                //enemyMoves = moveGenerator.GetEnemyMoves(0, futureBoard);
                
                
                for(int i = 0; i < 64; ++i)
                {
                    if (i % 8 == 0) Console.WriteLine("");
                    if(futureBoard.GetSquare(i) != 0) Console.Write(String.Format("{0,2} ", futureBoard.GetSquare(i)));
                    else if (enemyMoves.Contains(i)) Console.Write(String.Format("{0,2} ", 1));
                    else Console.Write(String.Format("{0,2} ", 0));

                }

                Console.WriteLine(checkMate.Mate(futureBoard));
                Console.WriteLine("");
                

                if (checkMate.Mate(futureBoard) != true)
                {
                    LegalMoves.Add(move);
                }
            }


            Assert.IsFalse(LegalMoves.Contains(35));
            Assert.IsFalse(LegalMoves.Contains(37));
        }
    }
}
