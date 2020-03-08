using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame.Exceptions
{
    public class BattleShipInputException: Exception
    {
        public BattleShipInputException(string message) : this(message, null)
        {
            
        }

        public BattleShipInputException(string message, Exception innerExcption) : base(message,innerExcption)
        {

        }
    }
}
