namespace ImperialMetricConverter.Converters;

// Measurement converter for units of length.
public class LengthConverter
{
    // Converting inches to centimeters.
    public double InchesToCentimeters(double inches)
    {
        if (inches < 0)
            throw new ArgumentException("Length cannot be negative.");
        
        return (inches * 2.54);
    }
}    
