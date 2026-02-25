namespace ImperialMetricConverter.Converters;

// Generic type parameter prevents needing a separate interface for each unit.
public interface IUnitConverter<TUnit>
{
    double Convert(double value, TUnit from, TUnit to);
}