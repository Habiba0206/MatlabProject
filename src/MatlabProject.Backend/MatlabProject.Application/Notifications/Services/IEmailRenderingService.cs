using MatlabProject.Application.Notifications.Models;

namespace MatlabProject.Application.Notifications.Services;

public interface IEmailRenderingService
{
    ValueTask<string> RenderAsync(
        EmailMessage emailMessage,
        CancellationToken cancellationToken = default
    );
}