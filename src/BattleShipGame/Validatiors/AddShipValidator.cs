using BattleShipGame.Elements.Cell;
using BattleShipGame.Elements.Ship;
using BattleShipGame.Elements.Ship.Interface;
using FluentValidation;

namespace BattleShipGame.Validatiors
{
    public class AddShipValidator : AbstractValidator<IAddShip>
    {
        public AddShipValidator(BattleCell[,] battleCells)
        {
            RuleFor(x => x.Row).GreaterThanOrEqualTo(0).LessThanOrEqualTo(battleCells.GetLength(0))
                .WithErrorCode("ASV001");
            RuleFor(x => x.Column).GreaterThanOrEqualTo(0).LessThanOrEqualTo(battleCells.GetLength(1))
                .WithErrorCode("ASV002");
            RuleFor(x => x.Row + x.Height).GreaterThanOrEqualTo(0).LessThanOrEqualTo(battleCells.GetLength(0))
                .WithErrorCode("ASV003");
            RuleFor(x => x.Column + x.Width).GreaterThanOrEqualTo(0).LessThanOrEqualTo(battleCells.GetLength(0))
                .WithErrorCode("ASV004");

            RuleFor(x => x).Must((x) => {

                for(var i = 0; i<= x.Height;i++)
                {
                    if (battleCells[x.Row + i, x.Column].HasShip)
                        return false;
                }
                for (var i = 0; i <= x.Width; i++)
                {
                    if (battleCells[x.Row, x.Column+i].HasShip)
                        return false;
                }

                return true;
            }).WithErrorCode("ASV005");
           
        }
    }
}