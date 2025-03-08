using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.Certificates.Models;

namespace MatlabProject.Application.Certificates.Queries;

public class CertificateGetQuery : IQuery<ICollection<CertificateDto>>
{
    public CertificateFilter CertificateFilter { get; set; }
}
