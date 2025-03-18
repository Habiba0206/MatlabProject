using FluentValidation;
using MatlabProject.Application.StudentAnswers.Models;
using MatlabProject.Application.StudentAnswers.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;
using MatlabProject.Domain.Enums;
using MatlabProject.Infrastructure.StudentAnswers.Validators;
using MatlabProject.Persistence.Extensions;
using MatlabProject.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MatlabProject.Infrastructure.StudentAnswers.Services;

public class StudentAnswerService(
    IStudentAnswerRepository studentAnswerRepository,
    StudentAnswerValidator validator)
   : IStudentAnswerService
{
    public IQueryable<StudentAnswer> Get(
        Expression<Func<StudentAnswer, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    studentAnswerRepository.Get(predicate, queryOptions);

    public IQueryable<StudentAnswer> Get(
        StudentAnswerFilter studentAnswerFilter,
        QueryOptions queryOptions = default) =>
        studentAnswerRepository
        .Get(queryOptions: queryOptions)
        .ApplyPagination(studentAnswerFilter);

    public ValueTask<StudentAnswer?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    studentAnswerRepository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<StudentAnswer>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    studentAnswerRepository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    studentAnswerRepository.CheckByIdAsync(id, cancellationToken);

    public async ValueTask<StudentAnswer> CreateAsync(
        StudentAnswer studentAnswer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            studentAnswer,
            options => options
            .IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await studentAnswerRepository.CreateAsync(studentAnswer, commandOptions, cancellationToken);
    }

    public async ValueTask<StudentAnswer> UpdateAsync(
        StudentAnswer studentAnswer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            studentAnswer,
            options => options
            .IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await studentAnswerRepository.UpdateAsync(studentAnswer, commandOptions, cancellationToken);
    }

    public ValueTask<StudentAnswer?> DeleteAsync(
        StudentAnswer studentAnswer,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    studentAnswerRepository.DeleteAsync(studentAnswer, commandOptions, cancellationToken);

    public ValueTask<StudentAnswer?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    studentAnswerRepository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
