using AutoMapper;
using MatlabProject.Application.Certificates.Commands;
using MatlabProject.Application.Certificates.Models;
using MatlabProject.Application.Certificates.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.Certificates.CommandHandlers;

public class CertificateUpdateCommandHandler(
    IMapper mapper,
    ICertificateService certificateService) : ICommandHandler<CertificateUpdateCommand, CertificateDto>
{
    public async Task<CertificateDto> Handle(CertificateUpdateCommand request, CancellationToken cancellationToken)
    {
        var certificate = mapper.Map<Certificate>(request.CertificateDto);

        var createdCertificate = await certificateService.UpdateAsync(certificate, cancellationToken: cancellationToken);

        return mapper.Map<CertificateDto>(createdCertificate);
    }
}
