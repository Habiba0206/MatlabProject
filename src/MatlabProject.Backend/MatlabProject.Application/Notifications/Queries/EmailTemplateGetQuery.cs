using MatlabProject.Application.Identity.Models;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.Notifications.Models;

namespace MatlabProject.Application.Notifications.Queries;

public class EmailTemplateGetQuery : IQuery<ICollection<EmailTemplateDto>>
{
    public EmailTemplateFilter EmailTemplateFilter { get; set; }
}
