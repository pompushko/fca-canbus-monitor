using System.IO;
using System.Linq;
using CanBusMonitor.PoC.Parsing.Nodes;

namespace CanBusMonitor.PoC.Parsing.Writers
{
    internal abstract class CsvWriter<T> : IWriter
    {
        private readonly string outputDirectory;

        protected CsvWriter(string outputDirectory)
        {
            this.outputDirectory = outputDirectory;
        }

        protected const char ColumnSeparator = ',';

        protected abstract string FileName { get; }

        public void Write(INodeReader nodeReader)
        {
            var data = string.Join(ColumnSeparator, nodeReader.Signals.Select(s => s.ToString()));
            if (!string.IsNullOrWhiteSpace(data))
            {
                var fullFileName = Path.Combine(outputDirectory, FileName);
                if (!File.Exists(fullFileName))
                {
                    var columnNames = string.Join(ColumnSeparator, nodeReader.Signals.Select(s => s.Name));
                    using (var streamWriter = File.CreateText(fullFileName))
                    {
                        streamWriter.WriteLine(columnNames);
                    }
                }

                using (var streamWriter = File.AppendText(fullFileName))
                {
                    streamWriter.WriteLine(data);
                }
            }
        }
    }

    internal class STNB_CUSW11CsvWriter : CsvWriter<STNB_CUSW11NodeReader>
    {
        public STNB_CUSW11CsvWriter(string outputDirectory) : base(outputDirectory) { }

        protected override string FileName => $"{Constants.Protocols.STNB_CUSW11}.csv";
    }

    internal class STNBCsvWriter : CsvWriter<STNBNodeReader>
    {
        public STNBCsvWriter(string outputDirectory) : base(outputDirectory) { }

        protected override string FileName => $"{Constants.Protocols.STNB}.csv";
    }

    internal class ASR1CsvWriter : CsvWriter<ASR1NodeReader>
    {
        public ASR1CsvWriter(string outputDirectory) : base(outputDirectory) { }

        protected override string FileName => $"{Constants.Protocols.ASR1}.csv";
    }

    internal class ASR2CsvWriter : CsvWriter<ASR2NodeReader>
    {
        public ASR2CsvWriter(string outputDirectory) : base(outputDirectory) { }

        protected override string FileName => $"{Constants.Protocols.ASR2}.csv";
    }

    internal class MOT1CsvWriter : CsvWriter<MOT1NodeReader>
    {
        public MOT1CsvWriter(string outputDirectory) : base(outputDirectory) { }

        protected override string FileName => $"{Constants.Protocols.MOT1}.csv";
    }

    internal class MOT2CsvWriter : CsvWriter<MOT2NodeReader>
    {
        public MOT2CsvWriter(string outputDirectory) : base(outputDirectory) { }

        protected override string FileName => $"{Constants.Protocols.MOT2}.csv";
    }

    internal class MOTGEARCsvWriter : CsvWriter<MOTGEARNodeReader>
    {
        public MOTGEARCsvWriter(string outputDirectory) : base(outputDirectory) { }

        protected override string FileName => $"{Constants.Protocols.MOTGEAR}.csv";
    }
}
