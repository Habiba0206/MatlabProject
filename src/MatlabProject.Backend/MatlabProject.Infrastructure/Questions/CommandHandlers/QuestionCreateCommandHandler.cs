using AutoMapper;
using MatlabProject.Application.Questions.Commands;
using MatlabProject.Application.Questions.Models;
using MatlabProject.Application.Questions.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.Questions.CommandHandlers;

public class QuestionCreateCommandHandler(
    IMapper mapper,
    IQuestionService questionService) : ICommandHandler<QuestionCreateCommand, QuestionDto>
{
    public async Task<QuestionDto> Handle(QuestionCreateCommand request, CancellationToken cancellationToken)
    {
        var question = mapper.Map<Question>(request.QuestionDto);

        var createdQuestion = await questionService.CreateAsync(question, cancellationToken: cancellationToken);

        return mapper.Map<QuestionDto>(createdQuestion);
    }
}
