using ImperialMetricConverter.Services;

namespace ImperialMetricConverter.UI;

public class ConsoleInterface
{
    private readonly ConverterService _service;
    private readonly IUserIO _inputOutput;

    public ConsoleInterface(ConverterService service, IUserIO inputOutput)
    {
        _service = service;
        _inputOutput = inputOutput;
    }

    public void Run()
    {
        _inputOutput.WriteLine("Welcome to the Metric/Imperial Unit Converter!");
    }
}