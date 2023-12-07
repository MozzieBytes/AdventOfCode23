using System.IO.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Trebuchet.Configuration;
using Trebuchet.Sanitize;
using Trebuchet.Decypher;
using Trebuchet.Mediation;

namespace Trebuchet.Tests.Helpers;
internal static class TestServiceProvider
{
    static TestServiceProvider()
    {
        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.testing.json")
            .Build();

        services
            .AddSingleton<IConfiguration>(configuration)
            .AddSingleton(Substitute.For<IFileSystem>())
            .AddConfigurationServices(configuration)
            .AddSanitizationServices()
            .AddDecypherServices()
            .AddMediators();

        ServiceProvider = services.BuildServiceProvider();
    }

    public static IServiceProvider ServiceProvider { get; }
}
