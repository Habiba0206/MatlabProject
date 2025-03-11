using AutoMapper;
using MatlabProject.Application.AnswerOptions.Models;
using MatlabProject.Application.AnswerOptions.Queries;
using MatlabProject.Application.AnswerOptions.Services;
using MatlabProject.Domain.Common.Queries;

namespace MatlabProject.Infrastructure.AnswerOptions.QueryHandlers;

public class AnswerOptionGetByIdQueryHandler(
    IMapper mapper,
    IAnswerOptionService answerOptionService)
    : IQueryHandler<AnswerOptionGetByIdQuery, AnswerOptionDto>
{
    public async Task<AnswerOptionDto> Handle(AnswerOptionGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await answerOptionService.GetByIdAsync(request.AnswerOptionId, cancellationToken: cancellationToken);

        return mapper.Map<AnswerOptionDto>(result);
    }
}
