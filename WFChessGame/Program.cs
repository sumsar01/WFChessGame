using System;
using WFChessGame.Engine.viewModels;
using System.Windows.Forms;

namespace WFChessGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GameSession gameSession = new GameSession();
            gameSession.NewGame();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(gameSession));
        }
    }
}
