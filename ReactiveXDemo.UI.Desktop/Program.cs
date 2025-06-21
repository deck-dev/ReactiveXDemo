using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ReactiveXDemo.UI;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var builder = new HostApplicationBuilder();

        builder.Services.AddScoped<FormMain>();
        builder.Services.AddSingleton<IStartStopAsync, FaultyStartStopAsync>();

       var host = builder.Build();
        
       using var scope = host.Services.CreateScope();
       var provider = scope.ServiceProvider;
       
       var form = provider.GetRequiredService<FormMain>();
       
        Application.Run(form);
    }
}