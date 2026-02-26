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
        _inputOutput.WriteLine("Welcome to the Metric/Imperial Unit Converter!");
    }
}