using BattleShipGame.Elements.Ship.Interface;

namespace BattleShipGame.Elements.Ship
{
    public class QShip : IShip
    {
        public int MaxHitCountPerCell => 2;
    }
}