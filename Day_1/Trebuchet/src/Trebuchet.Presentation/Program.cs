using Trebuchet.Presentation;
using Trebuchet.Mediation;
using Trebuchet.Configuration;
using Trebuchet.Decypher;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services
            .AddConfigurationServices(builder.Configuration)
            .AddDecypherServices()
            .AddMediators()
            .AddHostedService<CalibrationWorker>();

        var host = builder.Build();
        host.Run();
    }
}