using Microsoft.Extensions.DependencyInjection;

namespace Trebuchet.Mediation;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMediators(this IServiceCollection services)
    {
        return services.Scan(scan => scan
            .FromCallingAssembly()
            .AddClasses(false)
            .AsMatchingInterface());
    }
}
