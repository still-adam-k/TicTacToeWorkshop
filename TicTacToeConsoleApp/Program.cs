using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TicTacToe_Game.GameDomain;
using TicTacToe_Game.Infrastructure;

namespace TicTacToeConsoleApp
{

    public class OurTicTacToeApp
    {
        TicTacToeComponent ticTacToeService;

        public OurTicTacToeApp()
        {
            ticTacToeService = new TicTacToeComponent();
        }

        public void Run()
        {
            var gameId = ticTacToeService.StartGame();

            Console.WriteLine("Starting Game: " + gameId);

            Console.WriteLine("Board:");
            Console.WriteLine("0 | 1 | 2");
            Console.WriteLine("3 | 4 | 5");
            Console.WriteLine("6 | 7 | 8");

            string currentResponse;
            do
            {
                Console.WriteLine("Please input field:");
                var input = Console.ReadLine();

                var fieldIndex = Int32.Parse(input);

                ticTacToeService.PutMarkerOnField(gameId, new Field(fieldIndex));
                currentResponse = ticTacToeService.GetGameStatus(gameId);
                Console.WriteLine(currentResponse);

            } while (currentResponse.Contains("wins") == false);

            Console.WriteLine("Ending Game. Press Any Key...");
            Console.ReadLine();   
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var app = new OurTicTacToeApp();
            app.Run();
        }
    }
}
