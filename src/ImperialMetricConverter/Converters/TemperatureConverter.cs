namespace ImperialMetricConverter.Converters;

/*
* Celsius and fahrenheit temperature conversion
*/
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
            return (value * 9.0 / 5.0) + 32;
        
        if (from == TempUnit.Fahrenheit && to == TempUnit.Celsius)
            // formula for F to C conversion.
            return (value - 32) * 5.0 / 9.0;

        // If the temperature units are the same, return the input value.
        // E.g. C to C, F to F.
        if (from == to)
            return value;

        throw new NotImplementedException();
    }
}