namespace ImperialMetricConverter.UI;

// interface that wraps console input/output
// used real console in production or mock I/O in tests.
public interface IUserIO
{
    string ReadLine();
    void WriteLine(string message);
}