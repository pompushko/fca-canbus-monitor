using CanBusMonitor.PoC.Parsing;
using CanBusMonitor.PoC.Parsing.Nodes;
using System;
using System.IO;

namespace CanBusMonitor.PoC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start file parsing...");
            using (var file = new FileStream(".\\Samples\\Can_500k_Alfa_159.txt", FileMode.Open))
            using (var fileReader = new StreamReader(file))
            {
                var fileParser = new FileParser();
                var nodeReaderFactory = new NodeReaderFactory();
                while (!fileReader.EndOfStream)
                {
                    var line = fileReader.ReadLine();
                    var message = fileParser.ParseLine(line);
                    INodeReader nodeReader = null;
                    try
                    {
                        nodeReader = nodeReaderFactory.CreateNodeReader(message);
                    }
                    catch (NotSupportedException)
                    {
                        Console.WriteLine($"Line has been ignored: Identifier:{message.Identifier} not supported.");
                        continue;
                    }

                    Console.WriteLine($"Reading values from {nodeReader.Name}:{nodeReader.Identifier}");
                    foreach (var signal in nodeReader.Signals)
                    {
                        Console.WriteLine(signal.ToString());
                    }
                }
            }
            Console.WriteLine("Finish file parsing...");
        }
    }
}