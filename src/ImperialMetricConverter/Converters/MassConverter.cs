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
        // formula for pound to kilogram conversion.
        if (from == MassUnit.Pound && to == MassUnit.Kilogram)
            return value * 0.453592;

        throw new NotImplementedException();
    }
}
