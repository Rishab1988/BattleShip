namespace BattleShipGame
{
    public class Player
    {
        public IBattleArea BattleArea { get; }

        public Player(IBattleArea battleArea)
        {
            BattleArea = battleArea;
        }
    }
}