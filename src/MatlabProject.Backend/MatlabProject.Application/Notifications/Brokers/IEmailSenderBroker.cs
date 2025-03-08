using MatlabProject.Application.Notifications.Models;

namespace MatlabProject.Application.Notifications.Brokers;

public interface IEmailSenderBroker
{
    ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}