using System.Reactive.Linq;
using Accessibility;
using ReactiveDemo;

namespace ReactiveDemo.UI;

public static class ControlExtensions
{
    public static void BindStart(this Button button, IDevice device)
    {
        UiUpdateState(device.IsRunning);
        _ = device.RunningStateChangedEvent().SubscribeAsync(UiUpdateState);
        
        button.Click += async (_, _) =>
        {
            if (device.IsRunning) return;

            var errorEvent = await device.ExecutionErrorEvent()
                .SubscribeAsync((_) => UiError());

            try
            {
                UiReset();
                await device.StartAsync(CancellationToken.None);
            }
            finally
            {
                await errorEvent.DisposeAsync();
                button.Enabled = true;
            }
        };
        
        return;

        void UiReset()
        {
            button.FlatAppearance.BorderColor = Color.Black;
            button.Enabled = false;
            button.BackColor = Color.Transparent;
        }

        void UiUpdateState(bool state)
        {
            button.FlatAppearance.BorderColor = Color.Black;
            button.BackColor = state ? Color.GreenYellow : Color.Transparent;
        }

        void UiError()
        {
            button.FlatAppearance.BorderColor = Color.Red;
        }
    }

    public static void BindStop(this Button button, IDevice device)
    {
        UiUpdateState(device.IsRunning);
        _ = device.RunningStateChangedEvent().SubscribeAsync(UiUpdateState);
        
        button.Click += async (_, _) =>
        {
            if (!device.IsRunning) return;

            var errorEvent = await device.ExecutionErrorEvent()
                .SubscribeAsync((_) => UiError());

            try
            {
                UiReset();
                await device.StopAsync(CancellationToken.None);
            }
            finally
            {
                await errorEvent.DisposeAsync();
                button.Enabled = true;
            }
        };
        
        return;
        
        void UiReset()
        {
            button.FlatAppearance.BorderColor = Color.Black;
            button.Enabled = false;
            button.BackColor = Color.Transparent;
        }

        void UiUpdateState(bool state)
        {
            button.FlatAppearance.BorderColor = Color.Black;
            button.BackColor = !state ? Color.GreenYellow : Color.Transparent;
        }

        void UiError()
        {
            button.FlatAppearance.BorderColor = Color.Red;
        }
    }

    public static void BindToggle(this Button button, IDevice device)
    {
        UiUpdateState(device.IsRunning);
        _ = device.RunningStateChangedEvent().SubscribeAsync(UiUpdateState);

        button.Click += async (_, _) =>
        {
            var errorEvent = await device.ExecutionErrorEvent()
                .SubscribeAsync((_) => UiError());

            try
            {
                UiReset();
                if (device.IsRunning)
                    await device.StopAsync(CancellationToken.None);
                else
                    await device.StartAsync(CancellationToken.None);
            }
            finally
            {
                await errorEvent.DisposeAsync();
                button.Enabled = true;
            }
        };
        
        return;

        void UiReset()
        {
            button.FlatAppearance.BorderColor = Color.Black;
            button.Enabled = false;
        }

        void UiUpdateState(bool state)
        {
            button.FlatAppearance.BorderColor = Color.Black;
            button.BackColor = state ? Color.GreenYellow : Color.Transparent;
        }

        void UiError()
        {
            button.FlatAppearance.BorderColor = Color.Red;
        }
    }
}