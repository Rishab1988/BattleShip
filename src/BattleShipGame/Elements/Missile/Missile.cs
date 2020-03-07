namespace BattleShipGame.Elements.Missile
{
    public class Missile : Cell.Cell
    {
        public bool IsFired { get; set; } = false;

        public Missile(Cell.Cell cell)
        {
            Column = cell.Column;
            Row = cell.Row;
        }

        public Cell.Cell Cell => new Cell.Cell {Column = Column, Row = Row};
    }
}