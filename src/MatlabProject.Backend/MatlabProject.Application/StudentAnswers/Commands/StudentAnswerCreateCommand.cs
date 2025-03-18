using MatlabProject.Domain.Common.Commands;
using MatlabProject.Application.StudentAnswers.Models;

namespace MatlabProject.Application.StudentAnswers.Commands;

public record StudentAnswerCreateCommand : ICommand<StudentAnswerDto>
{
    public StudentAnswerDto StudentAnswerDto { get; set; }
}
