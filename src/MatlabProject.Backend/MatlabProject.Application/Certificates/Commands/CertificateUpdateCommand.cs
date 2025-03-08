using MatlabProject.Domain.Common.Commands;
using MatlabProject.Application.Certificates.Models;

namespace MatlabProject.Application.Certificates.Commands;

public class CertificateUpdateCommand : ICommand<CertificateDto>
{
    public CertificateDto CertificateDto { get; set; }
}
