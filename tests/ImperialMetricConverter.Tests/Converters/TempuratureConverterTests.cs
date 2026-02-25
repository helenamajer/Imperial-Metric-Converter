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
    }
}
