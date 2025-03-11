using AutoMapper;
using MatlabProject.Application.Notifications.Models;

namespace MatlabProject.Infrastructure.Notifications.Mappers;

public class NotificationMessageMapper : Profile
{
    public NotificationMessageMapper()
    {
        CreateMap<EmailProcessNotificationEvent, EmailMessage>();
    }
}