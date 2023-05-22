using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using VideoService.Application.Services;
using VideoService.Domain.DbModels;

namespace VideoService.Application.Configuration;

internal class MongoDbConfigurationService : IHostedService
{
    private readonly IMongoCollectionFactory _mongoCollectionFactory;

    public MongoDbConfigurationService(IMongoCollectionFactory mongoCollectionFactory)
    {
        _mongoCollectionFactory = mongoCollectionFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var videoCollection = _mongoCollectionFactory.GetCollection<Video>();
        var indexKeysDefinition = Builders<Video>.IndexKeys.Text(x => x.ObjectRootId);
        await videoCollection.Indexes.CreateOneAsync(new CreateIndexModel<Video>(indexKeysDefinition), cancellationToken: cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
