using MatlabProject.Application.Certificates.Models;
using MatlabProject.Application.Certificates.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;
using MatlabProject.Domain.Enums;
using MatlabProject.Persistence.Extensions;
using MatlabProject.Persistence.Repositories.Interfaces;
using FluentValidation;
using MatlabProject.Infrastructure.Certificates.Validators;
using System.Linq.Expressions;

namespace MatlabProject.Infrastructure.Certificates.Services;

public class CertificateService(
    ICertificateRepository certificateRepository,
    CertificateValidator validator)
   : ICertificateService
{
    public IQueryable<Certificate> Get(
        Expression<Func<Certificate, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    certificateRepository.Get(predicate, queryOptions);

    public IQueryable<Certificate> Get(
        CertificateFilter certificateFilter,
        QueryOptions queryOptions = default) =>
    certificateRepository
        .Get(queryOptions: queryOptions)
        .ApplyPagination(certificateFilter);

    public ValueTask<Certificate?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    certificateRepository.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<Certificate>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    certificateRepository.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    certificateRepository.CheckByIdAsync(id, cancellationToken);

    public async ValueTask<Certificate> CreateAsync(
        Certificate certificate,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            certificate,
            options => options
            .IncludeRuleSets(EntityEvent.OnCreate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await certificateRepository.CreateAsync(certificate, commandOptions, cancellationToken);
    }

    public async ValueTask<Certificate> UpdateAsync(
        Certificate certificate,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(
            certificate,
            options => options
            .IncludeRuleSets(EntityEvent.OnUpdate.ToString()),
            cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return await certificateRepository.UpdateAsync(certificate, commandOptions, cancellationToken);
    }

    public ValueTask<Certificate?> DeleteAsync(
        Certificate certificate,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    certificateRepository.DeleteAsync(certificate, commandOptions, cancellationToken);

    public ValueTask<Certificate?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    certificateRepository.DeleteByIdAsync(id, commandOptions, cancellationToken);
}
