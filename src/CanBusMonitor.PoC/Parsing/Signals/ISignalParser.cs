namespace CanBusMonitor.PoC.Parsing.Signals
{
    public interface ISignalParser
    {
        string Name { get; }
        string ToString();
    }

    public interface ISignalParser<TValue> : ISignalParser
    {
        TValue Value { get; }
    }
}