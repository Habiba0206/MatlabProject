using MatlabProject.Domain.Common.Commands;
using MatlabProject.Application.Questions.Models;

namespace MatlabProject.Application.Questions.Commands;

public class QuestionUpdateCommand : ICommand<QuestionDto>
{
    public QuestionDto QuestionDto { get; set; }
}
