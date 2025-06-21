using System.Runtime.CompilerServices;

namespace ClassLibrary1;

public interface IDevice
{
    bool IsRunning { get; }
    Task StartAsync(CancellationToken cancellationToken);
    Task StopAsync(CancellationToken cancellationToken);

    IAsyncObservable<bool> RunningStateChangedEvent();
    IAsyncObservable<Exception> ExecutionErrorEvent();
}