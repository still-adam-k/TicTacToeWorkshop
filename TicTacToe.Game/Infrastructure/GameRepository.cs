using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TicTacToe_Game.GameDomain;

namespace TicTacToe_Game.Infrastructure
{
    class GameRepository : IGameRepository
    {
        private readonly string fileName = "MyStorage.txt";

        public GameRepository()
        {
            gamesList = new List<Game>();
        }

        private List<Game> gamesList { get; set; }

        public Game GetGame(int gameId)
        {
            return gamesList.First(game => game.Id == gameId);
        }

        public void Save(Game game)
        {
            gamesList.Add(game);
        }

        public int GetNextId()
        {
            if (gamesList.Any())
                return gamesList.Select(x => x.Id).Max() + 1;

            return 1;
        }
    }
}
