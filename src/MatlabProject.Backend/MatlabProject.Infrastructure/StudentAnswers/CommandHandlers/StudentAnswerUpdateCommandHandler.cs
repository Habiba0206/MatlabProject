using AutoMapper;
using MatlabProject.Application.StudentAnswers.Commands;
using MatlabProject.Application.StudentAnswers.Models;
using MatlabProject.Application.StudentAnswers.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.StudentAnswers.CommandHandlers;

public class StudentAnswerUpdateCommandHandler(
    IMapper mapper,
    IStudentAnswerService studentAnswerService) : ICommandHandler<StudentAnswerUpdateCommand, StudentAnswerDto>
{
    public async Task<StudentAnswerDto> Handle(StudentAnswerUpdateCommand request, CancellationToken cancellationToken)
    {
        var studentAnswer = mapper.Map<StudentAnswer>(request.StudentAnswerDto);

        var createdStudentAnswer = await studentAnswerService.UpdateAsync(studentAnswer, cancellationToken: cancellationToken);

        return mapper.Map<StudentAnswerDto>(createdStudentAnswer);
    }
}
