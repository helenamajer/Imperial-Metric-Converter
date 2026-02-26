using Moq;
using Xunit;
using ImperialMetricConverter.UI;
using ImperialMetricConverter.Services;
using ImperialMetricConverter.Converters;

/*
* Test suite for mocking console user interface.
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
                .SetupSequence(inputOutput => inputOutput.ReadLine())
                // invalid input to break flow
                .Returns("99")
                // exit
                .Returns("0");

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
            // mock the service dependency
            var serviceMock = new Mock<IConverterService>();

            // mock the input output dependency
            var inputOutputMock = new Mock<IUserIO>();

            // setup mock behavious
            inputOutputMock.SetupSequence(inputOutput => inputOutput.ReadLine())
                .Returns("1")         // main menu option
                .Returns("3")         // from meter option
                .Returns("7")         // to kilometer option
                .Returns("500")       // value
                .Returns("0");        // exit loop
            
            serviceMock
                .Setup(s => s.ConvertLength(500, LengthUnit.Meter, LengthUnit.Kilometer))
                .Returns(0.5);

            // isloate - inject mocked dependency
            var userInterface = new ConsoleInterface(serviceMock.Object, inputOutputMock.Object);

            // Act
            userInterface.Run();

            // Assert and verify interactions
            serviceMock.Verify(
                s => s.ConvertLength(500, LengthUnit.Meter, LengthUnit.Kilometer),
                Times.Once);

            inputOutputMock.Verify(
                inputOutput => inputOutput.WriteLine(It.Is<string>(msg => msg.Contains("0,5"))),
                Times.Once);
        }

        [Fact]
        // Temp conversion flow.
        public void RunApp_TemperatureFlow_CallsConvertTemperature_DisplaysResult()
        {
            // mock the service dependency
            var serviceMock = new Mock<IConverterService>();

            // mock the input output dependency
            var inputOutputMock = new Mock<IUserIO>();

            // setup mock behavious
            inputOutputMock.SetupSequence(inputOutput => inputOutput.ReadLine())
                .Returns("2")         // main menu option
                .Returns("1")         // from 'celsius' option
                .Returns("2")         // to 'fahrenheit' option
                .Returns("30")        // value
                .Returns("0");        // exit loop


            serviceMock
                .Setup(s => s.ConvertTemperature(30, TempUnit.Celsius, TempUnit.Fahrenheit))
                .Returns(86);

            // isloate - inject mocked dependency
            var userInterface = new ConsoleInterface(serviceMock.Object, inputOutputMock.Object);

            // Act
            userInterface.Run();

            // Assert and verify interactions
            serviceMock.Verify(
                s => s.ConvertTemperature(30, TempUnit.Celsius, TempUnit.Fahrenheit),
                Times.Once);

            inputOutputMock.Verify(
                inputOutput => inputOutput.WriteLine(It.Is<string>(msg => msg.Contains("86"))),
                Times.Once);
        }

        [Fact]
        // Mass converion flow.
        public void RunApp_MassFlow_CallsConvertMass_DisplaysResult()
        {
            // mock the service dependency
            var serviceMock = new Mock<IConverterService>();

            // mock the input output dependency
            var inputOutputMock = new Mock<IUserIO>();

            // setup mock behavious
            inputOutputMock.SetupSequence(inputOutput => inputOutput.ReadLine())
                .Returns("3")         // main menu option
                .Returns("1")         // from 'pound' option
                .Returns("2")         // to 'kilogram' option
                .Returns("1000")      // value
                .Returns("0");        // exit loop

            serviceMock
                .Setup(s => s.ConvertMass(1000, MassUnit.Pound, MassUnit.Kilogram))
                .Returns(453.59);

            // isloate - inject mocked dependency
            var userInterface = new ConsoleInterface(serviceMock.Object, inputOutputMock.Object);

            // Act
            userInterface.Run();

            // Assert and verify interactions
            serviceMock.Verify(
                s => s.ConvertMass(1000, MassUnit.Pound, MassUnit.Kilogram),
                Times.Once);

            inputOutputMock.Verify(
                inputOutput => inputOutput.WriteLine(It.Is<string>(msg => msg.Contains("453,59"))),
                Times.Once);
        }
    }
}