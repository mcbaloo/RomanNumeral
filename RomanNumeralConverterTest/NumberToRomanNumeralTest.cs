namespace RomanNumeral.Test
{
    [TestFixture]
    public class NumberToRomanNumeralTest
    {
        private RomanNumeralConverter _converter;

        [SetUp]
        public void Setup()
        {
            //set up
            _converter = new RomanNumeralConverter();
        }
        [TestCase(1666, "MDCLXVI")]
        [TestCase(3999, "MMMCMXCIX")]
        public void Convert_ValidNumbers_ReturnsExpectedRomanNumeral(int number, string expectedRomanNumeral)
        {
            // Act
            string result = _converter.NumberToRoman(number);

            // Assert
            Assert.AreEqual(expectedRomanNumeral, result);
        }

        [TestCase(0)]
        [TestCase(4000)]
        public void Convert_InvalidNumber_ThrowsArgumentOutOfRangeException(int number)
        {


            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _converter.NumberToRoman(number));
        }
    }
}