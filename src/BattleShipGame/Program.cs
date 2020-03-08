using BattleShipGame.Enums;
using BattleShipGame.Exceptions;
using BattleShipGame.GamePlay;
using BattleShipGame.Properties;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace BattleShipGame
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            var filePath = ConfiguationReader.GetValue(BatteShipGameKeys.InputPath);
            var startup = new Startup();
            try
            {
                startup.ReadInput(filePath);
                startup.InitiatePlay();
            }
            catch (BattleShipInputException k)
            {
                Console.WriteLine(Resources.Program_Main_Error_reading_game_input);
                Console.WriteLine(Resources.Program_Main_Error_detail___0_, k.Message);
                Console.WriteLine(Resources.Program_Main_Error_detail_inner___0_, k.InnerException?.Message);
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
