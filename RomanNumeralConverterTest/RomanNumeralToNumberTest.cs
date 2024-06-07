using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumeral.Test
{
    public class RomanNumeralToNumberTest
    {
        private RomanNumeralConverter _converter;

        [SetUp]
        public void Setup()
        {
            //set up
            _converter = new RomanNumeralConverter();
        }
        [TestCase("MMMCMXCIX", 3999)]
        [TestCase("MDCLXVI", 1666)]
        public void Convert_ValidRomanNumeral_ReturnsExpectedNumber(string romanNumeral, int number)
        {
           //Act
            int result = _converter.RomanToNumber(romanNumeral);

           //Assert
            Assert.AreEqual(number, result);
        }

        [TestCase("123456")]
        [TestCase("MD1236")]
        public void Convert_InvalidString_ThrowsArgumentException(string value)
        {

            //Act & Assert
            Assert.Throws<ArgumentException>(() => _converter.RomanToNumber(value));
        }
        [TestCase("UX")]
        [TestCase("MDU")]
        public void Convert_InvalidRomanNumeralFormat_ThrowsArgumentException(string value)
        {

            //Act & Assert
            Assert.Throws<ArgumentException>(() => _converter.RomanToNumber(value));
        }
    }
}
