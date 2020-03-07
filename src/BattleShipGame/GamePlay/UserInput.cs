using System.Collections.Generic;

namespace BattleShipGame.GamePlay
{
    public class UserInput
    {
        public UserInput()
        {
            Player = new List<Player>(2);
        }
        public int Height { get; set; }
        public int Width { get; set; }
        public int ShipCount { get; set; }
        public List<Player> Player { get; set; }

    }
}