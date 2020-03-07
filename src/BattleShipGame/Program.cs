using BattleShipGame.Enums;
using BattleShipGame.Exceptions;
using BattleShipGame.GamePlay;
using BattleShipGame.Properties;
using System;
using System.Linq;

namespace BattleShipGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = ConfiguationReader.GetValue(BatteShipGameKeys.InputPath);
            Startup startup = new Startup(filePath);
            try
            {
                if (!startup.ReadInput())
                    throw new Exception();

                startup.InitiatePlay();

            }
            catch (BattleShipException k)
            {
                Console.WriteLine(Resources.Program_Main_Validation_Errors);
                if (k.ValidationFailures != null && k.ValidationFailures.Any())
                {
                    foreach (var error in k.ValidationFailures)
                    {
                        Console.WriteLine(Resources.Program_Main_Error_Code___0_, error.ErrorCode);
                    }
                }
            }
            catch (Exception k)
            {
                Console.WriteLine(k);
            }

            Console.ReadLine();
        }
    }
}
