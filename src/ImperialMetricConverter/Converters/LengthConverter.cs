namespace ImperialMetricConverter.Converters;

public enum LengthUnit
{
    Inch,
    Centimeter
}

// Measurement converter for units of length.
public class LengthConverter
{
    // input must be positive.
    public double Convert(double value, LengthUnit from, LengthUnit to)
    {
        if (value < 0)
            throw new ArgumentException("Length cannot be negative.");

        if (from == LengthUnit.Inch && to == LengthUnit.Centimeter)
            return value * 2.54;

        if (from == LengthUnit.Centimeter && to == LengthUnit.Inch)
            return value / 2.54;
        
        if (from == to)
            return value;
        throw new NotImplementedException();
    }
}    
