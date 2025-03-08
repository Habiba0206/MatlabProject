using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.Notifications.Models;

namespace MatlabProject.Application.Notifications.Queries;

public class EmailTemplateGetByIdQuery : IQuery<EmailTemplateDto?>
{
    public Guid EmailTemplateId { get; set; }
}
