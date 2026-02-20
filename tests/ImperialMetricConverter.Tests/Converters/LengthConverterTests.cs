using ImperialMetricConverter.Converters;
using Xunit;

/*
* First test as an example.
* Convert 1 inch to cm.
*/

// namespace defines a group of related code (classes, objects, interfaces, etc.)
namespace ImperialMetricConverter.Tests.Converters
{
    // defines a test class
    public class LengthConverterTests
    {
        // 'Fact' attribute tells Xunit to run this test.
        [Fact]
        // test method naming style: Method_Condition_Expectation
        public void ConvertInchesToCentimeters_WhenGiven1Inch_Returns2Point54()
        {
            // creating an instance of the class to test.
            // var instructs the compiler to infer the type based on the value assigned.
            var converter = new LengthConverter();

            // now we call the method under test and pass in 1 (inch), representing the condition.
            // the output is stored in result.
            var result = converter.InchesToCentimeters(1);

            // the assertion, a boolean expression, verifies the output by comparing (expected, actual).
            Assert.Equal(2.54, result);

        }

        [Fact]
        public void InchesToCentimeters_WhenGiven2Inches_Returns5Point08()
        {
            var converter = new LengthConverter();

            var result = converter.InchesToCentimeters(2);

            Assert.Equal(5.08, result);
            
        }
    }
}