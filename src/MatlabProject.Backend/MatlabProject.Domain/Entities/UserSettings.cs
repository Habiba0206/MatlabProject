using MatlabProject.Domain.Common.Entities;
using MatlabProject.Domain.Enums;

namespace MatlabProject.Domain.Entities;

public class UserSettings : IEntity
{
    public NotificationType? PreferredNotificationType { get; set; }

    /// <summary>
    ///     Gets or sets the user Id
    /// </summary>
    public Guid Id { get; set; }
}