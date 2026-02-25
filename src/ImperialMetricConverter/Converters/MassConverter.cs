namespace ImperialMetricConverter.Converters;

/*
* Mass conversion for pounds and kilograms.
*/
public enum MassUnit
{
    Pound,
    Kilogram,
}

public class MassConverter
{
    public double Convert(double value, MassUnit from, MassUnit to)
    {
        // if input is negative, throw argument exception.
        if (value < 0)
            throw new ArgumentException("Mass cannot be negative.");
        
        // formula for pound to kilogram conversion.
        if (from == MassUnit.Pound && to == MassUnit.Kilogram)
            return value * 0.453592;

        // formula for kilogram to pound conversion.
        if (from == MassUnit.Kilogram && to == MassUnit.Pound)
            return value * 2.20462;

        throw new NotImplementedException();
    }
}
