using MatlabProject.Domain.Common.Exceptions;
using MatlabProject.Domain.Entities;
using MatlabProject.Application.Notifications.Events;
using MatlabProject.Application.Notifications.Models;

namespace MatlabProject.Application.Notifications.Services;

public interface INotificationAggregatorService
{
    public ValueTask<FuncResult<bool>> SendAsync(ProcessNotificationEvent processNotificationEvent, CancellationToken cancellationToken = default);

    public ValueTask<IList<NotificationTemplate>> GetTemplatesByFilterAsync(
        NotificationTemplateFilter notificationTemplateFilter,
        CancellationToken cancellationToken = default
        );
}
