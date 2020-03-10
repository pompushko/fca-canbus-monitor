using CanBusMonitor.PoC.Parsing.Signals;
using System;

namespace CanBusMonitor.PoC.Parsing.Nodes
{
    public class MOTGEARNodeReader : NodeReader
    {
        private CanMessage _canMessage;

        public override int Identifier => TypeIdentifier;

        public override string Name => Constants.Protocols.MOTGEAR;

        public const int TypeIdentifier = 0x061;

        public MOTGEARNodeReader(CanMessage canMessage)
        {
            if (canMessage.Identifier != Identifier)
            {
                throw new NotSupportedException($"Identifier is not supported.");
            }

            _canMessage = canMessage;
            Signals = new ISignalParser[]
            {
                new BoolSignalParser(_canMessage.Data, 63, "EngineTorqueForNCAValidData"),
                new BoolSignalParser(_canMessage.Data, 62, "EngineTorqueReductNCAValidData"),
                new BoolSignalParser(_canMessage.Data, 61, "StopLightSwitchStsValidData"),
                new BoolSignalParser(_canMessage.Data, 60, "StopLightSwitchSts"),
                new BoolSignalParser(_canMessage.Data, 59, "AirConSts"),
                new BoolSignalParser(_canMessage.Data, 58, "EngineSpeedValidData"),
                new BoolSignalParser(_canMessage.Data, 57, "KickDownRequest"),
                new EmptySignalParser("NotUsed"),
                new RangeSignalParser(_canMessage.Data, 48, 55, "EngineTorqueForNCA"),
                new RangeSignalParser(_canMessage.Data, 40, 47, "EngineTorqueReductNCA"),
                new RangeSignalParser(_canMessage.Data, 32, 39, "EngineWaterTempForNCA"),
                new BoolSignalParser(_canMessage.Data, 31, "EngineWaterTempForNCAFailSts"),
                new EmptySignalParser("NotUsed")
            };
        }

    }
}

