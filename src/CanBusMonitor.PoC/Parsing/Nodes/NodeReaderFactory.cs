using System;

namespace CanBusMonitor.PoC.Parsing.Nodes
{
    public class NodeReaderFactory
    {
        public INodeReader CreateNodeReader(CanMessage canMessage)
        {
            switch (canMessage.Identifier)
            {
                case MOT1NodeReader.TypeIdentifier:
                    return new MOT1NodeReader(canMessage);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
