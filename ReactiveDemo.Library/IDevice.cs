using System.Runtime.CompilerServices;

namespace ReactiveDemo;

public interface IDevice
{
    bool IsRunning { get; }
    Task StartAsync(CancellationToken cancellationToken);
    Task StopAsync(CancellationToken cancellationToken);

    IAsyncObservable<bool> RunningStateChangedEvent();
    IAsyncObservable<Exception> ExecutionErrorEvent();
}