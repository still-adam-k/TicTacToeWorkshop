using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicTacToe_Game.GameDomain;
using TicTacToe_Game.Infrastructure;
using WebFrontEnd.Models;

namespace WebFrontEnd.Controllers
{
    public class TicTacToeController : ApiController
    {
        private TicTacToeComponent ticTacToe;

        public TicTacToeController()
        {
            ticTacToe = new TicTacToeComponent();
        }

        public int GetNewGame()
        {
            return ticTacToe.StartGame();
        }

        public void PostMove(MoveModel move)
        {
            ticTacToe.PutMarkerOnField(move.GameId, new Field(move.MoveToMake));
        }
    }
}
