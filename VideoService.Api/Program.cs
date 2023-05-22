using MediatR;
using VideoService.Api;
using VideoService.Application;
using VideoService.Application.Queries;
using VideoService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation(builder.Configuration)
        .AddApplication(builder.Configuration)
        .AddInfrastructure(builder.Configuration);
};

var app = builder.Build();
{
    app.MapGet("/video/{id:Guid}", async (Guid id, ISender sender) =>
    {
        return await sender.Send(new GetVideoQuery(id.ToString()));
    });

    app.Run();
}

