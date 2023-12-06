using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Trebuchet.Sanitize;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSanitizationServices(this IServiceCollection services)
    {
        return services.Scan(scan => scan
            .FromCallingAssembly()
            .AddClasses(false)
            .AsImplementedInterfaces());
    }
}
