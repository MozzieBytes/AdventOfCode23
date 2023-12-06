using Microsoft.Extensions.DependencyInjection;

namespace Trebuchet.Decypher;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDecypherServices(this IServiceCollection services)
    {
        return services.Scan(scan => scan
            .FromCallingAssembly()
            .AddClasses(false)
            .AsMatchingInterface());
    }
}
