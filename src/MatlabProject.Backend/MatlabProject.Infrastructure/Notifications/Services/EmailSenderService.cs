﻿using MatlabProject.Application.Notifications.Brokers;
using MatlabProject.Application.Notifications.Models;
using MatlabProject.Application.Notifications.Services;
using MatlabProject.Domain.Extensions;
using MatlabProject.Domain.Enums;
using FluentValidation;

namespace MatlabProject.Infrastructure.Notifications.Services;

public class EmailSenderService(IEnumerable<IEmailSenderBroker> emailSenderBrokers, IValidator<EmailMessage> emailMessageValidator) : IEmailSenderService
{
    private readonly IValidator<EmailMessage> _emailMessageValidator = emailMessageValidator;
    private readonly IEnumerable<IEmailSenderBroker> _emailSenderBrokers = emailSenderBrokers;

    public async ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default)
    {
        var validationResult = _emailMessageValidator.Validate(
            emailMessage,
            options => options.IncludeRuleSets(NotificationProcessingEvent.OnSending.ToString())
        );
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        foreach (var emailSenderBroker in _emailSenderBrokers)
        {
            var sendNotificationTask = () => emailSenderBroker.SendAsync(emailMessage, cancellationToken);
            var result = await sendNotificationTask.GetValueAsync();

            emailMessage.IsSuccessful = result.IsSuccess;
            emailMessage.ErrorMessage = result.Exception?.Message;
            return result.IsSuccess;
        }

        return false;
    }
}