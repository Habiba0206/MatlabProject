using MatlabProject.Domain.Enums;
using MatlabProject.Domain.Common.Queries;

namespace MatlabProject.Application.Notifications.Models;

public class NotificationTemplateFilter : FilterPagination
{
    public IList<NotificationType> TemplateType { get; set; }
}