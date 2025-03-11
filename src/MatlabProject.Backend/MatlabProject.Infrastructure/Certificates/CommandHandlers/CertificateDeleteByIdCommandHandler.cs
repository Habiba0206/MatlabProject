using MatlabProject.Application.Certificates.Commands;
using MatlabProject.Application.Certificates.Services;
using MatlabProject.Domain.Common.Commands;

namespace MatlabProject.Infrastructure.Certificates.CommandHandlers;

public class CertificateDeleteByIdCommandHandler(
    ICertificateService certificateService)
    : ICommandHandler<CertificateDeleteByIdCommand, bool>
{
    public async Task<bool> Handle(CertificateDeleteByIdCommand request, CancellationToken cancellationToken)
    {
        var result = await certificateService.DeleteByIdAsync(request.CertificateId, cancellationToken: cancellationToken);

        return result is not null;
    }
}