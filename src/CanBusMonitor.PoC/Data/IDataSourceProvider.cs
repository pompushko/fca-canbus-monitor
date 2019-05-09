using CanBusMonitor.PoC.Parsing;
using System;
using System.Threading.Tasks;

namespace CanBusMonitor.PoC.Data
{
    public interface IDataSourceProvider : IDisposable
    {
        Task StartAsync();
        Task StopAsync();
        ISubscriptionHandler Subscribe(int messageIdentifier, Func<CanMessage, Task> callback);
    }
}