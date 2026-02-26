namespace ImperialMetricConverter.Converters;

// Generic type parameter prevents needing a separate interface for each unit.
public interface IUnitConverter<TUnit>
{
    // ny class that has a converter will have a Convert method
    // that takes a value and two units, and returns a double.
    double Convert(double value, TUnit from, TUnit to);
}