using AutoMapper;
using MatlabProject.Application.Common.EventBus.Brokers;
using MatlabProject.Application.Common.Settings;
using MatlabProject.Application.Notifications.Events;
using MatlabProject.Application.Notifications.Models;
using MatlabProject.Application.Notifications.Services;
using MatlabProject.Domain.Common.Events;
using MatlabProject.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MatlabProject.Infrastructure.Notifications.EventHandlers;

public class SendNotificationEventHandler(
    IServiceScopeFactory serviceScopeFactory,
    IMapper mapper,
    IOptions<NotificationSubscriberSettings> notificationSubscriberSettings,
    IEventBusBroker eventBusBroker,
    IOptions<NotificationSettings> notificationSettings
) : EventHandlerBase<SendNotificationEvent>
{
    protected override async ValueTask HandleAsync(SendNotificationEvent @event, CancellationToken cancellationToken)
    {
        await using var scope = serviceScopeFactory.CreateAsyncScope();
        var emailSenderService = scope.ServiceProvider.GetRequiredService<IEmailSenderService>();
        var emailHistoryService = scope.ServiceProvider.GetRequiredService<IEmailHistoryService>();

        if (@event.Message is EmailMessage emailMessage)
        {
            await emailSenderService.SendAsync(emailMessage, cancellationToken);

            var history = mapper.Map<EmailHistory>(emailMessage);
            history.SenderUserId = @event.SenderUserId;
            history.ReceiverUserId = @event.ReceiverUserId;

            Console.WriteLine($"TEMPLATE YES?: {history.TemplateId}");

            //await emailHistoryService.CreateAsync(history, cancellationToken: cancellationToken);

            if (!history.IsSuccessful) throw new InvalidOperationException("Email history is not created");
        }
    }
}
