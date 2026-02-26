using Moq;
using Xunit;
using ImperialMetricConverter.UI;
using ImperialMetricConverter.Services;
using ImperialMetricConverter.Converters;

/*
* Test suite for mocking console user interface .
*/
namespace ImperialMetricConverter.Tests.UI
{
    public class ConsoleInterfaceTests
    {
        [Fact]
        // test displaying welcome message.
        public void RunApp_DisplaysWelcomeMessage()
        {
            // Arrange
            var serviceMock = new Mock<IConverterService>();
            
            var inputOutputMock = new Mock<IUserIO>();

            // input so Run() does not break.
            inputOutputMock
                .Setup(inputOutput => inputOutput.ReadLine())
                // invalid input to break flow
                .Returns("99");

            var userInterface = new ConsoleInterface(serviceMock.Object, inputOutputMock.Object);
            
            // Act
            userInterface.Run();

            // Assert
            inputOutputMock.Verify(inputOutput => inputOutput.WriteLine("Welcome to the Metric/Imperial Unit Converter!"),
            Times.Once);
        }

        [Fact]
        // Length conversion flow.
        public void RunApp_LengthFlow_CallsConvertLength_DisplaysResult()
        {
            // Arrange
            var serviceMock = new Mock<IConverterService>();

            var inputOutputMock = new Mock<IUserIO>();

            inputOutputMock.SetupSequence(inputOutput => inputOutput.ReadLine())
                .Returns("1") // menu selection
                .Returns("10") // value
                .Returns("Meter") // from
                .Returns("Kilometer"); // to
            
            serviceMock
                .Setup(s => s.ConvertLength(10, LengthUnit.Meter, LengthUnit.Kilometer))
                .Returns(0.01);

            var userInterface = new ConsoleInterface(serviceMock.Object, inputOutputMock.Object);

            // Act
            userInterface.Run();

            // Assert
            serviceMock.Verify(
                s => s.ConvertLength(10, LengthUnit.Meter, LengthUnit.Kilometer),
                Times.Once);

            inputOutputMock.Verify(
                inputOutput => inputOutput.WriteLine(It.Is<string>(msg => msg.Contains("0.01"))),
                Times.Once);
        }

        [Fact]
        // Temp conversion flow.
        public void RunApp_TemperatureFlow_CallsConvertTemperature_DisplaysResult()
        {
            // Arrange
            var serviceMock = new Mock<IConverterService>();
            var inputOutputMock = new Mock<IUserIO>();

            inputOutputMock.SetupSequence(io => io.ReadLine())
                .Returns("2")        // menu option
                .Returns("100")      // value
                .Returns("Celsius")  // from
                .Returns("Fahrenheit"); // to


            serviceMock
                .Setup(s => s.ConvertTemperature(100, TempUnit.Celsius, TempUnit.Fahrenheit))
                .Returns(212);

            var userInterface = new ConsoleInterface(serviceMock.Object, inputOutputMock.Object);

            // Act
            userInterface.Run();

            // Assert
            serviceMock.Verify(
                s => s.ConvertTemperature(100, TempUnit.Celsius, TempUnit.Fahrenheit),
                Times.Once);

            inputOutputMock.Verify(
                io => io.WriteLine(It.Is<string>(msg => msg.Contains("212"))),
                Times.Once);
        }
    }
}