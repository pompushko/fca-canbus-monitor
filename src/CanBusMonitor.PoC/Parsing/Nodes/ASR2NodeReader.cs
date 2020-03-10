using CanBusMonitor.PoC.Parsing.Signals;
using System;

namespace CanBusMonitor.PoC.Parsing.Nodes
{
    public class ASR2NodeReader : NodeReader
    {
        private CanMessage _canMessage;

        public override int Identifier => TypeIdentifier;

        public override string Name => Constants.Protocols.ASR2;

        public const int TypeIdentifier = 0x166;

        public ASR2NodeReader(CanMessage canMessage)
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
