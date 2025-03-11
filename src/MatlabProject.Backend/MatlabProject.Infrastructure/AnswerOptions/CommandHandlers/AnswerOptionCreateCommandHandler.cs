using AutoMapper;
using MatlabProject.Application.AnswerOptions.Commands;
using MatlabProject.Application.AnswerOptions.Models;
using MatlabProject.Application.AnswerOptions.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.AnswerOptions.CommandHandlers;

public class AnswerOptionCreateCommandHandler(
    IMapper mapper,
    IAnswerOptionService answerOptionService) : ICommandHandler<AnswerOptionCreateCommand, AnswerOptionDto>
{
    public async Task<AnswerOptionDto> Handle(AnswerOptionCreateCommand request, CancellationToken cancellationToken)
    {
        var answerOption = mapper.Map<AnswerOption>(request.AnswerOptionDto);

        var createdAnswerOption = await answerOptionService.CreateAsync(answerOption, cancellationToken: cancellationToken);

        return mapper.Map<AnswerOptionDto>(createdAnswerOption);
    }
}
