using AutoMapper;
using MatlabProject.Application.Notifications.Models;
using MatlabProject.Application.Notifications.Queries;
using MatlabProject.Application.Notifications.Services;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Infrastructure.Notifications.Services;

namespace MatlabProject.Infrastructure.Notifications.QueryHandlers;

public class EmailTemplateGetByIdQueryHandler(
    IMapper mapper,
    IEmailTemplateService emailTemplateService)
    : IQueryHandler<EmailTemplateGetByIdQuery, EmailTemplateDto>
{
    public async Task<EmailTemplateDto> Handle(EmailTemplateGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await emailTemplateService.GetByIdAsync(request.EmailTemplateId, cancellationToken: cancellationToken);

        return mapper.Map<EmailTemplateDto>(result);
    }
}

