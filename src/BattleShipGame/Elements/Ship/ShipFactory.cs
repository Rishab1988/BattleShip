using System;
using BattleShipGame.Elements.Ship.Interface;

namespace BattleShipGame.Elements.Ship
{
    public class ShipFactory
    {
        public static IShip GetShip(string type)
        {
            switch (type.ToUpper())
            {
                case "P":
                    return new PShip();
                case "Q":
                    return new QShip();
                default:
                    throw new InvalidOperationException("No ship type");
            }
        }
    }
}
