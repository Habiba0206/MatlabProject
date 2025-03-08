using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.Certificates.Models;

namespace MatlabProject.Application.Certificates.Queries;

public class CertificateGetByIdQuery : IQuery<CertificateDto?>
{
    public Guid CertificateId { get; set; }
}
