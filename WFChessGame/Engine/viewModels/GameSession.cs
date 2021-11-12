using WFChessGame.Engine.Models;

namespace WFChessGame.Engine.viewModels
{
    public class GameSession
    {
        public bool WhiteMate;
        public bool BlackMate;
        public Board board;
        public Turn turn;

        public GameSession()
        {
            board = new Board();
            turn = new Turn();
        }

        public void NewGame()
        {
            board.FreshBoard();
            // Starting player white.
            // The turn is represented by the string value of the int representing the color.
            board.playerTurn = "1000";
            // None of the kings are in danger
            WhiteMate = false;
            BlackMate = false;
        }
    }
}
