using MongoDB.Driver;
using VideoService.Application.Services;
using VideoService.Infrastructure.Settings;

namespace VideoService.Infrastructure.Services
{
    internal class MongoCollectionFactory : IMongoCollectionFactory
    {
        private readonly MongoDbSetting _mongoDbSetting;
        private readonly MongoClient _client;

        public MongoCollectionFactory(MongoDbSetting mongoDbSetting, MongoClient client)
        {
            _mongoDbSetting = mongoDbSetting;
            _client = client;
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return _client.GetDatabase(_mongoDbSetting.DatabaseName).GetCollection<T>(typeof(T).Name);
        }
    }
}
