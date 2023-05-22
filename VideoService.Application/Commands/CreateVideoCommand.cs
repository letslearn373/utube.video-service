using MediatR;
using VideoService.Application.Persistance;
using VideoService.Domain;

namespace VideoService.Application.Commands;

public record CreateVideoCommand(string videoId, string rootVideoPath) : IRequest;

public class CreateVideoCommandHandler : IRequestHandler<CreateVideoCommand>
{
    private readonly IVideoRepository _videoRepository;

    public CreateVideoCommandHandler(IVideoRepository videoRepository)
    {
        _videoRepository = videoRepository;
    }

    public async Task Handle(CreateVideoCommand notification, CancellationToken cancellationToken)
    {
        await _videoRepository.CreateAsync(new Video
        {
            ObjectRootId = notification.videoId,
            UploadDate = DateTime.Now,
            OrigialVideo = notification.rootVideoPath
        });
    }
}
