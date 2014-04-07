using System;
using TicTacToe_Game.Infrastructure;

namespace TicTacToe_Game.GameDomain
{
    public class Game : Entity
    {
        public Game(int id)
            :base(id)
        {   
        }

        public Game PutMarkerOnField(Field moveToPlay)
        {
            throw new NotImplementedException();
        }

        public GameStatus GetGameCurrentStatus()
        {
            throw new NotImplementedException();   
        }
    }
}
