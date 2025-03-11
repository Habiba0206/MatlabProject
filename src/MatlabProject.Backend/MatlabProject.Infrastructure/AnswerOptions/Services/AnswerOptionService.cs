using MatlabProject.Application.AnswerOptions.Models;
using MatlabProject.Application.AnswerOptions.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;
using MatlabProject.Domain.Enums;
using MatlabProject.Persistence.Extensions;
using MatlabProject.Persistence.Repositories.Interfaces;
using FluentValidation;
using MatlabProject.Infrastructure.AnswerOptions.Validators;
using System.Linq.Expressions;

namespace MatlabProject.Infrastructure.AnswerOptions.Services;

public class AnswerOptionService(
    IAnswerOptionRepository answerOptionRepository,
    AnswerOptionValidator validator)
   : IAnswerOptionService
{
    public IQueryable<AnswerOption> Get(
        Expression<Func<AnswerOption, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    answerOptionRepository.Get(predicate, queryOptions);

    public IQueryable<AnswerOption> Get(
        AnswerOptionFilter answerOptionFilter,
        QueryOptions queryOptions = default) =>
    answerOptionRepository
        .Get(queryOptions: queryOptions)
        .ApplyPagination(answerOptionFilter);

    public ValueTask<AnswerOption?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    answerOptionRepository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<AnswerOption>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    answerOptionRepository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    answerOptionRepository.CheckByIdAsync(id, cancellationToken);

    public async ValueTask<AnswerOption> CreateAsync(
        AnswerOption answerOption,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            answerOption,
            options => options
            .IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await answerOptionRepository.CreateAsync(answerOption, commandOptions, cancellationToken);
    }

    public async ValueTask<AnswerOption> UpdateAsync(
        AnswerOption answerOption,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            answerOption,
            options => options
            .IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await answerOptionRepository.UpdateAsync(answerOption, commandOptions, cancellationToken);
    }

    public ValueTask<AnswerOption?> DeleteAsync(
        AnswerOption answerOption,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    answerOptionRepository.DeleteAsync(answerOption, commandOptions, cancellationToken);

    public ValueTask<AnswerOption?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    answerOptionRepository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
