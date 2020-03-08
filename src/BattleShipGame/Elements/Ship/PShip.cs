using BattleShipGame.Elements.Ship.Interface;

namespace BattleShipGame.Elements.Ship
{
    public class PShip : IShip
    {
        public int MaxHitCountPerCell => 1;
    }
}