using MatlabProject.Domain.Enums;

namespace MatlabProject.Application.Questions.Models;

public class QuestionDto
{
    public Guid? Id { get; set; }
    public Guid TestId { get; set; }
    public string Text { get; set; }
    public string CorrectAnswer { get; set; }
}
