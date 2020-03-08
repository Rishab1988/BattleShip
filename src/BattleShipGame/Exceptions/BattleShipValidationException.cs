using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace BattleShipGame.Exceptions
{
    public class BattleShipValidationException : Exception
    {
        public IEnumerable<ValidationFailure> ValidationFailures { get; }
        public BattleShipValidationException(IEnumerable<ValidationFailure> validationFailures)
        {
            this.ValidationFailures = validationFailures;
        }
    }
}