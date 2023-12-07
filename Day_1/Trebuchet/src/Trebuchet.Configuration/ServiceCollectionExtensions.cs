using System.IO.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Trebuchet.Configuration;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfigurationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.TryAddSingleton<IFileSystem, FileSystem>();
        return services
            .Configure<TrebuchetOptions>(options =>
            {
                var section = configuration.GetSection(nameof(TrebuchetOptions));

                section.Bind(options);
            })
            .Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(false)
                .AsMatchingInterface());
    }
}
