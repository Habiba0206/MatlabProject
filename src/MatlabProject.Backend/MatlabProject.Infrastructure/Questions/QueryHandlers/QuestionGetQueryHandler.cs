using AutoMapper;
using MatlabProject.Application.Questions.Models;
using MatlabProject.Application.Questions.Queries;
using MatlabProject.Application.Questions.Services;
using MatlabProject.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace MatlabProject.Infrastructure.Questions.QueryHandlers;

public class QuestionGetQueryHandler(
    IMapper mapper,
    IQuestionService questionService)
    : IQueryHandler<QuestionGetQuery, ICollection<QuestionDto>>
{
    public async Task<ICollection<QuestionDto>> Handle(QuestionGetQuery request, CancellationToken cancellationToken)
    {
        var result = await questionService.Get(
            request.QuestionFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<QuestionDto>>(result);
    }
}
