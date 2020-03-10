using CanBusMonitor.PoC.Parsing;
using CanBusMonitor.PoC.Parsing.Nodes;
using CanBusMonitor.PoC.Parsing.Signals;
using CanBusMonitor.PoC.Parsing.Writers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CanBusMonitor.PoC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start file parsing...");
            var writersPool = new WritersPool(Path.Combine(".", "output"));

            using (var file = new FileStream(Path.Combine(".", "Samples", "Can_500k_Alfa_159.txt"), FileMode.Open))
            using (var fileReader = new StreamReader(file))
            {
                var fileParser = new FileParser();
                var nodeReaderFactory = new NodeReaderFactory();
                while (!fileReader.EndOfStream)
                {
                    var line = fileReader.ReadLine();
                    var message = fileParser.ParseLine(line);
                    try
                    {
                        var nodeReader = nodeReaderFactory.CreateNodeReader(message);
                        Console.WriteLine($"Reading values from {nodeReader.Name}:{nodeReader.Identifier}");

                        writersPool.Write(nodeReader);
                        foreach (var signal in nodeReader.Signals)
                        {
                            Console.WriteLine($"{signal.Name}: {signal}");
                        }
                    }
                    catch (NotSupportedException)
                    {
                        Console.WriteLine($"Line has been ignored: Identifier:{message.Identifier} not supported.");
                    }
                }
            }
            Console.WriteLine("Finish file parsing...");
        }
    }
}