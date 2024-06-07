using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeral.Utilities
{
    public class RomanNumeralConverter
    {
        #region Fields
        private static readonly Dictionary<int, string> RomanNumeralsDict = new()
        {
                { 1000, "M" }, { 900, "CM" }, { 500, "D" },
                { 400, "CD" }, { 100, "C" }, { 90, "XC" },
                { 50, "L" }, { 40, "XL" },  { 10, "X" },
                { 9, "IX" }, { 5, "V" }, { 4, "IV" }, { 1, "I" }
        };
        #endregion

        #region Public Methods
        //Task 1
        public string NumberToRoman(int number)
        {
            if (!IsWithinAllowedRange(number))
                throw new ArgumentOutOfRangeException("Input must be between 1 and 3999");

            return NumberToRomanNumeral(number);
        }
        //Task 2
        public int RomanToNumber(string value)
        {
            if (!IsOnlyLetters(value))
                throw new ArgumentException("Input must contain only alphabetic characters.");

            return RomanNumeralToNumber(value);
        }
        #endregion


        #region Private Methods
        private bool IsWithinAllowedRange(int number)
        {
            return number >= 1 && number <= 3999;
        }
        private bool IsOnlyLetters(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            return value.All(char.IsLetter);
        }
        private string NumberToRomanNumeral(int number)
        {
            StringBuilder romanNumeral = new StringBuilder();

            foreach (KeyValuePair<int, string> pair in RomanNumeralsDict)
            {
                while (number >= pair.Key)
                {
                    number -= pair.Key;
                    romanNumeral.Append(pair.Value);
                }
            }

            return romanNumeral.ToString();
        }
        private int RomanNumeralToNumber(string value)
        {
            int number = 0;
            int length = value.Length;

            for (int i = 0; i < length; i++)
            {

                int currentValue = RomanNumeralsDict.FirstOrDefault(x => x.Value == value[i].ToString()).Key;


                if (i + 1 < length)
                {
                    int nextValue = RomanNumeralsDict.FirstOrDefault(x => x.Value == value[i + 1].ToString()).Key;


                    if (currentValue < nextValue)
                    {
                        number -= currentValue;
                    }

                    else
                    {
                        number += currentValue;
                    }
                }
                else
                {

                    number += currentValue;
                }
            }
            return number;
        }

        #endregion
    }
}
