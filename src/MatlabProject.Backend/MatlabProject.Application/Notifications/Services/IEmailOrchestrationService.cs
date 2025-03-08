using MatlabProject.Domain.Common.Exceptions;
using MatlabProject.Application.Notifications.Models;

namespace MatlabProject.Application.Notifications.Services;

public interface IEmailOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(EmailProcessNotificationEvent @event, CancellationToken cancellationToken = default);
}
