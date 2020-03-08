using System.Collections.Generic;
using BattleShipGame.Elements.Player.Interface;

namespace BattleShipGame.GamePlay
{
    public class UserInput
    {
        public UserInput()
        {
            Player = new List<IPlayer>(2);
        }
        public int Height { get; set; }
        public int Width { get; set; }
        public int ShipCount { get; set; }
        public List<IPlayer> Player { get; set; }

    }
}