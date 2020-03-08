using BattleShipGame.Enums;
using BattleShipGame.Exceptions;
using BattleShipGame.GamePlay;
using BattleShipGame.Properties;
using System;
using System.Linq;

namespace BattleShipGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var filePath = ConfiguationReader.GetValue(BatteShipGameKeys.InputPath);
            var startup = new Startup(filePath);
            try
            {
                startup.ReadInput();
                startup.InitiatePlay();
            }
            catch (BattleShipValidationException k)
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
