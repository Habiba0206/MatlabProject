using MatlabProject.Domain.Common.Entities;

namespace MatlabProject.Domain.Entities;

public class Test : AuditableEntity
{
    public string Title { get; set; }
    public IEnumerable<Question> Questions { get; set; }
}
