using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipGame
{
    public static class StringExtensions
    {
        public static int ToRows(this char character)
        {
            try
            {
                if (Int32.TryParse(character.ToString().ToUpper(), out int i))
                {
                    return i - 66;
                }
                throw new InvalidConversionException<char, int>("Cannot convert");
            }
            catch
            {
                throw new InvalidConversionException<char, int>("Cannot convert Invalid Value");
            }
            
        }

        public static int ToColumn(this int i)
        {
            try
            {
                return --i;
            }
            catch
            {
                throw new InvalidConversionException<int, int>("Cannot convert");
            }
        }

        public static int ToHeightOrWidth(this int i)
        {
            try
            {
                return --i;
            }
            catch
            {
                throw new InvalidConversionException<int, int>("Cannot convert");
            }
        }
    }
}
