namespace ReactiveXDemo.UI;

public static class ControlExtensions
{
    public static void BindStart(this Button button, IStartStopAsync startStopAsync)
    {
        UiUpdateState(startStopAsync.IsRunning);
        _ = startStopAsync.RunningStateChangedEvent().SubscribeAsync(UiUpdateState);
        
        button.Click += async (_, _) =>
        {
            if (startStopAsync.IsRunning) return;

            var errorEvent = await startStopAsync.ExecutionErrorEvent()
                .SubscribeAsync((_) => UiError());

            try
            {
                UiReset();
                await startStopAsync.StartAsync(CancellationToken.None);
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

    public static void BindStop(this Button button, IStartStopAsync startStopAsync)
    {
        UiUpdateState(startStopAsync.IsRunning);
        _ = startStopAsync.RunningStateChangedEvent().SubscribeAsync(UiUpdateState);
        
        button.Click += async (_, _) =>
        {
            if (!startStopAsync.IsRunning) return;

            var errorEvent = await startStopAsync.ExecutionErrorEvent()
                .SubscribeAsync((_) => UiError());

            try
            {
                UiReset();
                await startStopAsync.StopAsync(CancellationToken.None);
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

    public static void BindToggle(this Button button, IStartStopAsync startStopAsync)
    {
        UiUpdateState(startStopAsync.IsRunning);
        _ = startStopAsync.RunningStateChangedEvent().SubscribeAsync(UiUpdateState);

        button.Click += async (_, _) =>
        {
            var errorEvent = await startStopAsync.ExecutionErrorEvent()
                .SubscribeAsync((_) => UiError());

            try
            {
                UiReset();
                if (startStopAsync.IsRunning)
                    await startStopAsync.StopAsync(CancellationToken.None);
                else
                    await startStopAsync.StartAsync(CancellationToken.None);
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