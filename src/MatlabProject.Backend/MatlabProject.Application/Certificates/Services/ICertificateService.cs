using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;
using MatlabProject.Application.Certificates.Models;
using System.Linq.Expressions;

namespace MatlabProject.Application.Certificates.Services;

public interface ICertificateService
{
    IQueryable<Certificate> Get(
             Expression<Func<Certificate, bool>>? predicate = default,
             QueryOptions queryOptions = default);

    IQueryable<Certificate> Get(
        CertificateFilter certificateFilter,
        QueryOptions queryOptions = default);

    ValueTask<Certificate?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    ValueTask<IList<Certificate>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Certificate> CreateAsync(
        Certificate certificate,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Certificate> UpdateAsync(
        Certificate certificate,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Certificate?> DeleteAsync(
        Certificate certificate,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<Certificate?> DeleteByIdAsync(
        Guid id,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);
}
