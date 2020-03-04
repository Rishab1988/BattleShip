using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BattleArea
{
    public class BattleCell
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public bool IsOccupied { get; set; }

        public BattleCell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public IShipType BattleShip { get; set; }

    }

    public class BattleShipArea
    {

    }
}
