using Mapster;
using MediatR;
using VideoService.Application.Dtos;
using VideoService.Application.Persistance;

namespace VideoService.Application.Queries;

public record GetVideoQuery(string videoId) : IRequest<VideoDto>;

public class GetVideoQueryHandler : IRequestHandler<GetVideoQuery, VideoDto>
{
    private readonly IVideoRepository _videoRepository;

    public GetVideoQueryHandler(IVideoRepository videoRepository)
    {
        _videoRepository = videoRepository;
    }

    public async Task<VideoDto> Handle(GetVideoQuery query, CancellationToken cancellationToken)
    {
        var video = await _videoRepository.GetAsync(query.videoId, cancellationToken);
        return await Task.FromResult(video.Adapt<VideoDto>());
    }
}