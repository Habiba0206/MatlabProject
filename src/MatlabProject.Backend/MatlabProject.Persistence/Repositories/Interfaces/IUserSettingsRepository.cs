using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;
using System.Linq.Expressions;

namespace MatlabProject.Persistence.Repositories.Interfaces;

public interface IUserSettingsRepository
{
    ValueTask<UserSettings?> GetByIdAsync(
        Guid id,
        QueryOptions queryOptions = default,
        CancellationToken cancellationToken = default);

    ValueTask<UserSettings> CreateAsync(
        UserSettings userSettings,
        CommandOptions commandOptions = default,
        CancellationToken cancellationToken = default);

}