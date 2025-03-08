using MatlabProject.Domain.Entities;

namespace MatlabProject.Application.Identity.Services;

public interface IAccountAggregatorService
{
    ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default);
}