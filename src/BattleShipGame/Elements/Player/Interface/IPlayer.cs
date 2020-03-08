using System.Collections.Generic;
using BattleShipGame.Elements.Area.Interface;

namespace BattleShipGame.Elements.Player.Interface
{
    public interface IPlayer
    {
        IBattleArea BattleArea { get; }
        Missile.Missile GetNextMissile { get; }
        List<Missile.Missile> Missiles { get; set; }
        string Name { get; set; }
    }
}