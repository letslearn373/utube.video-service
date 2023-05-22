using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using VideoService.Application.Consumers;
using VideoService.Application.Persistance;
using VideoService.Application.Services;
using VideoService.Infrastructure.Persistance;
using VideoService.Infrastructure.Services;
using VideoService.Infrastructure.Settings;

namespace VideoService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        #region MassTransit

        var rabbitMQSetting = new RabbitMQSetting();
        configuration.GetSection(nameof(RabbitMQSetting)).Bind(rabbitMQSetting);
        services.AddSingleton(rabbitMQSetting);

        services.AddMassTransit(x =>
        {
            x.AddConsumer<VideoUploadedEventConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMQSetting.Endpoint, rabbitMQSetting.VirtualHost, h =>
                {
                    h.Username(rabbitMQSetting.Username);
                    h.Password(rabbitMQSetting.Password);
                });

                cfg.ConfigureEndpoints(context);
            });

        });

        #endregion

        #region MongoDB

        var mongoDbsetting = new MongoDbSetting();
        configuration.GetSection(nameof(MongoDbSetting)).Bind(mongoDbsetting);
        services.AddSingleton(mongoDbsetting);
        services.AddSingleton<MongoClient>(_ =>
        {
            return new MongoClient(mongoDbsetting.ConnectionString);
        });

        #endregion

        services.AddTransient<IMongoCollectionFactory, MongoCollectionFactory>();
        services.AddTransient<IVideoRepository, VideoRepository>();

        return services;
    }
}
