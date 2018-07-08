using System;
using System.Collections.Generic;

namespace OopPrinciplesTraining
{
    /// <summary>
    /// Defines the functionality for obtaining a representation of a number in the decimal format
    /// </summary>
    public static class DecimalConverter
    {
        private static SortedList<char, int> list = new SortedList<char, int>()
        {
            { '0', 0 },
            { '1', 1 },
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
            { 'A', 10 },
            { 'B', 11 },
            { 'C', 12 },
            { 'D', 13 },
            { 'E', 14 },
            { 'F', 15 }
        };

        #region ToDecimal Method
        /// <summary>
        /// Retrieves information from a string and converts it to the decimal number format using given radix
        /// </summary>
        /// <param name="numberString"> The string representing a number in the given radix </param>
        /// <param name="radix"> The given radix </param>
        /// <returns> The decimal number representing an initial string number </returns>
        /// <exception cref="ArgumentNullException"> Thrown when <param name="numberString"> is null </exception>
        /// <exception cref="ArgumentException"> Thrown when <param name="numberString"> contains invalid characters </exception>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when <param name="radix"> is out of the range from 2 to 16 </exception>
        /// <exception cref="OverflowException"> Thrown when a number from the initial string exceeds limitation of System.Int32 type </exception>
        public static int ToDecimal(this string numberString, int radix)
        {
            ValidateRadix(radix);
            ValidateNumberString(numberString, radix);

            int temp = 0;
            string upperString = numberString.ToUpper();

            for (int i = 0; i < upperString.Length; i++)
            {
                int value = list[upperString[i]];
                temp = checked((temp * radix) + value);
            }

            return temp;
        }
        #endregion

        #region Private Helper Methods
        private static void ValidateNumberString(string numberString, int radix)
        {
            if (numberString == null)
            {
                throw new ArgumentNullException(nameof(numberString));
            }
            else
            {
                char[] stringDigits = new char[radix];
                IList<char> listKeys = list.Keys;
                string upperString = numberString.ToUpper();

                for (int i = 0; i < stringDigits.Length; i++)
                {
                    stringDigits[i] = listKeys[i];
                }

                foreach (var character in upperString)
                {
                    if (Array.IndexOf(stringDigits, character, 0, radix) < 0)
                    {
                        throw new ArgumentException(nameof(numberString));
                    }
                }
            }
        }

        private static void ValidateRadix(int radix)
        {
            if (radix > 16 || radix < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(radix));
            }
        }
        #endregion
    }
}