using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BattleShipGame.Elements.Area;
using BattleShipGame.Elements.Area.Interface;
using BattleShipGame.Elements.Missile;
using BattleShipGame.Elements.Ship;
using BattleShipGame.Extensions;
using BattleShipGame.Properties;

namespace BattleShipGame.GamePlay
{
    public class Startup
    {
        private readonly UserInput _userInput;
        private readonly string _filePath;

        public Startup(string filePath)
        {
            _filePath = filePath;
            _userInput = new UserInput();
        }

        public bool ReadInput()
        {
            if (string.IsNullOrEmpty(_filePath) || !File.Exists(_filePath))
            {
                Console.WriteLine(Resources.Startup_ReadInput_No_valid_input_file_found_at____0_, _filePath);
                return false;
            }

            IEnumerable<string> lines = File.ReadAllLines(_filePath);
            var x = lines.ElementAt(0).Split(' ');
            _userInput.Width = x.ElementAt(0).ToColumn();
            _userInput.Height = x.ElementAt(1).ToRows();
            _userInput.ShipCount = Convert.ToInt32(lines.ElementAt(1));




            _userInput.Player = new List<Player>
            {
                new Player(new BattleArea(new CreateArea
                {
                    Column = _userInput.Width,
                    Row = _userInput.Height
                })),
                new Player(new BattleArea(new CreateArea
                {
                    Column = _userInput.Width,
                    Row = _userInput.Height
                }))
            };



            for (var i = 0; i < _userInput.ShipCount; i++)
            {
                var shipData = lines.ElementAt(2 + i).Split(' ');
                _userInput.Player[0].BattleArea.AddShip(new AddShip(
                    ShipFactory.GetShip(shipData[0]), shipData[1].ToHeightOrWidth(), shipData[2].ToHeightOrWidth()
                    , shipData[3].ToCell().Column, shipData[3].ToCell().Row));

                _userInput.Player[1].BattleArea.AddShip(new AddShip(
                    ShipFactory.GetShip(shipData[0]), shipData[1].ToHeightOrWidth(), shipData[2].ToHeightOrWidth()
                    , shipData[4].ToCell().Column, shipData[4].ToCell().Row));

            }

            _userInput.Player[0].Missiles = lines.ElementAt(lines.Count() - 2).Split(' ').Select(m => new Missile(m.ToCell()));
            _userInput.Player[1].Missiles = lines.ElementAt(lines.Count() - 1).Split(' ').Select(m => new Missile(m.ToCell()));

            return true;


        }

        public void InitiatePlay()
        {
            var p1M = _userInput.Player[0].Missiles.ToList();
            var p2M = _userInput.Player[1].Missiles.ToList();

            while ((p1M.Exists(x => x.IsFired == false) || p2M.Exists(x => x.IsFired == false)))
            {
                if (_userInput.Player[0].BattleArea.IsDestroyed || _userInput.Player[1].BattleArea.IsDestroyed)
                    break;
                Player1Fire(p1M);
                if (_userInput.Player[0].BattleArea.IsDestroyed || _userInput.Player[1].BattleArea.IsDestroyed)
                    break;
                Player2Fire(p2M);
            }

            if (!_userInput.Player[0].BattleArea.IsDestroyed && !_userInput.Player[1].BattleArea.IsDestroyed)
                Console.WriteLine(Resources.Startup_InitiatePlay_Game_has_ended_in_draw);

        }

        private void Player1Fire( List<Missile> p1M)
        {
            while (true)
            {
                if (_userInput.Player[1].BattleArea.IsDestroyed)
                {
                    Console.WriteLine(Resources.Startup_Player1Fire_Player_1_won_the_battle);
                    break;
                }


                if (!p1M.Exists(x => x.IsFired == false))
                {
                    Console.WriteLine(Resources.Startup_Player1Fire_Player_1_has_no_more_missiles_left_to_launch);
                }
                else
                {
                    var cell = p1M.First(x => x.IsFired == false).Cell;
                    p1M.First(x => x.IsFired == false).IsFired = true;
                    if (_userInput.Player[1].BattleArea.Strike(cell) == Enums.HitAcknowledgement.Hit)
                    {
                        Console.WriteLine(Resources.Startup_Player1Fire_Player_1_fires_a_missile_with_target__0__which_got_hit, cell.ToCoordinates());
                        continue;
                    }
                    Console.WriteLine(Resources.Startup_Player1Fire_Player_1_fires_a_missile_with_target__0__which_got_miss, cell.ToCoordinates());
                }

                break;
            }
        }

        private void Player2Fire(List<Missile> p2M)
        {

            while (true)
            {
                if (_userInput.Player[0].BattleArea.IsDestroyed)
                {
                    Console.WriteLine(Resources.Startup_Player2Fire_Player_2_won_the_battle);
                    break;
                }

                if (!p2M.Exists(x => x.IsFired == false))
                {
                    Console.WriteLine(Resources.Startup_Player2Fire_Player_2_has_no_more_missiles_left_to_launch);
                }
                else
                {
                    var cell = p2M.First(x => x.IsFired == false).Cell;
                    p2M.First(x => x.IsFired == false).IsFired = true;
                    if (_userInput.Player[0].BattleArea.Strike(cell) == Enums.HitAcknowledgement.Hit)
                    {
                        Console.WriteLine(Resources.Startup_Player2Fire_Player_2_fires_a_missile_with_target__0__which_got_hit, cell.ToCoordinates());
                        continue;
                    }
                    Console.WriteLine(Resources.Startup_Player2Fire_Player_2_fires_a_missile_with_target__0__which_got_miss, cell.ToCoordinates());
                }

                break;
            }
        }
    }
}