using MatlabProject.Domain.Common.Entities;

namespace MatlabProject.Domain.Entities;

public class AnswerOption : AuditableEntity
{
    public Guid QuestionId { get; set; }
    public string Text { get; set; } = default!;
    public Question Question { get; set; }
}
