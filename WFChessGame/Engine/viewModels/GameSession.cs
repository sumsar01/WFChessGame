using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFChessGame.Models;

namespace WFChessGame.Engine.viewModels
{
    public static class GameSession
    {
        public static string playerTurn;

        static GameSession()
        {
            Board.NewGame();

            // Starting player white
            playerTurn = "1000";
        }

    }
}
