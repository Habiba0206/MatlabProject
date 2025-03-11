using MatlabProject.Domain.Entities;
using MatlabProject.Domain.Enums;
using FluentValidation;

namespace MatlabProject.Infrastructure.Certificates.Validators;
public class CertificateValidator : AbstractValidator<Certificate>
{
    public CertificateValidator()
    {
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(certificate => certificate.UserId).NotEqual(Guid.Empty);
                RuleFor(certificate => certificate.TestId).NotEqual(Guid.Empty);
                RuleFor(certificate => certificate.FilePath).NotEmpty().MinimumLength(2);
            });

        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(certificate => certificate.FilePath).NotEmpty().MinimumLength(2);
            });
    }
}
