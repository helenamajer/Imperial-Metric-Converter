using Moq;
using Xunit;
using ImperialMetricConverter.Converters;
using ImperialMetricConverter.Services;

/*
* Test suite to mock ConverterService correctly delegating to its dependencies.
*/
namespace ImperialMetricConverter.Tests.Services
{
    public class ConverterServiceTests
    {
        [Fact]
        // Length delegation.
        public void ConvertLength_CallsLengthConverter_ReturnsResult()
        {
            // Arrange mock of IUnitConverter LengthUnit.
            var mockLengthConverter = new Mock<IUnitConverter<LengthUnit>>();

            // tell the mock what to do when Convert is called
            mockLengthConverter
                .Setup(x => x.Convert(1, LengthUnit.Meter, LengthUnit.Kilometer))
                .Returns(0.001);

            // inject the mock into ConverterServices
            var service = new ConverterService(
                // real converter replaced with mock
                mockLengthConverter.Object,
                Mock.Of<IUnitConverter<TempUnit>>(),
                Mock.Of<IUnitConverter<MassUnit>>());

            // Act - call the method we are testing
            var result = service.ConvertLength(
                1,
                LengthUnit.Meter,
                LengthUnit.Kilometer);

            // Assert
            Assert.Equal(0.001, result);

            // verify mock was called correclty
            mockLengthConverter.Verify(
                x => x.Convert(1, LengthUnit.Meter, LengthUnit.Kilometer),
                Times.Once);
        }

        [Fact]
        // Temperature delegation.
        public void ConvertTemperature_CallsTempConverter_ReturnsResult()
        {
            // Arrange mock of IUnitConverter TempUnit.
            var mockTempConverter = new Mock<IUnitConverter<TempUnit>>();

            mockTempConverter
                .Setup(x => x.Convert(0, TempUnit.Celsius, TempUnit.Fahrenheit))
                .Returns(32);

            // inject mocked dependencies
            var service = new ConverterService(
                Mock.Of<IUnitConverter<LengthUnit>>(),
                // real converter replaced with mock
                mockTempConverter.Object,
                Mock.Of<IUnitConverter<MassUnit>>());

            // Act
            var result = service.ConvertTemperature(
                0,
                TempUnit.Celsius,
                TempUnit.Fahrenheit);

            // Assert
            Assert.Equal(32, result);

            // verify mock was called correclty
            mockTempConverter.Verify(
                x => x.Convert(0, TempUnit.Celsius, TempUnit.Fahrenheit),
                Times.Once);
        }

        [Fact]
        public void ConvertMass_CallsMassConverter_ReturnsResult()
        {
            // Arrange mock of IUnitConverter MassUnit.
            var mockMassConverter = new Mock<IUnitConverter<MassUnit>>();

            mockMassConverter
                .Setup(x => x.Convert(1, MassUnit.Kilogram, MassUnit.Pound))
                .Returns(2.2046);
            
            // inject mocked dependencies
            var service = new ConverterService(
                Mock.Of<IUnitConverter<LengthUnit>>(),
                Mock.Of<IUnitConverter<TempUnit>>(),
                // real converter replaced with mock
                mockMassConverter.Object);

            // Act
            var result = service.ConvertMass(
                1,
                MassUnit.Kilogram,
                MassUnit.Pound);

            // Assert
            Assert.Equal(2.2046, result, 4);

            // verify mock was called correclty
            mockMassConverter.Verify(
                x => x.Convert(1, MassUnit.Kilogram, MassUnit.Pound),
                Times.Once);
        }
    }
}