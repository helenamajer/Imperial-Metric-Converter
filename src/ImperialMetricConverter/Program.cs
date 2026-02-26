using ImperialMetricConverter.UI;
using ImperialMetricConverter.Services;
using ImperialMetricConverter.Converters;

namespace ImperialMetricConverter
{
    public class Program
    {
        static void Main(string[] args)
        {
            // dynamic object creation
            // dependency injection
            var lengthConverter = new LengthConverter();
            var tempConverter = new TempConverter();
            var massConverter = new MassConverter();

            // injecting the converters into ConvertService
            // dynamic object creation
            var converterService = new ConverterService(lengthConverter, tempConverter, massConverter);

            // injecting into ConsoleInterface
            // dynamic object creation
            var consoleInterface = new ConsoleInterface(converterService, new ConsoleIO());

            // run app
            consoleInterface.Run();
        }
    }

    // implementation of IUserIO that uses Console.
    public class ConsoleIO : IUserIO
    {
        public string ReadLine() => Console.ReadLine();
        public void WriteLine(string message) => Console.WriteLine(message);
    }
}