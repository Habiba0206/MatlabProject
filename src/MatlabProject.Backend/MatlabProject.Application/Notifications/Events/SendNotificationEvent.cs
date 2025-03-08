using MatlabProject.Application.Notifications.Models;

namespace MatlabProject.Application.Notifications.Events;

public record SendNotificationEvent : NotificationEvent
{
    public NotificationMessage Message { get; set; } = default!;
}
