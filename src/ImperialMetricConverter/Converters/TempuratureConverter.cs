namespace ImperialMetricConverter.Converters;

public enum TempUnit
{
    Celsius,
    Fahrenheit,
}

public class TempConverter
{
    public double Convert(double value, TempUnit from, TempUnit to)
    {
        if (from == TempUnit.Celsius && to == TempUnit.Fahrenheit)
            // formula for C to F conversion.
            return (value * 9 / 5) + 32;
        
        throw new NotImplementedException();
    }
}