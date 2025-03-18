using MatlabProject.Domain.Common.Entities;

namespace MatlabProject.Domain.Entities;

public class TestResult : AuditableEntity
{
    public Guid UserId { get; set; }
    public Guid TestId  { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public float ScorePercentage { get; set; }
    public bool IsPassed { get; set; }
    public User User { get; set; } 
    public Test Test { get; set; }
    public IEnumerable<StudentAnswer> StudentAnswers { get; set; }
    //public Certificate Certificate { get; set; }
}
