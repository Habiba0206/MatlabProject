using AutoMapper;
using MatlabProject.Application.Questions.Models;
using MatlabProject.Application.Questions.Queries;
using MatlabProject.Application.Questions.Services;
using MatlabProject.Domain.Common.Queries;

namespace MatlabProject.Infrastructure.Questions.QueryHandlers;

public class QuestionGetByIdQueryHandler(
    IMapper mapper,
    IQuestionService questionService)
    : IQueryHandler<QuestionGetByIdQuery, QuestionDto>
{
    public async Task<QuestionDto> Handle(QuestionGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await questionService.GetByIdAsync(request.QuestionId, cancellationToken: cancellationToken);

        return mapper.Map<QuestionDto>(result);
    }
}
