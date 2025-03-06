using Type = MatlabProject.Domain.Enums.NotificationType;

namespace MatlabProject.Domain.Entities;

public class EmailTemplate : NotificationTemplate
{
    public EmailTemplate()
    {
        Type = Type.Email;
    }

    public string Subject { get; set; } = default!;
}