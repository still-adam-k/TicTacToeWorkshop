using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TicTacToe_Game;
using TicTacToe_Game.GameDomain;
using Xunit;
using Xunit.Extensions;

namespace TicTacToe_Test
{
    class MovesHelperExtension
    {
        public static IEnumerable<Field> InterleaveMoves(IEnumerable<Field> oneMoves, IEnumerable<Field> twoMoves)
        {
            var m1 = new List<Field>(oneMoves);
            var m2 = new List<Field>(twoMoves);

            var combinedMoves = new List<Field>();
            for (int i = 0; i < Math.Max(m1.Count, m2.Count); i++)
            {
                if (i < m1.Count)
                    combinedMoves.Add(m1[i]);
                if (i < m2.Count)
                    combinedMoves.Add(m2[i]);

                if (i >= m1.Count && i >= m2.Count)
                    break;
            }
            return combinedMoves;
        }

        public static IEnumerable<Field> CreateMovesForFieldsIndexed(params int[] fieldsIndexes)
        {
            var moves = new List<Field>();

            foreach (var i in fieldsIndexes)
            {
                moves.Add(new Field(i));
            }

            return moves;
        }

        public static IEnumerable<Field> CreateGameMoveSetWithPlayerOneMovesAtFields(params int[] fieldsIndexes)
        {
            var playerIndexes = fieldsIndexes;
            var complimentaryIndexes = Enumerable.Range(1, 9).Where(x => !playerIndexes.Contains(x)).ToArray();

            var playerMoves = CreateMovesForFieldsIndexed(playerIndexes);
            var complimentaryMoves = CreateGameMoveSetWithPlayerOneMovesAtFields(complimentaryIndexes);

            return InterleaveMoves(playerMoves, complimentaryMoves);
        }
    }



    public class TicTacToe_Tests
    {
        [Fact]
        public void After_creation_the_game_is_active()
        {
            var game = new Game(0);

            game.GetGameCurrentStatus().ShouldBeEquivalentTo("The game is on");
        }

        [Fact]
        public void Player_one_fills_top_horizontal_line__player_one_wins()
        {
            var playerOneMoves = MovesHelperExtension.CreateMovesForFieldsIndexed(1, 2, 3);
            var playerTwoMoves = MovesHelperExtension.CreateMovesForFieldsIndexed(4, 5);

            var moveList = MovesHelperExtension.InterleaveMoves(playerOneMoves, playerTwoMoves);

            var game = new Game(0);

            foreach (var move in moveList)
            {
                game = game.PutMarkerOnField(move);
            }

            game.GetGameCurrentStatus().ShouldBeEquivalentTo("Player One Wins");
        }

        [Fact]
        public void Player_two_fills_line_before_player_one__player_two_wins()
        {
            var playerOneMoves = MovesHelperExtension.CreateMovesForFieldsIndexed(4, 5, 7);
            var playerTwoMoves = MovesHelperExtension.CreateMovesForFieldsIndexed(1, 2, 3);

            var moveList = MovesHelperExtension.InterleaveMoves(playerOneMoves, playerTwoMoves);

            var game = new Game(0);

            foreach (var move in moveList)
            {
                game = game.PutMarkerOnField(move);
            }

            game.GetGameCurrentStatus().ShouldBeEquivalentTo("Player Two Wins");
        }

        [Fact]
        public void Player_one_fills_middle_horizontal_line__player_one_wins()
        {
            var playerOneMoves = MovesHelperExtension.CreateMovesForFieldsIndexed(4, 5, 6);
            var playerTwoMoves = MovesHelperExtension.CreateMovesForFieldsIndexed(1, 2);

            var moveList = MovesHelperExtension.InterleaveMoves(playerOneMoves, playerTwoMoves);

            var game = new Game(0);

            foreach (var move in moveList)
            {
                game = game.PutMarkerOnField(move);
            }

            game.GetGameCurrentStatus().ShouldBeEquivalentTo("Player One Wins");
        }

        [Fact]
        public void Player_one_fills_bottom_horizontal_line__player_one_wins()
        {
            var playerOneMoves = MovesHelperExtension.CreateMovesForFieldsIndexed(7, 8, 9);
            var playerTwoMoves = MovesHelperExtension.CreateMovesForFieldsIndexed(1, 2);

            var moveList = MovesHelperExtension.InterleaveMoves(playerOneMoves, playerTwoMoves);

            var game = new Game(0);

            foreach (var move in moveList)
            {
                game = game.PutMarkerOnField(move);
            }

            game.GetGameCurrentStatus().ShouldBeEquivalentTo("Player One Wins");
        }

        [Fact]
        public void Player_one_fills_left_vertical_line__player_one_wins()
        {
            var playerOneMoves = MovesHelperExtension.CreateMovesForFieldsIndexed(1, 4, 7);
            var playerTwoMoves = MovesHelperExtension.CreateMovesForFieldsIndexed(8, 9);

            var moveList = MovesHelperExtension.InterleaveMoves(playerOneMoves, playerTwoMoves);

            var game = new Game(0);

            foreach (var move in moveList)
            {
                game = game.PutMarkerOnField(move);
            }

            game.GetGameCurrentStatus().ShouldBeEquivalentTo("Player One Wins");
        }


        [Fact]
        public void Player_one_fills_middle_vertical_line__player_one_wins()
        {
            var playerOneMoves = MovesHelperExtension.CreateMovesForFieldsIndexed(2, 5, 8);
            var playerTwoMoves = MovesHelperExtension.CreateMovesForFieldsIndexed(7, 9);

            var moveList = MovesHelperExtension.InterleaveMoves(playerOneMoves, playerTwoMoves);

            var game = new Game(0);

            foreach (var move in moveList)
            {
                game = game.PutMarkerOnField(move);
            }

            game.GetGameCurrentStatus().ShouldBeEquivalentTo("Player One Wins");
        }

        [Fact]
        public void Player_one_fills_right_vertical_line__player_one_wins()
        {
            var playerOneMoves = MovesHelperExtension.CreateMovesForFieldsIndexed(3, 6, 9);
            var playerTwoMoves = MovesHelperExtension.CreateMovesForFieldsIndexed(7, 8);

            var moveList = MovesHelperExtension.InterleaveMoves(playerOneMoves, playerTwoMoves);

            var game = new Game(0);

            foreach (var move in moveList)
            {
                game = game.PutMarkerOnField(move);
            }

            game.GetGameCurrentStatus().ShouldBeEquivalentTo("Player One Wins");
        }

        [Fact]
        public void Player_one_fills_diagonal_line__player_one_wins()
        {
            var playerOneMoves = MovesHelperExtension.CreateMovesForFieldsIndexed(1, 5, 9);
            var playerTwoMoves = MovesHelperExtension.CreateMovesForFieldsIndexed(7, 8);

            var moveList = MovesHelperExtension.InterleaveMoves(playerOneMoves, playerTwoMoves);

            var game = new Game(0);

            foreach (var move in moveList)
            {
                game = game.PutMarkerOnField(move);
            }

            game.GetGameCurrentStatus().ShouldBeEquivalentTo("Player One Wins");
        }
    }
}
