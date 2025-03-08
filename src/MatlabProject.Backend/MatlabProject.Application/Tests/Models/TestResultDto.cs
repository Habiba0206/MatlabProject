namespace MatlabProject.Application.Tests.Models;

public class TestResultDto
{
    public Guid? Id { get; set; }
    public Guid FormId { get; set; }
    public Guid QuestionId { get; set; }
    public string Value { get; set; }
}
