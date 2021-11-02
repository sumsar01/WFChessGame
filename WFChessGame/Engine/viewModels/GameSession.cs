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
        public static bool WhiteMate;
        public static bool BlackMate;

        static GameSession()
        {
            Board.NewGame();
            // Starting player white.
            // The turn is represented by the string value of the int representing the color.
            playerTurn = "1000";
            // None of the kings are in danger
            WhiteMate = false;
            BlackMate = false;
        }

        
        public static void ChangeTurn()
        {
            /// <summary>
            /// Change turn players turn.
            /// </summary>
            if (playerTurn == "1000")
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
