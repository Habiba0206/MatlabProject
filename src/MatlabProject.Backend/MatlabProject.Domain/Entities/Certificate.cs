using MatlabProject.Domain.Common.Entities;

namespace MatlabProject.Domain.Entities;

public class Certificate : AuditableEntity
{
    public Guid UserId { get; set; }
    public Guid TestId { get; set; }
    public DateTimeOffset  IssuedAt { get; set; }
    public string FilePath { get; set; } = default!;
    public User User { get; set; }
    public Test Test { get; set; }
}
