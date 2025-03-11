using MatlabProject.Application.Identity.Services;
using MatlabProject.Application.Notifications.Events;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Enums;
using FluentValidation;

namespace MatlabProject.Infrastructure.Notifications.Validators;

public class NotificationRequestValidator : AbstractValidator<ProcessNotificationEvent>
{
    public NotificationRequestValidator(IUserService userService)
    {
        // TODO : to external
        var templatesRequireSender = new List<NotificationTemplateType>
        {
            NotificationTemplateType.ReferralNotification
        };

        RuleFor(request => request.SenderUserId)
            .NotEqual(Guid.Empty)
            .NotNull()
            .When(request => templatesRequireSender.Contains(request.TemplateType))
            .CustomAsync(
                async (senderUserId, context, cancellationToken) =>
                {
                    var user = await userService.GetByIdAsync(senderUserId, new QueryOptions(QueryTrackingMode.AsNoTracking), cancellationToken);

                    if (user is null)
                        context.AddFailure("Sender user not found");
                }
            );

        RuleFor(request => request.ReceiverUserId)
            .NotEqual(Guid.Empty)
            .CustomAsync(
                async (senderUserId, context, cancellationToken) =>
                {
                    var user = await userService.GetByIdAsync(senderUserId, new QueryOptions(QueryTrackingMode.AsNoTracking), cancellationToken);

                    if (user is null)
                        context.AddFailure("Sender user not found");
                }
            );
    }
}