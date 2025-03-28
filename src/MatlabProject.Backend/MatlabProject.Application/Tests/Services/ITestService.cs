﻿using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;
using MatlabProject.Application.Tests.Models;
using System.Linq.Expressions;

namespace MatlabProject.Application.Tests.Services;

public interface ITestService
{
    IQueryable<Test> Get(
             Expression<Func<Test, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    IQueryable<Test> Get(
        TestFilter testFilter,
        QueryOptions queryOptions = default);

    ValueTask<Test?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<Test>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Test> CreateAsync(
        Test test,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Test> UpdateAsync(
        Test test,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Test?> DeleteAsync(
        Test test,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Test?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
