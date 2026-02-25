using ImperialMetricConverter.Converters;
using Xunit;

/*
* Test suite for celsius an fahrenheit conversion.
*/
namespace ImperialMetricConverter.Tests.Converters
{
    public class TempuratureConverterTests
    {
        [Fact]
        // converting 0C to 32F.
        public void Convert_0CelsiusToFahrenheit_Returns32Degrees()
        {
            var converter = new TempConverter();

            var result = converter.Convert(0, TempUnit.Celsius, TempUnit.Fahrenheit);

            Assert.Equal(32, result);
        }

        [Fact]
        // converting 32F to 0C.
        public void Convert_32FahrenheitToCelsius_Returns0Degrees()
        {
            var converter = new TempConverter();

            var result = converter.Convert(32, TempUnit.Fahrenheit, TempUnit.Celsius);

            Assert.Equal(0, result);
        }

        [Fact]
        // converting Non-zero values. converting 100C to 212F.
        public void Convert_100CelsiusToFahrenheit_Returns212Degrees()
        {
            var converter = new TempConverter();

            var result = converter.Convert(100, TempUnit.Celsius, TempUnit.Fahrenheit);

            Assert.Equal(212, result);
        }

        [Fact]
        // converting same units like C to C and F to F returns the same input value.
        public void Convert_SameToAndFromUnit_ReturnsSameValue()
        {
            var converter = new TempConverter();

            var resultC = converter.Convert(1, TempUnit.Celsius, TempUnit.Celsius);
            var resultF = converter.Convert(1, TempUnit.Fahrenheit, TempUnit.Fahrenheit);

            Assert.Equal(1, resultC);
            Assert.Equal(1, resultF);
        }

        [Fact]
        // converting negative values. -40C to -40F.
        public void Convert_Negative40CelsiusToFahrenheit_ReturnsNegative40Degrees()
        {
            var converter = new TempConverter();

            var result = converter.Convert(-40, TempUnit.Celsius, TempUnit.Fahrenheit);

            Assert.Equal(-40, result);
        }

        [Fact]
        // converting floating point values. 1C to 33.8F
        public void Convert_1CelsiusToFahrenheit_Returns33Point8()
        {
            var converter = new TempConverter();

            var result = converter.Convert(1, TempUnit.Celsius, TempUnit.Fahrenheit);

            Assert.Equal(33.8, result);
        }
    }
}
