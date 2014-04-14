using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe_Game.GameDomain;

namespace TicTacToe_Game.Infrastructure
{
    public class TicTacToeComponent
    {
        private IGameRepository repository;

        public TicTacToeComponent()
        {
            this.repository = GameRepository.Create();
        }

        public int StartGame()
        {
            var game = new Game(repository.GetNextId());
            repository.Save(game);
            return game.Id;
        }

        public void PutMarkerOnField(int gameId, Field field)
        {
            var game = repository.GetGame(gameId);
            game.PutMarkerOnField(field);
            repository.Save(game);
        }

        public string GetGameStatus(int gameId)
        {
            var game = repository.GetGame(gameId);
            return game.GetGameCurrentStatus();
        }
    }
}
