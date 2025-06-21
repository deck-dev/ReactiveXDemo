using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ReactiveDemo;

public class FaultyStartStopAsync : IStartStopAsync, IDisposable
{
    public bool IsRunning { get; private set; }

    private readonly Subject<bool> _runningStateChangedEvent = new();
    private readonly Subject<Exception> _executionErrorEvent = new();

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            if (Random.Shared.Next() % 10 == 0)
                throw new Exception();
            
            await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
            IsRunning = true;
            _runningStateChangedEvent.OnNext(IsRunning);
        }
        catch (Exception ex)
        {
            _executionErrorEvent.OnNext(ex);
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        try
        {
            if (Random.Shared.Next() % 10 == 0)
                throw new Exception();
            
            await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
            IsRunning = false;
            _runningStateChangedEvent.OnNext(IsRunning);
        }
        catch (Exception ex)
        {
            _executionErrorEvent.OnNext(ex);
        }
    }

    public IAsyncObservable<bool> RunningStateChangedEvent() => 
        _runningStateChangedEvent.ToAsyncObservable();

    public IAsyncObservable<Exception> ExecutionErrorEvent() =>
        _executionErrorEvent.ToAsyncObservable();

    #region Dispose

    private bool _disposed;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing)
        {
            _runningStateChangedEvent.Dispose();
            _executionErrorEvent.Dispose();
        }

        _disposed = true;
    }

    #endregion
}