using TicTacToe_Game.GameDomain;

namespace TicTacToe_Game.Infrastructure
{
    public interface IGameRepository
    {
        Game GetGame(int gameId);
        void Save(Game game);
        int GetNextId();
    }
}