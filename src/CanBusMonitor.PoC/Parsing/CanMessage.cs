using System.Collections;

namespace CanBusMonitor.PoC.Parsing
{
    public class CanMessage
    {
        public int Identifier { get; set; }
        public byte DataLength { get; set; }
        public BitArray Data { get; set; }
        public int Counter { get; set; }
    }
}