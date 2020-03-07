using System.Collections.Generic;
using BattleShipGame.Elements.Area.Interface;
using BattleShipGame.Elements.Missile;
using BattleShipGame.Elements.Ship;

namespace BattleShipGame
{
    public class Player
    {
        public IBattleArea BattleArea { get; }

        public Player(IBattleArea battleArea)
        {
            BattleArea = battleArea;
        }

        public IEnumerable<Missile> Missiles { get; set; }
    }
}