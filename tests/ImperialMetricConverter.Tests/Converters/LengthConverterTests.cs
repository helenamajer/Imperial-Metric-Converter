using ImperialMetricConverter.Converters;
using Xunit;

/*
* Test suite for units of length conversion.
*
*
* First test as an example.
* Convert 1 inch to cm.
*/

// namespace defines a group of related code (classes, objects, interfaces, etc.).
namespace ImperialMetricConverter.Tests.Converters
{
    // defines a test class.
    public class LengthConverterTests
    {
        // 'Fact' attribute tells Xunit to run this test.
        [Fact]
        // test converting 1 inch to 2.54 centimeters.
        // test method naming style: Method_Condition_Expectation.
        public void Convert_WhenConverting1InchToCentimeters_Returns2Point54()
        {
            // creating an instance of the class to test.
            // var instructs the compiler to infer the type based on the value assigned.
            var converter = new LengthConverter();

            // now we call the method under test and pass in 1 (inch), representing the condition.
            // the output is stored in result.
            var result = converter.Convert(1, LengthUnit.Inch, LengthUnit.Centimeter);

            // the assertion, a boolean expression, verifies the output by comparing (expected, actual).
            Assert.Equal(2.54, result);

        }

        [Fact]
        // Test converting 2 inches to 5.08 centimeters.
        public void Convert_WhenConverting2InchesToCentimeters_Returns5Point08()
        {
            var converter = new LengthConverter();

            // pass in value 2 (inches).
            var result = converter.Convert(2, LengthUnit.Inch, LengthUnit.Centimeter);

            // expected result: 5.08.
            Assert.Equal(5.08, result);
            
        }

        [Fact]
        // Negative numbers should not be accpeted; negative length does not exist.
        public void Convert_WhenGivenNegativeValue_ThrowsArgumentException()
        {
            var converter = new LengthConverter();

            Assert.Throws<ArgumentException>(() => converter.Convert(-1, LengthUnit.Inch, LengthUnit.Centimeter));
        }

        [Fact]
        // Reversing the conversion. Now converting 1 Centimeter into inches.
        public void Convert_WhenConverting1CentimeterToInches_Return0Point3937()
        {
            var converter = new LengthConverter();

            var result = converter.Convert(1, LengthUnit.Centimeter, LengthUnit.Inch);

            // (expected, actual, decimal value).
            Assert.Equal(0.3937, result, 4);
        }

        [Fact]
        // When the conversion units are the same, return the input value.
        public void Convert_WhenToAndFromAreSameUnit_ReturnSameValue()
        {
            var converter = new LengthConverter();

            var inchResult = converter.Convert(1, LengthUnit.Inch, LengthUnit.Inch);
            var cmResult = converter.Convert(1, LengthUnit.Centimeter, LengthUnit.Centimeter);

            Assert.Equal(1, inchResult);
            Assert.Equal(1, cmResult);
        }

        [Fact]
        // Convert 1 foot to the base unit (meters).
        public void Convert_1FootToMeters_Returns0Point3048()
        {
            var converter = new LengthConverter();

            var result = converter.Convert(1, LengthUnit.Foot, LengthUnit.Meter);

            Assert.Equal(0.3048, result, 4);
        }

        [Fact]
        // Convert 1 yard to the base unit (meters).
        public void Convert_1YardToMeters_Returns0Point9144()
        {
            var converter = new LengthConverter();

            var result = converter.Convert(1, LengthUnit.Yard, LengthUnit.Meter);

            Assert.Equal(0.9144, result, 4);
        }

        [Fact]
        // Converting 1 mile to the base unit (meters).
        public void Convert_1MileToMeters_Returns1609Point34()
        {
            var converter = new LengthConverter();

            var result = converter.Convert(1, LengthUnit.Mile, LengthUnit.Meter);

            Assert.Equal(1609.34, result, 2);
        }

        [Fact]
        // Converting 1 kilometer to the base unit (meters).
        public void Convert_1KilometerToMeters_Returns1000()
        {
            var converter = new LengthConverter();

            var result = converter.Convert(1, LengthUnit.Kilometer, LengthUnit.Meter);

            Assert.Equal(1000, result);
        }
    }
}