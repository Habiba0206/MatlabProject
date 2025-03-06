using MatlabProject.Domain.Common.Entities;
using MatlabProject.Domain.Enums;

namespace MatlabProject.Domain.Entities;

public abstract class VerificationCode : Entity
{
    public VerificationCodeType CodeType { get; set; }

    public VerificationType Type { get; set; }

    public DateTimeOffset ExpiryTime { get; set; }

    public bool IsActive { get; set; }

    public string Code { get; set; } = default!;

    public string VerificationLink { get; set; } = default!;
}