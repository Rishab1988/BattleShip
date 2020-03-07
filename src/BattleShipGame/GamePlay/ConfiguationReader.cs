using System;
using System.Configuration;
using BattleShipGame.Enums;

namespace BattleShipGame.GamePlay
{
    public static class ConfiguationReader
    {
        public static string GetValue(BatteShipGameKeys batteShipGameKeys)
        {
            switch (batteShipGameKeys)
            {
                case BatteShipGameKeys.InputPath:
                    return ConfigurationManager.AppSettings[BatteShipGameKeys.InputPath.ToString()];
                default:
                    throw new InvalidOperationException("Not a valid key");
            }
        }

    }
}