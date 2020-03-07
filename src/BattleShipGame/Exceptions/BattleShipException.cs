using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace BattleShipGame.Exceptions
{
    public class BattleShipException : Exception
    {
        public IEnumerable<ValidationFailure> ValidationFailures { get; }
        public BattleShipException(IEnumerable<ValidationFailure> validationFailures)
        {
            this.ValidationFailures = validationFailures;
        }
    }
}