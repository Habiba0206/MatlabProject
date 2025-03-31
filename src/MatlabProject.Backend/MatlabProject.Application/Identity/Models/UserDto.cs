using MatlabProject.Domain.Enums;

namespace MatlabProject.Application.Identity.Models;

public class UserDto
{
    public Guid? Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public int Age { get; set; }
    public string? StudentId { get; set; }
    public bool IsEmailAddressVerified { get; set; }
    public Role Role { get; set; }
    public UserState UserState { get; set; }
}
