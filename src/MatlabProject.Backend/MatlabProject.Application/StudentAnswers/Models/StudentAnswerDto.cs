namespace MatlabProject.Application.StudentAnswers.Models;

public class StudentAnswerDto
{
    public Guid? Id { get; set; }
    public Guid FormId { get; set; }
    public Guid QuestionId { get; set; }
    public string Value { get; set; }
}
