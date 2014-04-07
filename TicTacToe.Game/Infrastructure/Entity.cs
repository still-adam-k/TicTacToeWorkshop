using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Game.Infrastructure
{
    public class Entity
    {
        public Entity(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }
    }
}
