using System.Collections;

namespace CanBusMonitor.PoC.Parsing.Signals
{
    public class BoolSignalParser : ISignalParser<bool>
    {
        private BitArray _bitArray;
        private readonly int _index;

        public BoolSignalParser(BitArray bitArray, int index, string name)
        {
            _bitArray = bitArray;
            _index = index;
            Name = name;
        }

        public bool Value
        {
            get { return _bitArray.Get(_index); }
        }

        public string Name { get; }

        public override string ToString()
        {
            return Value ? "1" : "0";
        }
    }
}
