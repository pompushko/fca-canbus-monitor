using CanBusMonitor.PoC.Parsing.Signals;
using System;

namespace CanBusMonitor.PoC.Parsing.Nodes
{
    public class MOT1NodeReader: NodeReader
    {
        private CanMessage _canMessage;

        public override int Identifier => TypeIdentifier;

        public override string Name => "MOT1";

        public const int TypeIdentifier = 0x361;

        public MOT1NodeReader(CanMessage canMessage)
        {
            if (canMessage.Identifier != Identifier)
            {
                throw new NotSupportedException($"Identifier is not supported.");
            }

            _canMessage = canMessage;
            Signals = new[]
            {
                new BoolSignalParser(_canMessage.Data, 63, "MaxEngineTorqueValidData"),
                new BoolSignalParser(_canMessage.Data, 62, "GasPedalPositionValidData"),
                new BoolSignalParser(_canMessage.Data, 61, "EngineFrictionTorqueValidData"),
                new BoolSignalParser(_canMessage.Data, 60, "FeedbackASR/VDCReq"),
                new BoolSignalParser(_canMessage.Data, 59, "EngineTorqueValidData"),
                new BoolSignalParser(_canMessage.Data, 58, "EngineTorqueDriverReqValidData"),
            };
        }
    }
}
