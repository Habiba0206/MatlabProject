using AutoMapper;
using MatlabProject.Application.StudentAnswers.Models;
using MatlabProject.Application.StudentAnswers.Queries;
using MatlabProject.Application.StudentAnswers.Services;
using MatlabProject.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace MatlabProject.Infrastructure.StudentAnswers.QueryHandlers;

public class StudentAnswerGetQueryHandler(
    IMapper mapper,
    IStudentAnswerService studentAnswerService)
    : IQueryHandler<StudentAnswerGetQuery, ICollection<StudentAnswerDto>>
{
    public async Task<ICollection<StudentAnswerDto>> Handle(StudentAnswerGetQuery request, CancellationToken cancellationToken)
    {
        var result = await studentAnswerService.Get(
            request.StudentAnswerFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<StudentAnswerDto>>(result);
    }
}
