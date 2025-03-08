using MatlabProject.Domain.Entities;

namespace MatlabProject.Application.Identity.Services;

public interface IPasswordGeneratorService
{
    string GeneratePassword();

    string GetValidatedPassword(string password, User user);
}