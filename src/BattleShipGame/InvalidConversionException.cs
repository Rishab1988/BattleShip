using System;

namespace BattleShipGame
{
    public class InvalidConversionException<T, U> : Exception
    {
        public Type TypeFrom { get; }
        public Type TypeTo { get; }


        public InvalidConversionException()  : this(string.Empty)
        {
          
        }

        public InvalidConversionException(string message) : base(message)
        {
            TypeFrom = typeof(T);
            TypeTo = typeof(T);
        }
        
    }
}