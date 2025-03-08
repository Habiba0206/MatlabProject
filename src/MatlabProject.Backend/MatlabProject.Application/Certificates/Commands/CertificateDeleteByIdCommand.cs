using MatlabProject.Domain.Common.Commands;

namespace MatlabProject.Application.Certificates.Commands;

public class CertificateDeleteByIdCommand : ICommand<bool>
{
    public Guid CertificateId { get; set; }
}
