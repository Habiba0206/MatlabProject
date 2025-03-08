using MatlabProject.Domain.Common.Commands;
using MatlabProject.Application.Notifications.Models;

namespace MatlabProject.Application.Notifications.Commands;

public class EmailTemplateCreateCommand : ICommand<EmailTemplateDto>
{
    public EmailTemplateDto EmailTemplateDto { get; set; }
}
