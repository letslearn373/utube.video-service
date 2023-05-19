using MassTransit;
using System.Diagnostics;
using UTube.Common.Events;

namespace VideoService.Application.Consumers;

public class VideoUploadedEventConsumer : IConsumer<VideoUploadedEvent>
{
    public async Task Consume(ConsumeContext<VideoUploadedEvent> context)
    {
        Debug.WriteLine(context.Message.videoId);
        await Task.CompletedTask;
    }
}