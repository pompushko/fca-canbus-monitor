using CanBusMonitor.PoC.Parsing.Nodes;

namespace CanBusMonitor.PoC.Parsing.Writers
{
    public interface IWritersPool
    {
        void Write(INodeReader nodeReader);
    }
}
