using AutoMapper;
using MatlabProject.Application.Notifications.Models;
using MatlabProject.Application.Notifications.Queries;
using MatlabProject.Application.Notifications.Services;
using MatlabProject.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace MatlabProject.Infrastructure.Notifications.QueryHandlers;

public class EmailTemplateGetQueryHandler(
    IMapper mapper,
    IEmailTemplateService emailTemplateService)
    : IQueryHandler<EmailTemplateGetQuery, ICollection<EmailTemplateDto>>
{
    public async Task<ICollection<EmailTemplateDto>> Handle(EmailTemplateGetQuery request, CancellationToken cancellationToken)
    {
        var result = await emailTemplateService.Get(
            request.EmailTemplateFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<EmailTemplateDto>>(result);
    }
}
