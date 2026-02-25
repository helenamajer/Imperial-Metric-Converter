using Moq;
using Xunit;
using ImperialMetricConverter.UI;
using ImperialMetricConverter.Services;
using ImperialMetricConverter.Converters;

/*
* Test suite for console user interface .
*/
namespace ImperialMetricConverter.Tests.UI
{
    public class ConsoleInterfaceTests
    {
        [Fact]
        // test displaying welcome message.
        public void RunApp_DisplaysWelcomeMessage()
        {
            var serviceMock = new Mock<ConverterService>(
                new LengthConverter(),
                new TempConverter(),
                new MassConverter());
            
            var inputOutputMock = new Mock<IUserIO>();

            var userInterface = new ConsoleInterface(serviceMock.Object, inputOutputMock.Object);
            
            userInterface.Run();

            inputOutputMock.Verify(inputOutput => inputOutput.WriteLine("Welcome to the Metric/Imperial Unit Converter!"));
        }
    }
}