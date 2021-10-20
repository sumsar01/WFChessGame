using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFChessGame.Engine.Models;

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


        public static void ChangeTurn()
        {
            if(playerTurn == "1000")
            {
                playerTurn = "10000";
            }
            else if(playerTurn == "10000")
            {
                playerTurn = "1000";
            }
        }

    }
}
