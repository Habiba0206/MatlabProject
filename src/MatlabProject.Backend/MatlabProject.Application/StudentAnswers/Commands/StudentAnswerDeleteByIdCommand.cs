using MatlabProject.Domain.Common.Commands;

namespace MatlabProject.Application.StudentAnswers.Commands;

public class StudentAnswerDeleteByIdCommand : ICommand<bool>
{
    public Guid StudentAnswerId { get; set; }
}
