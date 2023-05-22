using MongoDB.Driver;
using VideoService.Application.Persistance;
using VideoService.Application.Services;
using VideoService.Domain.DbModels;

namespace VideoService.Infrastructure.Persistance;

public class VideoRepository : IVideoRepository
{
    private IMongoCollection<Video> _collection;

    public VideoRepository(IMongoCollectionFactory factory)
    {
        _collection = factory.GetCollection<Video>();
    }

    public async Task CreateAsync(Video video, CancellationToken cancellationToken = default)
    {
        await _collection.InsertOneAsync(video, cancellationToken: cancellationToken);
    }

    public async Task<Video> GetAsync(string videoId, CancellationToken cancellationToken = default)
    {
        var filter = Builders<Video>.Filter.Eq(x => x.ObjectRootId, videoId);
        var items = await _collection.FindAsync(filter, null, cancellationToken);
        var item = await items.FirstOrDefaultAsync();
        return await Task.FromResult(item);
    }

    public async Task UpdateAsync(string id, Video video, CancellationToken cancellationToken = default)
    {
        await _collection.ReplaceOneAsync(x => x.Id == id, video, cancellationToken: cancellationToken);
    }
}
