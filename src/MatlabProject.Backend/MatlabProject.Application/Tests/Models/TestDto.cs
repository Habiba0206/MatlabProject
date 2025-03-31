namespace MatlabProject.Application.Tests.Models;

public class TestDto
{
    public Guid? Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int DurationMinutes { get; set; }
}
