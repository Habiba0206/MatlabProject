using AutoMapper;
using MatlabProject.Application.AnswerOptions.Commands;
using MatlabProject.Application.AnswerOptions.Models;
using MatlabProject.Application.AnswerOptions.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.AnswerOptions.CommandHandlers;

public class AnswerOptionUpdateCommandHandler(
    IMapper mapper,
    IAnswerOptionService answerOptionService) : ICommandHandler<AnswerOptionUpdateCommand, AnswerOptionDto>
{
    public async Task<AnswerOptionDto> Handle(AnswerOptionUpdateCommand request, CancellationToken cancellationToken)
    {
        var answerOption = mapper.Map<AnswerOption>(request.AnswerOptionDto);

        var updatedAnswerOption = await answerOptionService.UpdateAsync(answerOption, cancellationToken: cancellationToken);

        return mapper.Map<AnswerOptionDto>(updatedAnswerOption);
    }
}
