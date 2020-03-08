using BattleShipGame.Elements.Cell;
using BattleShipGame.Elements.Cell.Interface;

namespace BattleShipGame.Elements.Ship.Interface
{
    public interface IAddShip : ICell
    {
        int Height { get; }
        IShip Ship { get; }
        int Width { get; }

        BattleCell[,] GetCells(BattleCell[,] battleCells);
    }
}