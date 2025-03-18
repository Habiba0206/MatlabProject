using AutoMapper;
using MatlabProject.Application.StudentAnswers.Models;
using MatlabProject.Application.StudentAnswers.Queries;
using MatlabProject.Application.StudentAnswers.Services;
using MatlabProject.Domain.Common.Queries;

namespace MatlabProject.Infrastructure.StudentAnswers.QueryHandlers;

public class StudentAnswerGetByIdQueryHandler(
    IMapper mapper,
    IStudentAnswerService studentAnswerService)
    : IQueryHandler<StudentAnswerGetByIdQuery, StudentAnswerDto>
{
    public async Task<StudentAnswerDto> Handle(StudentAnswerGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await studentAnswerService.GetByIdAsync(request.StudentAnswerId, cancellationToken: cancellationToken);

        return mapper.Map<StudentAnswerDto>(result);
    }
}
