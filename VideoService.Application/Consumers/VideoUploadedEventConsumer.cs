using MassTransit;
using MediatR;
using UTube.Common.Events;
using VideoService.Application.Commands;

namespace VideoService.Application.Consumers;

public class VideoUploadedEventConsumer : IConsumer<VideoUploadedEvent>
{
    private readonly ISender _sender;

    public VideoUploadedEventConsumer(ISender sender)
    {
        _sender = sender;
    }
    public async Task Consume(ConsumeContext<VideoUploadedEvent> context)
    {
        await _sender.Send(new CreateVideoCommand(context.Message.videoId, context.Message.objectPath));
        await Task.CompletedTask;
    }
}