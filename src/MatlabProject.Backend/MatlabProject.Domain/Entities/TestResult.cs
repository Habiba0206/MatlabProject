using MatlabProject.Domain.Common.Entities;

namespace MatlabProject.Domain.Entities;

public class TestResult : AuditableEntity
{
    public Guid UserId { get; set; }
    public Guid TestId  { get; set; }
    public float ScorePercentage { get; set; }
    public bool Passed { get; set; }
    public User User { get; set; } 
    public Test Test { get; set; }
}
