using BattleShipGame.Elements.Area;
using FluentValidation;

namespace BattleShipGame.Validatiors
{
    public class CreateAreaValidator : AbstractValidator<CreateArea>
    {
        public CreateAreaValidator()
        {
            RuleFor(x => x.Column).GreaterThanOrEqualTo(0).LessThanOrEqualTo(8).WithErrorCode("CAV001");
            RuleFor(x => x.Row).GreaterThanOrEqualTo(0).LessThanOrEqualTo(25).WithErrorCode("CAV002");
        }
    }
}