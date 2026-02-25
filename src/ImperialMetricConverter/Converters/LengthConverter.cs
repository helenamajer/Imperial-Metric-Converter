namespace ImperialMetricConverter.Converters;
/*
* Converter for 7 units of imperial and metric length measurements.
* Imperial: Inch, Foot, Yard, Mile.
* Metric: Centimeter, Meter, Kilometer.
*/

public enum LengthUnit
{
    Inch,
    Centimeter,
    Meter,
    Foot,
    Yard,
    Mile,
    Kilometer,
}

/*
* Converting the input unit to a base unit (meters).
* The base unit (meters) is then converted to the output unit.
*
* Without a base unit, each possible pair of units would need their own conversion logic.
*/
public class LengthConverter
{
    
    public double Convert(double value, LengthUnit from, LengthUnit to)
    {
        // input must be positive.
        if (value < 0)
            throw new ArgumentException("Length cannot be negative.");

        // if the 'from' unit and 'to' unit are the same, return the input value.
        if (from == to)
            return value;

        double meters = ToMeters(value, from);
        return FromMeters(meters, to);
    }

    // Convert the input unit to a base unit (meters).
    private double ToMeters(double value, LengthUnit unit)
    {
        return unit switch
        {
            LengthUnit.Inch => value * 0.0254,
            LengthUnit.Centimeter => value * 0.01,
            LengthUnit.Foot => value * 0.3048,
            LengthUnit.Meter => value,
            LengthUnit.Yard => value * 0.9144,
            LengthUnit.Mile => value * 1609.34,
            LengthUnit.Kilometer => value * 1000,
            _ => throw new ArgumentException("unit not supported")
        };
    }

    // Convert the base unit (meters) to the output unit.
    private double FromMeters(double value, LengthUnit unit)
    {
        return unit switch
        {
            LengthUnit.Inch => value / 0.0254,
            LengthUnit.Centimeter => value / 0.01,
            LengthUnit.Foot => value / 0.3048,
            LengthUnit.Meter => value,
            LengthUnit.Yard => value / 0.9144,
            LengthUnit.Mile => value / 1609.34,
            LengthUnit.Kilometer => value / 1000,
            _ => throw new ArgumentException("unit not supported")
        };
    }
}    