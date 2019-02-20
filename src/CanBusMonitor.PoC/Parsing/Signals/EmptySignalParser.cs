namespace CanBusMonitor.PoC.Parsing.Signals
{
    public class EmptySignalParser : ISignalParser
    {
        public EmptySignalParser(string name)
        {
            Name = name;
        }
        
        public string Name { get; }

        public override string ToString()
        {
            return $"{Name}:-";
        }
    }
}
