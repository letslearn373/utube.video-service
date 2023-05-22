using MongoDB.Driver;

namespace VideoService.Application.Services;

public interface IMongoCollectionFactory
{
    IMongoCollection<T> GetCollection<T>();
}
