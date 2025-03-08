using MatlabProject.Domain.Enums;
using MatlabProject.Application.Notifications.Events;

namespace MatlabProject.Application.Notifications.Models;

public record EmailProcessNotificationEvent : ProcessNotificationEvent
{
    public EmailProcessNotificationEvent()
    {
        Type = NotificationType.Email;
    }
}