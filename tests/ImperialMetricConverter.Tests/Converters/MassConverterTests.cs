using ImperialMetricConverter.Converters;
using Xunit;

/*
* Test suite for mass conversion.
*/
namespace ImperialMetricConverter.Tests.Converters
{
    public class MassConverterTests()
    {
        [Fact]
        // Converting 1 pound to 0.4536 kilograms.
        public void Convert_1PoundToKilograms_Returns0Point4536()
        {
            var converter = new MassConverter();

            var result = converter.Convert(1, MassUnit.Pound, MassUnit.Kilogram);

            Assert.Equal(0.4536, result, 4);
        }

        [Fact]
        // Converting 1 Kilogram to 2.2046 pounds.
        public void Convert_1KilogramToPounds_Returns2Point2046()
        {
            var converter = new MassConverter();

            var result = converter.Convert(1, MassUnit.Kilogram, MassUnit.Pound);

            Assert.Equal(2.2046, result, 4);
        }
    }
}