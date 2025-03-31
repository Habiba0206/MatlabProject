using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;
using MatlabProject.Persistence.Caching.Brokers;
using MatlabProject.Persistence.DataContexts;
using MatlabProject.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MatlabProject.Persistence.Repositories;

public class StudentAnswerRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<StudentAnswer, AppDbContext>(appDbContext, cacheBroker),
    IStudentAnswerRepository

{
    public IQueryable<StudentAnswer> Get(
        Expression<Func<StudentAnswer, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<StudentAnswer?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<StudentAnswer>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<StudentAnswer> CreateAsync(
        StudentAnswer studentAnswer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    base.CreateAsync(studentAnswer, commandOptions, cancellationToken);

    public ValueTask<StudentAnswer> UpdateAsync(
        StudentAnswer studentAnswer,
        CommandOptions commandOptions,
        CancellationToken cancellationToken) =>
    base.UpdateAsync(studentAnswer, commandOptions, cancellationToken);

    public ValueTask<StudentAnswer?> DeleteAsync(
        StudentAnswer studentAnswer,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.UpdateAsync(studentAnswer, commandOptions, cancellationToken);

    public ValueTask<StudentAnswer?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
