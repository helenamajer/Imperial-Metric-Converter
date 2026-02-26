using ImperialMetricConverter.Converters;

namespace ImperialMetricConverter.Services;

public interface IConverterService
{
    double ConvertLength(double value, LengthUnit from, LengthUnit to);
    double ConvertTemperature(double value, TempUnit from, TempUnit to);
    double ConvertMass(double value, MassUnit from, MassUnit to);
}