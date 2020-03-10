using CanBusMonitor.PoC.Parsing.Signals;
using System;

namespace CanBusMonitor.PoC.Parsing.Nodes
{
    public class MOT2NodeReader : NodeReader
    {
        private CanMessage _canMessage;

        public override int Identifier => TypeIdentifier;

        public override string Name => Constants.Protocols.MOT2;

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
                new RangeSignalParser(_canMessage.Data, 56, 63, "DriverPowerReq"),
                new RangeSignalParser(_canMessage.Data, 48, 55, "MaxEngTorqueNorm"),
                new BoolSignalParser(_canMessage.Data, 47, "GasPedalGradientValidData"),
                new BoolSignalParser(_canMessage.Data, 46, "ThrottlePositionValidData"),
                new BoolSignalParser(_canMessage.Data, 45, "StopLightSwitchStsValidData"),
                new BoolSignalParser(_canMessage.Data, 44, "StopLightSwitchSts"),
                new BoolSignalParser(_canMessage.Data, 43, "EngineIntervention"),
                new BoolSignalParser(_canMessage.Data, 42, "CruiseControlSts"),
                new BoolSignalParser(_canMessage.Data, 41, "ECUFail"),
                new BoolSignalParser(_canMessage.Data, 40, "Override"),
                new RangeSignalParser(_canMessage.Data, 32, 39, "GasPedalGradient"),
                new RangeSignalParser(_canMessage.Data, 24, 31, "Throttle Position"),
                new BoolSignalParser(_canMessage.Data, 23, "ECACCFail"),
                new BoolSignalParser(_canMessage.Data, 22, "ECACCShutOff"),
                new BoolSignalParser(_canMessage.Data, 21, "ClutchPedalAction"),
                new BoolSignalParser(_canMessage.Data, 20, "GasPedalAct"),
                new EmptySignalParser("EngineTorqueTarget"),
                new BoolSignalParser(_canMessage.Data, 11, "MainSwitchACC"),
                new EnumSignalParser<OperationCodeACC>(_canMessage.Data, 8, 10, "OperationCodeACC"),
                new EnumSignalParser<TypeOfGearbox>(_canMessage.Data, 6, 7, "TypeOfGearbox"),
                new EnumSignalParser<EngineSts>(_canMessage.Data, 4, 5, "EngineSts"),
                new BoolSignalParser(_canMessage.Data, 3, "Crank Aborted"),
                new BoolSignalParser(_canMessage.Data, 2, "Starter Active"),
                new BoolSignalParser(_canMessage.Data, 2, "Starter Failed Sts"),
                new BoolSignalParser(_canMessage.Data, 1, "Start Relay BCM Cmd")
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

        public enum TypeOfGearbox
        {
            ManualTransmission = 0,
            AutomaticTransmission = 1,
            ContinuouslyVariableTransmission = 2,
            RoboticTransmission = 3
        }

        public enum EngineSts
        {
            EngineOFF = 0,
            EngineCranking = 1,
            EngineON = 2,
            Unknown_Value_3 = 3
        }
    }
}
