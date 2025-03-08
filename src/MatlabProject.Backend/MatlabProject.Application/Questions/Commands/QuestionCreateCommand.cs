using MatlabProject.Domain.Common.Commands;
using MatlabProject.Application.Questions.Models;

namespace MatlabProject.Application.Questions.Commands;

public record QuestionCreateCommand : ICommand<QuestionDto>
{
    public QuestionDto QuestionDto { get; set; }
}
