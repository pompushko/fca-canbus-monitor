using CanBusMonitor.PoC.Parsing.Signals;
using System;

namespace CanBusMonitor.PoC.Parsing.Nodes
{
    public class STNB_CUSW11NodeReader : NodeReader
    {
        private CanMessage _canMessage;

        public override int Identifier => TypeIdentifier;

        // The frame STNB_CUSW11 contains the values of Hand brake status, CompressorACReqSts, Drive ModeSelection, External temperature fail status, External temperature.
        public override string Name => "STNB_CUSW11";

        public const int TypeIdentifier = 0x4E0;

        public STNB_CUSW11NodeReader(CanMessage canMessage)
        {
            if (canMessage.Identifier != Identifier)
            {
                throw new NotSupportedException($"Identifier is not supported.");
            }

            _canMessage = canMessage;
            Signals = new ISignalParser[]
            {
                // AC Status on CAN
                // 1 = AC Request
                // 2 = No AC Request
                new BoolSignalParser(_canMessage.Data, 50, "CompressorACReqSts"),

                // Value Range -40ºC to +87ºC 
                // CAN Conversion E = N * 0.5 - 40ºC
                new RangeSignalParser(_canMessage.Data, 32, 39, "ExternalTemperature"),

                // This signal contains the faulty information related to the signal "ExternalTemperature". If the value is "Fail Present", then the ECM doesn' t take into account the external temperature value.
                // TRUE  = Fail Present 
                // FALSE = Fail not Present
                new BoolSignalParser(_canMessage.Data, 31, "ExternalTemperatureFailSts"),

                // This signal contains the information about Drive Style Sts.
                // Value Range 0 to 7
                new RangeSignalParser(_canMessage.Data, 27, 29, "Drive Style Sts"),

                // This signal contains the information about hand brake insertion. If the hand break is activated, the value $1(On) will be received.
                // 1 = On
                // 0 = Off
                new BoolSignalParser(_canMessage.Data, 13, "HandBrakeSts")
            };
        }

    }
}