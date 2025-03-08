using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.Notifications.Models;

namespace MatlabProject.Application.Notifications.Queries;

public class EmailHistoryGetQuery : IQuery<ICollection<EmailHistoryDto>>
{
    public EmailHistoryFilter EmailHistoryFilter { get; set; }
}
