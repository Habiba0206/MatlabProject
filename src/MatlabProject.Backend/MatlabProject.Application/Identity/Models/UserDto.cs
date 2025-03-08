using MatlabProject.Domain.Enums;

namespace MatlabProject.Application.Identity.Models;

public class UserDto
{
    public Guid? Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public int Age { get; set; }
    public Role Role { get; set; }
    public UserState UserState { get; set; }
}
