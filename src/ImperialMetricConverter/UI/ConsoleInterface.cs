using ImperialMetricConverter.Services;
using ImperialMetricConverter.Converters;

namespace ImperialMetricConverter.UI;

// Menu based console application
// Handles user interaction and delegates conversion logic to the service layer.
public class ConsoleInterface
{
    private readonly IConverterService _service;
    private readonly IUserIO _inputOutput;

    // Dependency injections through constructors using IConverterService and IUserIO.
    public ConsoleInterface(IConverterService service, IUserIO inputOutput)
    {
        _service = service;
        _inputOutput = inputOutput;
    }

    // main application loop
    public void Run()
{
        _inputOutput.WriteLine("Welcome to the Metric/Imperial Unit Converter!");

        bool running = true;

        while (running)
        {
            _inputOutput.WriteLine("\nSelect conversion type:");
            _inputOutput.WriteLine("1. Length");
            _inputOutput.WriteLine("2. Temperature");
            _inputOutput.WriteLine("3. Mass");
            _inputOutput.WriteLine("0. Exit");

            string choice = _inputOutput.ReadLine();

            if (choice == null)
            {
                break;
            }

            switch (choice)
            {
                case "1":
                    HandleLength();
                    break;
                case "2":
                    HandleTemperature();
                    break;
                case "3":
                    HandleMass();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    _inputOutput.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    // length conversion flow
    // prompts user and delegates conversion to the service layer
    private void HandleLength()
    {
        var units = Enum.GetValues<LengthUnit>();

        _inputOutput.WriteLine("Select 'from' unit:");
        for (int i = 0; i < units.Length; i++)
        {
            _inputOutput.WriteLine($"{i + 1}. {units[i]}");
        }

        if (!int.TryParse(_inputOutput.ReadLine(), out int fromIndex) ||
            fromIndex < 1 || fromIndex > units.Length)
        {
            _inputOutput.WriteLine("Invalid selection.");
            return;
        }

        _inputOutput.WriteLine("Select 'to' unit:");
        for (int i = 0; i < units.Length; i++)
        {
            _inputOutput.WriteLine($"{i + 1}. {units[i]}");
        }

        if (!int.TryParse(_inputOutput.ReadLine(), out int toIndex) ||
            toIndex < 1 || toIndex > units.Length)
        {
            _inputOutput.WriteLine("Invalid selection.");
            return;
        }

        _inputOutput.WriteLine("Enter value:");
        if (!double.TryParse(_inputOutput.ReadLine(), out double value))
        {
            _inputOutput.WriteLine("Invalid number.");
            return;
        }

        var from = units[fromIndex - 1];
        var to = units[toIndex - 1];

        double result = _service.ConvertLength(value, from, to);

        _inputOutput.WriteLine($"Result: {result}");
    }

    // temperature conversion flow
    // prompts user and delegates conversion to the service layer
    private void HandleTemperature()
    {
        var units = Enum.GetValues<TempUnit>();

        _inputOutput.WriteLine("Select 'from' unit:");
        for (int i = 0; i < units.Length; i++)
        {
            _inputOutput.WriteLine($"{i + 1}. {units[i]}");
        }

        if (!int.TryParse(_inputOutput.ReadLine(), out int fromIndex) ||
            fromIndex < 1 || fromIndex > units.Length)
        {
            _inputOutput.WriteLine("Invalid selection.");
            return;
        }

        _inputOutput.WriteLine("Select 'to unit:");
        for (int i = 0; i < units.Length; i++)
        {
            _inputOutput.WriteLine($"{i + 1}. {units[i]}");
        }

        if (!int.TryParse(_inputOutput.ReadLine(), out int toIndex) ||
            toIndex < 1 || toIndex > units.Length)
        {
            _inputOutput.WriteLine("Invalid selection.");
            return;
        }

        _inputOutput.WriteLine("Enter value:");
        if (!double.TryParse(_inputOutput.ReadLine(), out double value))
        {
            _inputOutput.WriteLine("Invalid number.");
            return;
        }

        var from = units[fromIndex - 1];
        var to = units[toIndex - 1];

        double result = _service.ConvertTemperature(value, from, to);

        _inputOutput.WriteLine($"Result: {result}");
    }

    // mass conversion flow
    // prompts user and delegates conversion to the service layer
    private void HandleMass()
    {
        var units = Enum.GetValues<MassUnit>();

        _inputOutput.WriteLine("Select 'from' unit:");
        for (int i = 0; i < units.Length; i++)
        {
            _inputOutput.WriteLine($"{i + 1}. {units[i]}");
        }

        if (!int.TryParse(_inputOutput.ReadLine(), out int fromIndex) ||
            fromIndex < 1 || fromIndex > units.Length)
        {
            _inputOutput.WriteLine("Invalid selection.");
            return;
        }

        _inputOutput.WriteLine("Select 'to' unit:");
        for (int i = 0; i < units.Length; i++)
        {
            _inputOutput.WriteLine($"{i + 1}. {units[i]}");
        }

        if (!int.TryParse(_inputOutput.ReadLine(), out int toIndex) ||
            toIndex < 1 || toIndex > units.Length)
        {
            _inputOutput.WriteLine("Invalid selection.");
            return;
        }

        _inputOutput.WriteLine("Enter value:");
        if (!double.TryParse(_inputOutput.ReadLine(), out double value))
        {
            _inputOutput.WriteLine("Invalid number.");
            return;
        }

        var from = units[fromIndex - 1];
        var to = units[toIndex - 1];

        double result = _service.ConvertMass(value, from, to);

        _inputOutput.WriteLine($"Result: {result}");
    }
}