using System;
using System.Collections;
using System.Linq;

namespace CanBusMonitor.PoC.Parsing
{
    public class FileParser
    {
        public CanMessage ParseLine(string line)
        {
            var lineParts = line.Split(new char[] { ' ', '\u0002' }, StringSplitOptions.RemoveEmptyEntries);
            var bytesCount = byte.Parse(lineParts[1]);
            return new CanMessage
            {
                Identifier = int.Parse(lineParts[0], System.Globalization.NumberStyles.HexNumber),
                DataLength = bytesCount,
                Data = new BitArray(Enumerable.Range(2, bytesCount).Select(index => byte.Parse(lineParts[index],System.Globalization.NumberStyles.HexNumber)).ToArray()),
                Counter = int.Parse(lineParts[2 + bytesCount])
            };
        }
    }
}
