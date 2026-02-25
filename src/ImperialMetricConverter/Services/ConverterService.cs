using ImperialMetricConverter.Converters;

namespace ImperialMetricConverter.Services;

// Acts as the application layer between UI and domain layer (converters).
// This service delegates conversion requests to the respected converter.
// This abstraction allows dependency injection and mocking.
public class ConverterService
{
    // Dependencies injected through constructor (DI).
    private readonly IUnitConverter<LengthUnit> _lengthConverter;
    private readonly IUnitConverter<TempUnit> _tempConverter;
    private readonly IUnitConverter<MassUnit> _massConverter;

    // Constructor injection of all converter dependencies.
    // enables testability.
    public ConverterService(
        IUnitConverter<LengthUnit> lengthConverter,
        IUnitConverter<TempUnit> tempConverter,
        IUnitConverter<MassUnit> massConverter)
    {
        _lengthConverter = lengthConverter;
        _tempConverter = tempConverter;
        _massConverter = massConverter;
    }

    // converts length values by delegating requests to the length converter.
    public double ConvertLength(double value, LengthUnit from, LengthUnit to)
        => _lengthConverter.Convert(value, from, to);

    // converts temperature values by delegating requests to the temperature converter.
    public double ConvertTemperature(double value, TempUnit from, TempUnit to)
        => _tempConverter.Convert(value, from, to);

    // converts mass values by delegating requests to the mass converter.
    public double ConvertMass(double value, MassUnit from, MassUnit to)
        => _massConverter.Convert(value, from, to);
}