using System;
using BattleShipGame.Elements.Cell;
using BattleShipGame.Exceptions;

namespace BattleShipGame.Extensions
{
    public static class BattleCellExtensions
    {
        public static int ToRows(this string character)
        {
            try
            {
                var a = Convert.ToChar(character.ToUpper());
                return Convert.ToInt32(a) - 65;
            }
            catch
            {
                throw new InvalidConversionException<string, int>("Cannot convert Invalid Value");
            }

        }

        public static string ToCoordinates(this Cell cell)
        {
            return Convert.ToChar(cell.Row + 65) + Convert.ToString(cell.Column + 1);
        }

        public static Cell ToCell(this string coordinates)
        {
            try
            {
                var a = coordinates.ToCharArray();
                var cell = new Cell
                {
                    Row = a[0].ToString().ToRows(),
                    Column = a[1].ToString().ToColumn()
                };
                return cell;
            }
            catch
            {
                throw new InvalidConversionException<string, Cell>("Cannot convert");
            }
        }

        public static int ToColumn(this string i)
        {
            try
            {
                var k = Convert.ToInt32(i);
                return --k;
            }
            catch
            {
                throw new InvalidConversionException<int, int>("Cannot convert");
            }
        }

        public static int ToHeightOrWidth(this string i)
        {
            try
            {
                var k = Convert.ToInt32(i);
                return --k;
            }
            catch
            {
                throw new InvalidConversionException<int, int>("Cannot convert");
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
