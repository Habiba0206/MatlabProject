using MatlabProject.Application.Tests.Models;
using MatlabProject.Application.Tests.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;
using MatlabProject.Domain.Enums;
using MatlabProject.Persistence.Extensions;
using MatlabProject.Persistence.Repositories.Interfaces;
using FluentValidation;
using MatlabProject.Infrastructure.Tests.Validators;
using System.Linq.Expressions;

namespace MatlabProject.Infrastructure.Tests.Services;

public class TestService(
    ITestRepository testRepository,
    TestValidator validator)
   : ITestService
{
    public IQueryable<Test> Get(
        Expression<Func<Test, bool>>? predicate = null,
        QueryOptions queryOptions = default)
    {
        return testRepository.Get(predicate, queryOptions);
    }

    public IQueryable<Test> Get(
        TestFilter testFilter,
        QueryOptions queryOptions = default) =>
    testRepository
        .Get(queryOptions: queryOptions)
        .ApplyPagination(testFilter);

    public ValueTask<Test?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    testRepository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Test>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    testRepository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    testRepository.CheckByIdAsync(id, cancellationToken);

    public async ValueTask<Test> CreateAsync(
        Test test,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            test,
            options => options
            .IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await testRepository.CreateAsync(test, commandOptions, cancellationToken);
    }

    public async ValueTask<Test> UpdateAsync(
        Test test,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            test,
            options => options
            .IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await testRepository.UpdateAsync(test, commandOptions, cancellationToken);
    }

    public ValueTask<Test?> DeleteAsync(
        Test test,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    testRepository.DeleteAsync(test, commandOptions, cancellationToken);

    public ValueTask<Test?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    testRepository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
