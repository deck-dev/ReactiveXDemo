using Microsoft.Extensions.Logging;

namespace ReactiveXDemo.UI;

public partial class FormMain : Form
{
    private readonly ILogger<FormMain> _logger;
    private readonly IStartStopAsync _startStopAsync;

    public FormMain(
        IStartStopAsync startStopAsync,
        ILogger<FormMain> logger)
    {
        InitializeComponent();
        
        _startStopAsync = startStopAsync;
        _logger = logger;

        // var timer = Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(2));
        // timer.Subscribe(async (ticks) =>
        // {
        //     if (_device.IsRunning)
        //         await _device.StopAsync(CancellationToken.None);
        //     else
        //         await _device.StartAsync(CancellationToken.None);
        // });
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        
        btnToggle.BindToggle(_startStopAsync);
        btnStart.BindStart(_startStopAsync);
        btnStop.BindStop(_startStopAsync);
    }
}