using MatlabProject.Domain.Common.Entities;

namespace MatlabProject.Domain.Entities;

public class Test : AuditableEntity
{
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int DurationMinutes { get; set; }
    public User User { get; set; }
    public IEnumerable<Question> Questions { get; set; }
}
