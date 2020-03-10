using CanBusMonitor.PoC.Parsing.Nodes;

namespace CanBusMonitor.PoC.Parsing.Writers
{
    public interface IWriter
    {
        void Write(INodeReader nodeReader);
    }
}
