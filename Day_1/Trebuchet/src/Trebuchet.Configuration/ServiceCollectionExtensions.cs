using System.IO.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Trebuchet.Configuration;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddConfigurationServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddSingleton<IFileSystem, FileSystem>()
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
