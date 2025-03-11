using MatlabProject.Application.Tests.Models;
using MatlabProject.Application.Tests.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;
using MatlabProject.Domain.Enums;
using MatlabProject.Persistence.Extensions;
using MatlabProject.Persistence.Repositories.Interfaces;
using FluentValidation;
using System.Linq.Expressions;
using MatlabProject.Infrastructure.Tests.Validators;

namespace MatlabProject.Infrastructure.Tests.Services;

public class TestResultService(
    ITestResultRepository testResultRepository,
    TestResultValidator validator)
   : ITestResultService
{
    public IQueryable<TestResult> Get(
        Expression<Func<TestResult, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    testResultRepository.Get(predicate, queryOptions);

    public IQueryable<TestResult> Get(
        TestResultFilter testResultFilter,
        QueryOptions queryOptions = default) =>
    testResultRepository
        .Get(queryOptions: queryOptions)
        .ApplyPagination(testResultFilter);

    public ValueTask<TestResult?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    testResultRepository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<TestResult>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    testResultRepository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    testResultRepository.CheckByIdAsync(id, cancellationToken);

    public async ValueTask<TestResult> CreateAsync(
        TestResult testResult,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            testResult,
            options => options
            .IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await testResultRepository.CreateAsync(testResult, commandOptions, cancellationToken);
    }

    public async ValueTask<TestResult> UpdateAsync(
        TestResult testResult,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            testResult,
            options => options
            .IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await testResultRepository.UpdateAsync(testResult, commandOptions, cancellationToken);
    }

    public ValueTask<TestResult?> DeleteAsync(
        TestResult testResult,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    testResultRepository.DeleteAsync(testResult, commandOptions, cancellationToken);

    public ValueTask<TestResult?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    testResultRepository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
