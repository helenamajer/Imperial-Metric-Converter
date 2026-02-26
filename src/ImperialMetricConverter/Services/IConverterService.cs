using ImperialMetricConverter.Converters;

namespace ImperialMetricConverter.Services;

// This defines what methods the ConverterService must have.
// used in ConsoleInterface.
public interface IConverterService
{
    double ConvertLength(double value, LengthUnit from, LengthUnit to);
    double ConvertTemperature(double value, TempUnit from, TempUnit to);
    double ConvertMass(double value, MassUnit from, MassUnit to);
}