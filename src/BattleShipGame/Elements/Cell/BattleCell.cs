using BattleShipGame.Elements.Ship.Interface;

namespace BattleShipGame.Elements.Cell
{
    public class BattleCell
    {
        public int HitCount { get; set; } = 0;
        public virtual bool HasShip => Ship != null;
        public IShip Ship { get; set; }
    }
}
