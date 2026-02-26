using ImperialMetricConverter.Services;
using ImperialMetricConverter.Converters;

namespace ImperialMetricConverter.UI;

public class ConsoleInterface
{
    private readonly IConverterService _service;
    private readonly IUserIO _inputOutput;

    public ConsoleInterface(IConverterService service, IUserIO inputOutput)
    {
        _service = service;
        _inputOutput = inputOutput;
    }

    public void Run()
    {
        // display welcome message.
        _inputOutput.WriteLine("Welcome to the Metric/Imperial Unit Converter!");

        var option = _inputOutput.ReadLine();

        // length conversion flow.
        if (option == "1")
        {
            // read value
            var valueInput = _inputOutput.ReadLine();
            double value = double.Parse(valueInput);

            // read 'from' unit
            var fromInput = _inputOutput.ReadLine();
            LengthUnit fromUnit = Enum.Parse<LengthUnit>(fromInput);

            // read 'to' unit
            var toInput = _inputOutput.ReadLine();
            LengthUnit toUnit = Enum.Parse<LengthUnit>(toInput);

            // call service
            double result = _service.ConvertLength(value, fromUnit, toUnit);

            // display result and force invariant culture when converting to string.
            _inputOutput.WriteLine(result.ToString("0.####", System.Globalization.CultureInfo.InvariantCulture));
        }
    }
}