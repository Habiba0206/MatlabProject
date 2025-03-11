using AutoMapper;
using MatlabProject.Application.Certificates.Commands;
using MatlabProject.Application.Certificates.Models;
using MatlabProject.Application.Certificates.Services;
using MatlabProject.Domain.Common.Commands;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.Certificates.CommandHandlers;

public class CertificateCreateCommandHandler(
    IMapper mapper,
    ICertificateService certificateService) : ICommandHandler<CertificateCreateCommand, CertificateDto>
{
    public async Task<CertificateDto> Handle(CertificateCreateCommand request, CancellationToken cancellationToken)
    {
        var certificate = mapper.Map<Certificate>(request.CertificateDto);

        var createdCertificate = await certificateService.CreateAsync(certificate, cancellationToken: cancellationToken);

        return mapper.Map<CertificateDto>(createdCertificate);
    }
}
