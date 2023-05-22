using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoService.Application.Configuration;

namespace VideoService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        services.AddHostedService<MongoDbConfigurationService>();

        return services;
    }
}
