using System;
using System.Collections;

namespace CanBusMonitor.PoC.Parsing.Signals
{
    public class EnumSignalParser<TEnum> : ISignalParser<TEnum> where TEnum : Enum
    {
        private BitArray _bitArray;
        private readonly int _offset;
        private readonly int _length;

        public EnumSignalParser(BitArray bitArray, int startIndex, int endIndex, string name)
        {
            _bitArray = bitArray;
            _offset = startIndex;
            _length = endIndex - startIndex + 1;
            Name = name;
        }

        public TEnum Value
        {
            get { return (TEnum)Enum.ToObject(typeof(TEnum), GetValue(_bitArray, _offset, _length)); }
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
