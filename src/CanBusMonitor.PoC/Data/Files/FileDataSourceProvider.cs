using CanBusMonitor.PoC.Parsing;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace CanBusMonitor.PoC.Data.Files
{
    public class FileDataSourceProvider : IDataSourceProvider
    {
        private TimeSpan _messageDelay;
        private string _fileName;
        private Task _task;
        private CancellationTokenSource _taskCancellationTokenSource;
        private ConcurrentDictionary<int, Func<CanMessage, Task>> _subscriptions;
        

        public FileDataSourceProvider(string fileName) : this(fileName, TimeSpan.Zero)
        {

        }

        public FileDataSourceProvider(string fileName, TimeSpan messageDelay)
        {
            _messageDelay = messageDelay;
            _fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
            _subscriptions = new ConcurrentDictionary<int, Func<CanMessage, Task>>();
        }

        public Task StartAsync()
        {
            if (_task == null)
            {
                _taskCancellationTokenSource = new CancellationTokenSource();
                _task = Task.Run(async () => await ProcessFileAsync(_taskCancellationTokenSource.Token), _taskCancellationTokenSource.Token);
            }
            return Task.CompletedTask;
        }

        public async Task StopAsync()
        {
            if (_task != null)
            {
                if (_taskCancellationTokenSource != null)
                {
                    _taskCancellationTokenSource.Cancel();
                    _taskCancellationTokenSource.Dispose();
                    _taskCancellationTokenSource = null;
                }

                try
                {
                    await _task;
                }
                catch (Exception)
                {
                    //ignore
                }
                finally
                {
                    _task = null;
                }
            }
        }

        public ISubscriptionHandler Subscribe(int messageIdentifier, Func<CanMessage, Task> callback)
        {
            return null;
            //_subscriptions.TryAdd(messageIdentifier,callback)
        }

        public void Dispose()
        {

        }

        private async Task ProcessFileAsync(CancellationToken cancellationToken)
        {
            using (var fileReader = new StreamReader(_fileName))
            {
                while (!fileReader.EndOfStream)
                {
                    var line = fileReader.ReadLine();
                    var message = ParseLine(line);
                    if (_subscriptions.TryGetValue(message.Identifier, out var callback))
                    {
                        await callback(message);
                    }
                }
            }
        }

        private CanMessage ParseLine(string line)
        {
            var lineParts = line.Split(new char[] { ' ', '\u0002' }, StringSplitOptions.RemoveEmptyEntries);
            var bytesCount = byte.Parse(lineParts[1]);
            return new CanMessage
            {
                Identifier = int.Parse(lineParts[0], System.Globalization.NumberStyles.HexNumber),
                DataLength = bytesCount,
                Data = new BitArray(Enumerable.Range(2, bytesCount).Select(index => byte.Parse(lineParts[index], System.Globalization.NumberStyles.HexNumber)).ToArray()),
                Counter = int.Parse(lineParts[2 + bytesCount])
            };
        }
    }
}