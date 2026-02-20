namespace ImperialMetricConverter.Converters;

// Measurement converter for units of length.
public class LengthConverter
{
    // Converting inches to centimeters.
    public double InchesToCentimeters(double inches)
    {
        return (inches * 2.54);
    }
}    
