namespace ReactiveDemo;

public interface IStartStopAsync
{
    bool IsRunning { get; }
    Task StartAsync(CancellationToken cancellationToken);
    Task StopAsync(CancellationToken cancellationToken);

    IAsyncObservable<bool> RunningStateChangedEvent();
    IAsyncObservable<Exception> ExecutionErrorEvent();
}