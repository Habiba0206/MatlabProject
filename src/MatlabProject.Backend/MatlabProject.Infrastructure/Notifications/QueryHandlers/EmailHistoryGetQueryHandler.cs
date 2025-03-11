using AutoMapper;
using MatlabProject.Application.Notifications.Models;
using MatlabProject.Application.Notifications.Queries;
using MatlabProject.Application.Notifications.Services;
using MatlabProject.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace MatlabProject.Infrastructure.Notifications.QueryHandlers;

public class EmailHistoryGetQueryHandler(
    IMapper mapper,
    IEmailHistoryService emailHistoryService)
    : IQueryHandler<EmailHistoryGetQuery, ICollection<EmailHistoryDto>>
{
    public async Task<ICollection<EmailHistoryDto>> Handle(EmailHistoryGetQuery request, CancellationToken cancellationToken)
    {
        var result = await emailHistoryService.Get(
            request.EmailHistoryFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<EmailHistoryDto>>(result);
    }
}
