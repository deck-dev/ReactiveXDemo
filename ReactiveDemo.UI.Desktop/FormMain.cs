using System.Reactive.Linq;
using ReactiveDemo;
using Microsoft.Extensions.Logging;

namespace ReactiveDemo.UI;

public partial class FormMain : Form
{
    private readonly ILogger<FormMain> _logger;
    private readonly IDevice _device;

    public FormMain(
        IDevice device,
        ILogger<FormMain> logger)
    {
        InitializeComponent();
        
        _device = device;
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
        
        btnToggle.BindToggle(_device);
        btnStart.BindStart(_device);
        btnStop.BindStop(_device);
    }
}