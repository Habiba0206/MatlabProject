using MatlabProject.Domain.Common.Commands;
using MatlabProject.Application.Certificates.Models;

namespace MatlabProject.Application.Certificates.Commands;

public record CertificateCreateCommand : ICommand<CertificateDto>
{
    public CertificateDto CertificateDto { get; set; }
}
