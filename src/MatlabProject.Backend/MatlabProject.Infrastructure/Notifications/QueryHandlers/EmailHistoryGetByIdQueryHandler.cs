using AutoMapper;
using MatlabProject.Application.Notifications.Models;
using MatlabProject.Application.Notifications.Queries;
using MatlabProject.Application.Notifications.Services;
using MatlabProject.Domain.Common.Queries;

namespace MatlabProject.Infrastructure.Notifications.QueryHandlers;

public class EmailHistoryGetByIdQueryHandler(
    IMapper mapper,
    IEmailHistoryService emailHistoryService)
    : IQueryHandler<EmailHistoryGetByIdQuery, EmailHistoryDto>
{
    public async Task<EmailHistoryDto> Handle(EmailHistoryGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await emailHistoryService.GetByIdAsync(request.EmailHistoryId, cancellationToken: cancellationToken);

        return mapper.Map<EmailHistoryDto>(result);
    }
}
