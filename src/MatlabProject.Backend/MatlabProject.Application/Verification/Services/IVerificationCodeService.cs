using MatlabProject.Domain.Enums;

namespace MatlabProject.Application.Verification.Services;

public interface IVerificationCodeService
{
    ValueTask<VerificationType?> GetVerificationTypeAsync(string code, CancellationToken cancellationToken = default);
}
