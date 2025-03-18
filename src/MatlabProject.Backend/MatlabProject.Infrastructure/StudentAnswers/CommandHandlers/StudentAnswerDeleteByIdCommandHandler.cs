using MatlabProject.Application.StudentAnswers.Commands;
using MatlabProject.Application.StudentAnswers.Services;
using MatlabProject.Domain.Common.Commands;

namespace MatlabProject.Infrastructure.StudentAnswers.CommandHandlers;

public class StudentAnswerDeleteByIdCommandHandler(
    IStudentAnswerService studentAnswerService)
    : ICommandHandler<StudentAnswerDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(StudentAnswerDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await studentAnswerService.DeleteByIdAsync(request.StudentAnswerId, cancellationToken: cancellationToken);

        return result is not null;
    }
}