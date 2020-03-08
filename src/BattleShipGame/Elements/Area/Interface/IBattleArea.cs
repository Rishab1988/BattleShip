﻿using BattleShipGame.Elements.Ship;
using BattleShipGame.Elements.Ship.Interface;
using BattleShipGame.Enums;

namespace BattleShipGame.Elements.Area.Interface
{
    public interface IBattleArea
    {
        void AddShip(IAddShip addShip);
        bool IsDestroyed { get; }
        HitAcknowledgement Strike(Cell.Cell cell);
    }
}