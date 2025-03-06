using MatlabProject.Domain.Common.Entities;

namespace MatlabProject.Domain.Entities;

public class Question : AuditableEntity
{
    public Guid TestId { get; set; }
    public string Text { get; set; }
    public string CorrectAnswer { get; set; }
    public Test Test { get; set; }
    public IEnumerable<AnswerOption> AnswerOptions { get; set; }
}
