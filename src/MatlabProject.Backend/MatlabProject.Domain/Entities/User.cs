using MassTransit.Configuration;
using MatlabProject.Domain.Common.Entities;
using MatlabProject.Domain.Enums;

namespace MatlabProject.Domain.Entities;

public class User : AuditableEntity
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public int Age { get; set; }
    public string StudentId { get; set; } = default!;
    public bool IsEmailAddressVerified { get; set; }
    public Role Role { get; set; }
    public UserState UserState { get; set; }
    public UserSettings? UserSettings { get; set; }
    public IEnumerable<TestResult> TestResults { get; set; }
    public IEnumerable<Certificate> Certificates { get; set; }
}
