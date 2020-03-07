using BattleShipGame.Elements.Ship;
using BattleShipGame.Enums;

namespace BattleShipGame.Elements.Area.Interface
{
    public interface IBattleArea
    {
        void AddShip(AddShip addShip);
        bool IsDestroyed { get; }
        HitAcknowledgement Strike(Cell.Cell cell);
    }
}