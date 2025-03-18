using MatlabProject.Domain.Common.Commands;
using MatlabProject.Application.StudentAnswers.Models;

namespace MatlabProject.Application.StudentAnswers.Commands;

public class StudentAnswerUpdateCommand : ICommand<StudentAnswerDto>
{
    public StudentAnswerDto StudentAnswerDto { get; set; }
}
