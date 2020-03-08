using System.ComponentModel;
using BattleShipGame.Elements.Cell;
using BattleShipGame.Elements.Ship.Interface;

namespace BattleShipGame.Elements.Ship
{
    public class AddShip : IAddShip
    {
        public IShip Ship { get; }
        public int Height { get; }
        public int Width { get; }
        [ReadOnly(true)]
        public int Column { get; set; }
        [ReadOnly(true)]
        public int Row { get; set; }

        public AddShip(IShip ship, int width, int height, int column, int row)
        {
            Ship = ship;
            Height = height;
            Width = width;
            Column = column;
            Row = row;
        }

        public virtual BattleCell[,] GetCells(BattleCell[,] battleCells)
        {
            for (var i = 0; i <= Height; i++)
            {
                battleCells[Row + i, Column].Ship = Ship;
            }
            for (var i = 0; i <= Width; i++)
            {
                battleCells[Row, Column + i].Ship = Ship;
            }
            return battleCells;
        }
    }
}