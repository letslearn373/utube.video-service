using VideoService.Domain.DbModels;

namespace VideoService.Application.Persistance
{
    public interface IVideoRepository
    {
        Task CreateAsync(Video video, CancellationToken cancellationToken = default);
        Task UpdateAsync(string id, Video video, CancellationToken cancellationToken = default);
        Task<Video> GetAsync(string videoId, CancellationToken cancellationToken = default);
    }
}
