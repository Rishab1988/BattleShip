using System;
using System.Linq;
using BattleShipGame.Elements.Area.Interface;
using BattleShipGame.Elements.Cell;
using BattleShipGame.Elements.Ship.Interface;
using BattleShipGame.Enums;
using BattleShipGame.Exceptions;
using BattleShipGame.Validators;

namespace BattleShipGame.Elements.Area
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
                throw new BattleShipValidationException(results.Errors);
            }

            _area = new BattleCell[cell.Row+1, cell.Column+1];

            for (var i = 0; i <= cell.Row; i++)
            for (var j = 0; j <= cell.Column; j++)
                _area[i, j] = new BattleCell();

            _addShipValidator = new AddShipValidator(_area);
        }

        public virtual BattleCell[,] GetArea
        {
            get
            {
                var tempArray = new BattleCell[_area.GetLength(0), _area.GetLength(1)];
                Array.Copy(_area, tempArray, _area.Length);
                return tempArray;
            }
        }

        public virtual void AddShip(IAddShip addShip)
        {
            var results = _addShipValidator.Validate(addShip);
            if (!results.IsValid)
            {
                throw new BattleShipValidationException(results.Errors);
            }
            _area = addShip.GetCells(_area);
        }

        public virtual HitAcknowledgement Strike(Cell.Cell cell)
        {
            if (!_area[cell.Row,cell.Column].HasShip)
                return HitAcknowledgement.Miss;

            if (_area[cell.Row,cell.Column].HitCount >= _area[cell.Row, cell.Column].Ship.MaxHitCountPerCell)
                return HitAcknowledgement.Destroyed;

            _area[cell.Row, cell.Column].HitCount++;
            return HitAcknowledgement.Hit;
        }

        public virtual bool IsDestroyed
        {
            get
            {   
                    for (var i = 0; i < _area.GetLength(0); i++)
                    for (var j = 0; j < _area.GetLength(1); j++)
                    {
                        if (_area[i, j].HasShip && _area[i, j].HitCount < _area[i, j].Ship.MaxHitCountPerCell)
                            return false;
                    }

                    return true;
            }
        }

    }
}