using System;

namespace BattleShipGame.Exceptions
{
    public class InvalidConversionException<T, TU> : Exception
    {
        public Type TypeFrom { get; }
        public Type TypeTo { get; }


        public InvalidConversionException()  : this(string.Empty)
        {
          
        }

        public InvalidConversionException(string message) : base(message)
        {
            TypeFrom = typeof(T);
            TypeTo = typeof(TU);
        }
        
    }
}