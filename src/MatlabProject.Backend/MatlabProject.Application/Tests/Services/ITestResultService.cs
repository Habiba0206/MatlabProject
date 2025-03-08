using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;
using MatlabProject.Application.Tests.Models;
using System.Linq.Expressions;

namespace MatlabProject.Application.Tests.Services;

public interface ITestResultService
{
    IQueryable<TestResult> Get(
             Expression<Func<TestResult, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    IQueryable<TestResult> Get(
        TestResultFilter testResultFilter,
        QueryOptions queryOptions = default);

    ValueTask<TestResult?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<TestResult>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<TestResult> CreateAsync(
        TestResult testResult,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<TestResult> UpdateAsync(
        TestResult testResult,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<TestResult?> DeleteAsync(
        TestResult testResult,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<TestResult?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
