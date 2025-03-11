using AutoMapper;
using MatlabProject.Application.Identity.Commands;
using MatlabProject.Application.Identity.Models;
using MatlabProject.Application.Identity.Services;
using MatlabProject.Application.Notifications.Commands;
using MatlabProject.Application.Notifications.Models;
using MatlabProject.Application.Notifications.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.Notifications.CommandHandlers;

public class EmailTemplateCreateCommandHandler(
    IMapper mapper,
    IEmailTemplateService emailTemplateService) : ICommandHandler<EmailTemplateCreateCommand, EmailTemplateDto>
{
    public async Task<EmailTemplateDto> Handle(EmailTemplateCreateCommand request, CancellationToken cancellationToken)
    {
        var emailTemplate = mapper.Map<EmailTemplate>(request.EmailTemplateDto);

        var createdEmailTemplate = await emailTemplateService.CreateAsync(emailTemplate, cancellationToken: cancellationToken);

        return mapper.Map<EmailTemplateDto>(createdEmailTemplate);
    }
}
