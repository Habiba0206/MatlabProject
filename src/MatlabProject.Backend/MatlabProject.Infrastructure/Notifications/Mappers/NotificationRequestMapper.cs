using AutoMapper;
using MatlabProject.Application.Notifications.Events;
using MatlabProject.Application.Notifications.Models;

namespace MatlabProject.Infrastructure.Notifications.Mappers;

public class NotificationRequestMapper : Profile
{
    public NotificationRequestMapper()
    {
        CreateMap<ProcessNotificationEvent, EmailProcessNotificationEvent>();
    }
}