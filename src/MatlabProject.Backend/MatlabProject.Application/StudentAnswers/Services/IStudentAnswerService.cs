using MatlabProject.Application.StudentAnswers.Models;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;
using System.Linq.Expressions;

namespace MatlabProject.Application.StudentAnswers.Services;

public interface IStudentAnswerService
{
    IQueryable<StudentAnswer> Get(
             Expression<Func<StudentAnswer, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    IQueryable<StudentAnswer> Get(
        StudentAnswerFilter studentAnswerFilter,
        QueryOptions queryOptions = default);

    ValueTask<StudentAnswer?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<StudentAnswer>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<StudentAnswer> CreateAsync(
        StudentAnswer studentAnswer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<StudentAnswer> UpdateAsync(
        StudentAnswer studentAnswer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<StudentAnswer?> DeleteAsync(
        StudentAnswer studentAnswer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<StudentAnswer?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
