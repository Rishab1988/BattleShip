using BattleShipGame.Elements.Ship;
using BattleShipGame.Elements.Ship.Interfaces;
using BattleShipGame.Enums;

namespace BattleShipGame.Elements.Cell
{
    public class BattleCell
    {
        public int HitCount { get; set; } = 0;
        public virtual bool HasShip => Ship != null;

        

        public IShip Ship { get; set; }
    }
}
