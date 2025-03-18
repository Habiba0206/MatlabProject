using MatlabProject.Domain.Common.Entities;

namespace MatlabProject.Domain.Entities;

public class StudentAnswer : AuditableEntity
{
    public Guid TestResultId { get; set; }
    public Guid QuestionId { get; set; }
    public string SelectedAnswer { get; set; } = default!;
    public bool IsCorrect { get; set; }
    public TestResult TestResult { get; set; }
    public  Question Question { get; set; }
}
