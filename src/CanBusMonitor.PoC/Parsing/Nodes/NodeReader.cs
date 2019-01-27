using CanBusMonitor.PoC.Parsing.Signals;
using System.Collections.Generic;

namespace CanBusMonitor.PoC.Parsing.Nodes
{
    public abstract class NodeReader : INodeReader
    {
        public abstract int Identifier { get; }
        public abstract string Name { get; }

        public IEnumerable<ISignalParser> Signals { get; set; }
    }
}