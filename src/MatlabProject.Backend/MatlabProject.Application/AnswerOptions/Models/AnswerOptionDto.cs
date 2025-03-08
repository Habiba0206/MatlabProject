namespace MatlabProject.Application.AnswerOptions.Models;

public class AnswerOptionDto
{
    public Guid? Id { get; set; }
    public Guid QuestionId { get; set; }
    public string Text { get; set; } = default!;
}
