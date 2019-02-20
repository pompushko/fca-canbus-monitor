using CanBusMonitor.PoC.Parsing.Signals;
using System;

namespace CanBusMonitor.PoC.Parsing.Nodes
{
    public class MOT2NodeReader: NodeReader
    {
        private CanMessage _canMessage;

        public override int Identifier => TypeIdentifier;

        public override string Name => "MOT2";

        public const int TypeIdentifier = 0x3A1;

        public MOT2NodeReader(CanMessage canMessage)
        {
            if (canMessage.Identifier != Identifier)
            {
                throw new NotSupportedException($"Identifier is not supported.");
            }

            _canMessage = canMessage;
            Signals = new ISignalParser[]
            {
                new EmptySignalParser("CANStand"),
                new RangeSignalParser(_canMessage.Data, 48, 55, "MaxEngTorqueNorm"),
                new BoolSignalParser(_canMessage.Data, 47, "GasPedalGradientValidData"),
                new BoolSignalParser(_canMessage.Data, 46, "ThrottlePositionValidData"),
                new BoolSignalParser(_canMessage.Data, 45, "StopLightSwitchStsValidData"),
                new BoolSignalParser(_canMessage.Data, 44, "StopLightSwitchSts"),
                new BoolSignalParser(_canMessage.Data, 43, "EngineIntervention"),
                new BoolSignalParser(_canMessage.Data, 42, "CruiseControlSts"),
                new EmptySignalParser("ECUFail"),
                new BoolSignalParser(_canMessage.Data, 40, "Override"),
                new RangeSignalParser(_canMessage.Data, 32, 39, "GasPedalGradient"),
                new EmptySignalParser("ThrottlePosition"),
                new BoolSignalParser(_canMessage.Data, 23, "ECACCFail"),
                new BoolSignalParser(_canMessage.Data, 22, "ECACCShutOff"),
                new BoolSignalParser(_canMessage.Data, 21, "ClutchPedalAction"),
                new BoolSignalParser(_canMessage.Data, 20, "GasPedalAct"),
                new EmptySignalParser("EngineTorqueTarget"),
                new BoolSignalParser(_canMessage.Data, 11, "MainSwitchACC"),
                new EnumSignalParser<OperationCodeACC>(_canMessage.Data, 8, 10, "OperationCodeACC"),
                new RangeSignalParser(_canMessage.Data, 6, 7, "TypeOfGearbox")
            };
        }

        public enum OperationCodeACC
        {
            NoACCButtonPressed = 0,
            SetPlusPressed = 1,
            SetMinusPressed = 2,
            ResumePressed = 3,
            OffPressed = 4,
            Unknown_Value_5 = 5,
            Unknown_Value_6 = 6,
            FailureInACCInputDetected = 7
        }
    }
}
