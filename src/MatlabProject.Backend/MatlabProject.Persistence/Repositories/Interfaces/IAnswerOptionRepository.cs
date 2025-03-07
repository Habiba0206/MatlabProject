using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;
using System.Linq.Expressions;

namespace MatlabProject.Persistence.Repositories.Interfaces;

public interface IAnswerOptionRepository
{
    IQueryable<AnswerOption> Get(
             Expression<Func<AnswerOption, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    ValueTask<AnswerOption?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<AnswerOption>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<AnswerOption> CreateAsync(
        AnswerOption answerOption,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<AnswerOption> UpdateAsync(
        AnswerOption answerOption,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<AnswerOption?> DeleteAsync(
        AnswerOption answerOption,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<AnswerOption?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
