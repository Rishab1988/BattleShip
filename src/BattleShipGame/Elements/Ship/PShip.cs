using BattleShipGame.Elements.Ship.Interfaces;

namespace BattleShipGame.Elements.Ship
{
    public class PShip : IShip
    {
        public int MaxHitCountPerCell => 1;
    }
}