using System;
using System.Collections.Generic;
using System.IO;
using CanBusMonitor.PoC.Parsing.Nodes;

namespace CanBusMonitor.PoC.Parsing.Writers
{
    internal class WritersPool : IWritersPool
    {
        private readonly Dictionary<string, IWriter> writers;

        public WritersPool(string outputDirectory)
        {
            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            writers = new Dictionary<string, IWriter>
            {
                { Constants.Protocols.ASR1, new ASR1CsvWriter(outputDirectory) },
                { Constants.Protocols.ASR2, new ASR2CsvWriter(outputDirectory) },
                { Constants.Protocols.MOT1, new MOT1CsvWriter(outputDirectory) },
                { Constants.Protocols.MOT2, new MOT2CsvWriter(outputDirectory) },
                { Constants.Protocols.MOTGEAR, new MOTGEARCsvWriter(outputDirectory) },
                { Constants.Protocols.STNB_CUSW11, new STNB_CUSW11CsvWriter(outputDirectory) },
                { Constants.Protocols.STNB, new STNBCsvWriter(outputDirectory) }
            };
        }

        public void Write(INodeReader nodeReader)
        {
            if (writers.ContainsKey(nodeReader?.Name))
            {
                writers[nodeReader.Name].Write(nodeReader);
            }
        }
    }
}
