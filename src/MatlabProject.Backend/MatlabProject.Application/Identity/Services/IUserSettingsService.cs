using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Common.Queries;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Application.Identity.Services;

public interface IUserSettingsService
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
