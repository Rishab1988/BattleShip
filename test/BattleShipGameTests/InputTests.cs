using System.Collections.Generic;
using System.Linq;
using BattleShipGame.Exceptions;
using BattleShipGame.GamePlay;
using Xunit;

namespace BattleShipGameTests
{

    public class InputTests
    {
        private Startup _startup;


        [Fact]
        public void Should_Throw_BattleShipInputException_InvalidPath()
        {
            //Arrange
            _startup = new Startup();

            // Assert
            Assert.Throws<BattleShipInputException>(() => _startup.ReadInput("InvalidPath.txt"));
        }

        [Fact]
        public void Should_Throw_BattleShipInputException_On_InValid_Data()
        {
            // Arrange
            _startup = new Startup();

            // Assert
            Assert.Throws<BattleShipInputException>(() => _startup.ReadInputData(new List<string>()));
        }

        [Fact]
        public void Should_Throw_BattleShipValidationException_On_InvalidAreaData()
        {
            // Arrange
            _startup = new Startup();

            // Assert
            Assert.Throws<BattleShipValidationException>(() => _startup.ReadInputData(new List<string> { "-1 8" }));
        }

        [Fact]
        public void Should_Create_Valid_Game_Elements_Valid_Input()
        {
            // Arrange
            _startup = new Startup();
            var data = new List<string>()
            {
                "5 E",
                "2",
                "Q 1 1 A1 B2",
                "P 2 1 D4 C3",
                "A1 B2 B2 B3",
                "A1 B2 B3 A1 D1 E1 D4 D4 D5 D5"
            };

            // Act
            _startup.ReadInputData(data);
            var result = _startup.UserInput;

            // Assert
            Assert.True(result.ShipCount == 2);
            Assert.True(result.Player.Count == 2);
            Assert.True(result.Player.ElementAt(0).BattleArea.GetArea.GetLength(0) == 5);

        }

    }
}
