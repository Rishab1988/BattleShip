using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BattleShipGame.Elements.Area;
using BattleShipGame.Elements.Missile;
using BattleShipGame.Elements.Player;
using BattleShipGame.Elements.Player.Interface;
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



            _userInput.Player = new List<IPlayer>
            {
                new Player(new BattleArea(new CreateArea
                {
                    Column = _userInput.Width,
                    Row = _userInput.Height
                })){ Name = "Player-1", Missiles = lines.ElementAt(lines.Count() - 2).Split(' ').Select(m => new Missile(m.ToCell())).ToList()},
                new Player(new BattleArea(new CreateArea
                {
                    Column = _userInput.Width,
                    Row = _userInput.Height
                })){ Name = "Player-2", Missiles = lines.ElementAt(lines.Count() - 1).Split(' ').Select(m => new Missile(m.ToCell())).ToList()}
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

            return true;
        }


        public void InitiatePlay()
        {
            var player1 = _userInput.Player[0];
            var player2 = _userInput.Player[1];
            while (player1.GetNextMissile != null || player2.GetNextMissile != null)
            {
                if (Fire(player1, player2))
                    return;
                if (Fire(player2, player1))
                    return;
            }
            Console.WriteLine(Resources.Startup_InitiatePlay_Game_has_ended_in_draw);
        }

        private static bool Fire(IPlayer player1, IPlayer player2)
        {
            var missile = player1.GetNextMissile;
            if (missile == null)
            {
                Console.WriteLine(Resources.Startup_Fire__0__has_no_more_missiles_left_to_launch, player1.Name);
                return false;
            }

            missile.IsFired = true;
            if (player2.BattleArea.Strike(missile.Cell) != Enums.HitAcknowledgement.Hit)
            {
                Console.WriteLine(Resources.Startup_Fire__0__fires_a_missile_with_target__1__which_got_miss, player1.Name, missile.Cell.ToCoordinates());
                return false;
            }

            Console.WriteLine(Resources.Startup_Fire__0__fires_a_missile_with_target__1__which_got_hit, player1.Name, missile.Cell.ToCoordinates());
            if (player2.BattleArea.IsDestroyed)
            {
                Console.WriteLine(Resources.Startup_Fire__0__won_the_battle, player1.Name);
                return true;
            }

            Fire(player1, player2);

            return false;
        }
    }
}