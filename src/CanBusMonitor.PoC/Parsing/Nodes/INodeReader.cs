using CanBusMonitor.PoC.Parsing.Signals;
using System.Collections.Generic;

namespace CanBusMonitor.PoC.Parsing.Nodes
{
    public interface INodeReader
    {
        int Identifier { get; }
        string Name { get; }
        IEnumerable<ISignalParser> Signals { get; }
    }
}