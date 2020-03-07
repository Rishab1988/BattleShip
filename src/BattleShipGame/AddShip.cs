namespace BattleShipGame
{
    public class AddShip
    {
        public IShip Ship { get; }
        public int Height { get; }
        public int Width { get; }
        public int Column { get; }
        public int Row { get; }

        public BattleCell[,] GetCells(BattleCell[,] battleCells)
        {
            for (int i = 0; i <= Height; i++)
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