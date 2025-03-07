using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;
using MatlabProject.Persistence.Caching.Brokers;
using MatlabProject.Persistence.DataContexts;
using MatlabProject.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MatlabProject.Persistence.Repositories;

public class EmailTemplateRepository(AppDbContext appDbContext, ICacheBroker cacheBroker) :
    EntityRepositoryBase<EmailTemplate, AppDbContext>(appDbContext, cacheBroker),
    IEmailTemplateRepository

{
    public IQueryable<EmailTemplate> Get(
        Expression<Func<EmailTemplate, bool>>? predicate = null,
        QueryOptions queryOptions = default) =>
    base.Get(predicate, queryOptions);

    public ValueTask<EmailTemplate?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdAsync(id, queryOptions, cancellationToken);

    public ValueTask<IList<EmailTemplate>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default) =>
    base.GetByIdsAsync(ids, queryOptions, cancellationToken);

    public ValueTask<bool> CheckByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
    base.CheckByIdAsync(id, cancellationToken);

    public ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default) =>
    base.CreateAsync(emailTemplate, commandOptions, cancellationToken);
}