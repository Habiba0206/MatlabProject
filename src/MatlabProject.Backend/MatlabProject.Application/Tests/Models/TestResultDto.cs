namespace MatlabProject.Application.Tests.Models;

public class TestResultDto
{
    public Guid? Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TestId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public float ScorePercentage { get; set; }
    public bool IsPassed { get; set; }
}
