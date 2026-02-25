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
    }
}
