using System.Collections.Generic;
using System.Linq;
using BattleShipGame.Elements.Area.Interface;
using BattleShipGame.Elements.Player.Interface;

namespace BattleShipGame.Elements.Player
{
    public class Player : IPlayer
    {
        public IBattleArea BattleArea { get; }

        public Player(IBattleArea battleArea)
        {
            BattleArea = battleArea;
        }

        public List<Missile.Missile> Missiles { get; set; }

        public virtual Missile.Missile GetNextMissile => Missiles.FirstOrDefault(x => x.IsFired == false);
    
        public string Name { get; set; }
    }
}