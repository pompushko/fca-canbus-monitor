using CanBusMonitor.PoC.Parsing.Signals;
using System;

namespace CanBusMonitor.PoC.Parsing.Nodes
{
    public class ASR1NodeReader: NodeReader
    {
        private CanMessage _canMessage;

        public override int Identifier => TypeIdentifier;

        public override string Name => "ASR1";

        public const int TypeIdentifier = 0x146;

        public ASR1NodeReader(CanMessage canMessage)
        {
            if (canMessage.Identifier != Identifier)
            {
                throw new NotSupportedException($"Identifier is not supported.");
            }

            _canMessage = canMessage;
            Signals = new ISignalParser[]
            {

            };
        }

    }
}
