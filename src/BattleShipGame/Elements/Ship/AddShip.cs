using BattleShipGame.Elements.Cell;
using BattleShipGame.Elements.Ship.Interfaces;

namespace BattleShipGame.Elements.Ship
{
    public class AddShip
    {
        public IShip Ship { get; }
        public int Height { get; }
        public int Width { get; }
        public int Column { get; }
        public int Row { get; }

        public AddShip(IShip ship, int width, int height, int column, int row)
        {
            Ship = ship;
            Height = height;
            Width = width;
            Column = column;
            Row = row;
        }

        public BattleCell[,] GetCells(BattleCell[,] battleCells)
        {
            for (var i = 0; i <= Height; i++)
            {
                battleCells[Row + i, Column].Ship = Ship;
            }
            for (int i = 0; i <= Width; i++)
            {
                battleCells[Row, Column + i].Ship = Ship;
            }
            return battleCells;
        }
    }
}