using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;
using MatlabProject.Persistence.Caching.Brokers;
using MatlabProject.Persistence.DataContexts;
using MatlabProject.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MatlabProject.Persistence.Repositories;

public class TestRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<Test, AppDbContext>(appDbContext, cacheBroker),
    ITestRepository

{
    public IQueryable<Test> Get(
        Expression<Func<Test, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<Test?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Test>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<Test> CreateAsync(
        Test test,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    base.CreateAsync(test, commandOptions, cancellationToken);

    public ValueTask<Test> UpdateAsync(
        Test test,
        CommandOptions commandOptions,
        CancellationToken cancellationToken) =>
    base.UpdateAsync(test, commandOptions, cancellationToken);

    public ValueTask<Test?> DeleteAsync(
        Test test,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.UpdateAsync(test, commandOptions, cancellationToken);

    public ValueTask<Test?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
