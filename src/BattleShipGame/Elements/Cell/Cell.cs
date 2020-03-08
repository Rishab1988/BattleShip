using BattleShipGame.Elements.Cell.Interface;

namespace BattleShipGame.Elements.Cell
{
    public class Cell : ICell
    {
        public int Column { get; set; }
        public int Row { get; set; }
    }
}