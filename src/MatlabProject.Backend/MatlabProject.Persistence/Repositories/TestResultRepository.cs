using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;
using MatlabProject.Persistence.Caching.Brokers;
using MatlabProject.Persistence.DataContexts;
using MatlabProject.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MatlabProject.Persistence.Repositories;

public class TestResultRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<TestResult, AppDbContext>(appDbContext, cacheBroker),
    ITestResultRepository

{
    public IQueryable<TestResult> Get(
        Expression<Func<TestResult, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<TestResult?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<TestResult>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<TestResult> CreateAsync(
        TestResult testResult,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    base.CreateAsync(testResult, commandOptions, cancellationToken);

    public ValueTask<TestResult> UpdateAsync(
        TestResult testResult,
        CommandOptions commandOptions,
        CancellationToken cancellationToken) =>
    base.UpdateAsync(testResult, commandOptions, cancellationToken);

    public ValueTask<TestResult?> DeleteAsync(
        TestResult testResult,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.UpdateAsync(testResult, commandOptions, cancellationToken);

    public ValueTask<TestResult?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions,
        CancellationToken cancellationToken = default) =>
    base.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
