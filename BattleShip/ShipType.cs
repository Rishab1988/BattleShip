using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BattleArea;

namespace BattleShip
{
    public interface IShipType
    {
        IEnumerable<BattleCell> BattleCell { get; set; }
        int KillShotPerCell { get;}

        
    }

    public class ShipTypeP : IShipType
    {
        public IEnumerable<BattleCell> BattleCell { get; set; }
        public int KillShotPerCell { get; } = 1;

      
    }

    public class ShipTypeQ : IShipType
    {
        public IEnumerable<BattleCell> BattleCell { get; set; }
        public int KillShotPerCell { get; } = 2;
    }
}
