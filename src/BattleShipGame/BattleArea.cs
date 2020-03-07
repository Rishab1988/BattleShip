using BattleShipGame.Validations;

namespace BattleShipGame
{
    public class BattleArea : IBattleArea
    {
        private BattleCell[,] _area;
        private readonly AddShipValidator _addShipValidator;

        public BattleArea(CreateArea cell)
        {
            var createAreaValidator = new CreateAreaValidator();
           

            var results = createAreaValidator.Validate(cell);
            if (!results.IsValid)
            {
                throw new BattleShipException(results.Errors);
            }

            _area = new BattleCell[cell.Row, cell.Column];
            _addShipValidator = new AddShipValidator(_area);
        }

        public virtual void AddShip(AddShip addShip)
        {
            var results = _addShipValidator.Validate(addShip);
            if (!results.IsValid)
            {
                throw new BattleShipException(results.Errors);
            }
            _area = addShip.GetCells(_area);
        }
    }
}