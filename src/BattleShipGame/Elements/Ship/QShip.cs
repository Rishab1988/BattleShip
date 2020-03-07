using BattleShipGame.Elements.Ship.Interfaces;

namespace BattleShipGame.Elements.Ship
{
    public class QShip : IShip
    {
        public int MaxHitCountPerCell => 2;
    }
}