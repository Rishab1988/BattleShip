using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BattleArea
{
    public class BattleArea
    {
        public BattleCell[,] BattleCells { get;}

        public BattleArea(int rows, int columns)
        {
            BattleCells = new BattleCell[rows, columns];
        }

        public bool IsOccupied(BattleCell battleCell)
        {
            return BattleCells[battleCell.Row, battleCell.Column].IsOccupied;
        }

        private void SetOccupied(IEnumerable<BattleCell> battleCells, IShipType battleShip)
        {
            foreach (var battleCell in battleCells)
            {
                BattleCells[battleCell.Row, battleCell.Column].IsOccupied = true;
                BattleCells[battleCell.Row, battleCell.Column].BattleShip = battleShip;
            }
        }



        public void AddShip(IShipType battleShip, int rows, int columns,  BattleCell battleCell)
        {
            var cells = GetCells(battleShip, rows, columns, battleCell).ToList();
            battleShip.BattleCell = cells;
            SetOccupied(cells, battleShip);
        }

        private IEnumerable<BattleCell> GetCells(IShipType battleShip, int rows, int columns, BattleCell battleCell)
        {
            var battleCells = new List<BattleCell>();
            for (var i = 0; i < rows; i++)
            {
                var cell = new BattleCell(battleCell.Row + i, battleCell.Column);
                if (IsOccupied(cell))
                {
                    throw new InvalidOperationException("Overlapping ship");
                }
                battleCells.Add(cell);
            }
            for (var i = 0; i < columns; i++)
            {
                var cell = new BattleCell(battleCell.Row, battleCell.Column + i);
                if (IsOccupied(cell))
                {
                    throw new InvalidOperationException("Overlapping ship");
                }
                battleCells.Add(cell);
            }

            return battleCells;
        }
    }
}
