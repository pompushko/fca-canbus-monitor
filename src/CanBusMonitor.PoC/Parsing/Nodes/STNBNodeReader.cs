using CanBusMonitor.PoC.Parsing.Signals;
using System;

namespace CanBusMonitor.PoC.Parsing.Nodes
{
    public class STNBNodeReader : NodeReader
    {
        private CanMessage _canMessage;

        public override int Identifier => TypeIdentifier;

        public override string Name => Constants.Protocols.STNB;

        public const int TypeIdentifier = 0x560;

        public STNBNodeReader(CanMessage canMessage)
        {
            if (canMessage.Identifier != Identifier)
            {
                throw new NotSupportedException($"Identifier is not supported.");
            }

            _canMessage = canMessage;
            Signals = new ISignalParser[]
            {
                new BoolSignalParser(_canMessage.Data, 24, "Fuel Level Fail Sts"),
                new RangeSignalParser(_canMessage.Data, 16, 23, "Fuel Level")
            };
        }

    }
}
