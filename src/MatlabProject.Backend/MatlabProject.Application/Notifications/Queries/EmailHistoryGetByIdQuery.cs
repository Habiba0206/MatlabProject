using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.Notifications.Models;

namespace MatlabProject.Application.Notifications.Queries;

public class EmailHistoryGetByIdQuery : IQuery<EmailHistoryDto?>
{
    public Guid EmailHistoryId { get; set; }
}
