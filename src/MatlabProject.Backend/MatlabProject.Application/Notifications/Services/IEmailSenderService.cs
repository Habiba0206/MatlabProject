using MatlabProject.Application.Notifications.Models;

namespace MatlabProject.Application.Notifications.Services;

public interface IEmailSenderService
{
    ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}
