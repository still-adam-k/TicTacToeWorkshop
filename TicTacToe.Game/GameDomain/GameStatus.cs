namespace TicTacToe_Game.GameDomain
{
    public class GameStatus
    {
        public static implicit operator string(GameStatus v)
        {
            return v.ToString();
        }
    }
}
