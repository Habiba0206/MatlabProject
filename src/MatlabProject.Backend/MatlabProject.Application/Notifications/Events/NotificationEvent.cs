using MatlabProject.Domain.Common.Events;

namespace MatlabProject.Application.Notifications.Events;

public record NotificationEvent : EventBase
{
    public Guid SenderUserId { get; set; }

    public Guid ReceiverUserId { get; set; }
}
