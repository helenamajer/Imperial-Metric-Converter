using ImperialMetricConverter.Converters;
using Xunit;

/*
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
        // test converting 1 inch to 2.54 centimeters/
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
        public void Convert_WhenConverting1CentimeterToInches_Return0Point39()
        {
            var converter = new LengthConverter();

            var result = converter.Convert(1, LengthUnit.Centimeter, LengthUnit.Inch);

            // (expected, actual, decimal value)
            Assert.Equal(0.3937, result, 4);
        }

    }
}