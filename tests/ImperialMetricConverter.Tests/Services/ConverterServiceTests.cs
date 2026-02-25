using Moq;
using Xunit;
using ImperialMetricConverter.Converters;
using ImperialMetricConverter.Services;

/*
* Test suite to test if ConverterService correctly delegates to its dependencies.
*/
namespace ImperialMetricConverter.Tests.Services
{
    public class ConverterServiceTests
    {
        [Fact]
        // Length delegation.
        public void ConvertLength_CallsLengthConverter_ReturnsResult()
        {
            // Arrange
            var mockLengthConverter = new Mock<IUnitConverter<LengthUnit>>();

            mockLengthConverter
                .Setup(x => x.Convert(1, LengthUnit.Meter, LengthUnit.Kilometer))
                .Returns(0.001);

            var service = new ConverterService(
                mockLengthConverter.Object,
                Mock.Of<IUnitConverter<TempUnit>>(),
                Mock.Of<IUnitConverter<MassUnit>>());

            // Act
            var result = service.ConvertLength(
                1,
                LengthUnit.Meter,
                LengthUnit.Kilometer);

            // Assert
            Assert.Equal(0.001, result);

            mockLengthConverter.Verify(
                x => x.Convert(1, LengthUnit.Meter, LengthUnit.Kilometer),
                Times.Once);
        }

        [Fact]
        // Temperature delegation.
        public void ConvertTemperature_CallsTempConverter_ReturnsResult()
        {
            // Arrange
            var mockTempConverter = new Mock<IUnitConverter<TempUnit>>();

            mockTempConverter
                .Setup(x => x.Convert(0, TempUnit.Celsius, TempUnit.Fahrenheit))
                .Returns(32);

            var service = new ConverterService(
                Mock.Of<IUnitConverter<LengthUnit>>(),
                mockTempConverter.Object,
                Mock.Of<IUnitConverter<MassUnit>>());

            // Act
            var result = service.ConvertTemperature(
                0,
                TempUnit.Celsius,
                TempUnit.Fahrenheit);

            // Assert
            Assert.Equal(32, result);

            mockTempConverter.Verify(
                x => x.Convert(0, TempUnit.Celsius, TempUnit.Fahrenheit),
                Times.Once);
        }

        [Fact]
        public void ConvertMass_CallsMassConverter_ReturnsResult()
        {
            // Arrange
            var mockMassConverter = new Mock<IUnitConverter<MassUnit>>();

            mockMassConverter
                .Setup(x => x.Convert(1, MassUnit.Kilogram, MassUnit.Pound))
                .Returns(2.2046);
            
            var service = new ConverterService(
                Mock.Of<IUnitConverter<LengthUnit>>(),
                Mock.Of<IUnitConverter<TempUnit>>(),
                mockMassConverter.Object);

            // Act
            var result = service.ConvertMass(
                1,
                MassUnit.Kilogram,
                MassUnit.Pound);

            // Assert
            Assert.Equal(2.2046, result, 4);

            mockMassConverter.Verify(
                x => x.Convert(1, MassUnit.Kilogram, MassUnit.Pound),
                Times.Once);
        }
    }
}