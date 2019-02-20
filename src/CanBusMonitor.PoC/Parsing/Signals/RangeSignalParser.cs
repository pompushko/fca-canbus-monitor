using System.Collections;

namespace CanBusMonitor.PoC.Parsing.Signals
{
    public class RangeSignalParser : ISignalParser<int>
    {
        private BitArray _bitArray;
        private readonly int _offset;
        private readonly int _length;

        public RangeSignalParser(BitArray bitArray, int startIndex, int endIndex, string name)
        {
            _bitArray = bitArray;
            _offset = startIndex;
            _length = endIndex - startIndex + 1;
            Name = name;
        }

        public int Value
        {
            get { return GetValue(_bitArray, _offset, _length); }
        }

        public string Name { get; }

        public override string ToString()
        {
            return $"{Name}:{Value}";
        }

        private int GetValue(BitArray source, int offset, int length)
        {
            int value = 0;
            for (int i = 0; i < length; i++)
            {
                if (source[offset + i])
                {
                    value |= (1 << i);
                }
            }
            return value;
        }
    }
}
