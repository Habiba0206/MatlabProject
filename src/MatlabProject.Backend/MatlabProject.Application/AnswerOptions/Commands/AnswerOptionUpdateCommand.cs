using MatlabProject.Domain.Common.Commands;
using MatlabProject.Application.AnswerOptions.Models;

namespace MatlabProject.Application.AnswerOptions.Commands;

public class AnswerOptionUpdateCommand : ICommand<AnswerOptionDto>
{
    public AnswerOptionDto AnswerOptionDto { get; set; }
}
