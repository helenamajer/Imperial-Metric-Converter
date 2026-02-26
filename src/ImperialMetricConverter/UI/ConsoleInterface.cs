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
        // Display welcome message.
        _inputOutput.WriteLine("Welcome to the Metric/Imperial Unit Converter!");

        var option = _inputOutput.ReadLine();

        // Length conversion flow.
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

        // Temperature conversion flow.
        if (option == "2")
        {
            // read value
            _inputOutput.WriteLine("Enter value:");
            double value = double.Parse(_inputOutput.ReadLine());

            // read 'from' unit
            _inputOutput.WriteLine("Enter from unit:");
            TempUnit from = Enum.Parse<TempUnit>(_inputOutput.ReadLine(), true);

            // read 'to' unit
            _inputOutput.WriteLine("Enter to unit:");
            TempUnit to = Enum.Parse<TempUnit>(_inputOutput.ReadLine(), true);

            // call service
            double result = _service.ConvertTemperature(value, from, to);

            // display result
            _inputOutput.WriteLine(result.ToString("0.####", System.Globalization.CultureInfo.InvariantCulture));
        }

        // Mass conversion flow.
        if (option == "3")
        {
            // read value
            _inputOutput.WriteLine("Enter value:");
            double value = double.Parse(_inputOutput.ReadLine());

            // read 'from' unit
            _inputOutput.WriteLine("Enter from unit:");
            MassUnit from = Enum.Parse<MassUnit>(_inputOutput.ReadLine(), true);

            // read 'to' unit
            _inputOutput.WriteLine("Enter to unit:");
            MassUnit to = Enum.Parse<MassUnit>(_inputOutput.ReadLine(), true);

            // call service
            double result = _service.ConvertMass(value, from, to);

            // display result
            _inputOutput.WriteLine(result.ToString("0.####", System.Globalization.CultureInfo.InvariantCulture));
        }
    }
}