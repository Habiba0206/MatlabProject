using MatlabProject.Domain.Common.Commands;
using MatlabProject.Application.AnswerOptions.Models;

namespace MatlabProject.Application.AnswerOptions.Commands;

public record AnswerOptionCreateCommand : ICommand<AnswerOptionDto>
{
    public AnswerOptionDto AnswerOptionDto { get; set; }
}
