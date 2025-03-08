using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;
using MatlabProject.Persistence.Caching.Brokers;
using MatlabProject.Persistence.DataContexts;
using MatlabProject.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MatlabProject.Persistence.Repositories;

public class AnswerOptionRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<AnswerOption, AppDbContext>(appDbContext, cacheBroker),
    IAnswerOptionRepository

{
    public IQueryable<AnswerOption> Get(
        Expression<Func<AnswerOption, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<AnswerOption?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<AnswerOption>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<AnswerOption> CreateAsync(
        AnswerOption answerOption,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    base.CreateAsync(answerOption, commandOptions, cancellationToken);

    public ValueTask<AnswerOption> UpdateAsync(
        AnswerOption answerOption,
        CommandOptions commandOptions,
        CancellationToken cancellationToken) =>
    base.UpdateAsync(answerOption, commandOptions, cancellationToken);

    public ValueTask<AnswerOption?> DeleteAsync(
        AnswerOption answerOption,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.UpdateAsync(answerOption, commandOptions, cancellationToken);

    public ValueTask<AnswerOption?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
