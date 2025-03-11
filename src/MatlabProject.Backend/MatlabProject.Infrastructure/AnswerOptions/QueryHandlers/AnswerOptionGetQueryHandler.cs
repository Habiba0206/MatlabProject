using AutoMapper;
using MatlabProject.Application.AnswerOptions.Models;
using MatlabProject.Application.AnswerOptions.Queries;
using MatlabProject.Application.AnswerOptions.Services;
using MatlabProject.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace MatlabProject.Infrastructure.AnswerOptions.QueryHandlers;

public class AnswerOptionGetQueryHandler(
    IMapper mapper,
    IAnswerOptionService answerService)
    : IQueryHandler<AnswerOptionGetQuery, ICollection<AnswerOptionDto>>
{
    public async Task<ICollection<AnswerOptionDto>> Handle(AnswerOptionGetQuery request, CancellationToken cancellationToken)
    {
        var result = await answerService.Get(
            request.AnswerOptionFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<AnswerOptionDto>>(result);
    }
}
