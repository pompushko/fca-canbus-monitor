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
            Signals = new ISignalParser[]
            {
                new BoolSignalParser(_canMessage.Data, 63, "MaxEngineTorqueValidData"),
                new BoolSignalParser(_canMessage.Data, 62, "GasPedalPositionValidData"),
                new BoolSignalParser(_canMessage.Data, 61, "EngineFrictionTorqueValidData"),
                new BoolSignalParser(_canMessage.Data, 60, "FeedbackASR/VDCReq"),
                new BoolSignalParser(_canMessage.Data, 59, "EngineTorqueValidData"),
                new BoolSignalParser(_canMessage.Data, 58, "EngineTorqueDriverReqValidData"),
                new EnumSignalParser<TorqueIntervention>(_canMessage.Data, 56,57,"TorqueInterventionSts"),
                new RangeSignalParser(_canMessage.Data, 48, 55, "EngineTorque"),
                new RangeSignalParser(_canMessage.Data, 32, 47, "EngineSpeed"),
                new RangeSignalParser(_canMessage.Data, 24, 31, "EngineTorqueDriverReq"),
                new RangeSignalParser(_canMessage.Data, 16, 23, "EngineFrictionTorque"),
                new RangeSignalParser(_canMessage.Data, 8, 15, "MaxEngineTorque"),
                new RangeSignalParser(_canMessage.Data, 0, 7, "GasPedalPosition")
            };
        }

        public enum TorqueIntervention
        {
            Ok = 0,
            Unknown_Value_1 = 1,
            Unknown_Value_2 = 2,
            Unknown_SystemErrorOrInjectionShutOff = 3
        }
    }
}
