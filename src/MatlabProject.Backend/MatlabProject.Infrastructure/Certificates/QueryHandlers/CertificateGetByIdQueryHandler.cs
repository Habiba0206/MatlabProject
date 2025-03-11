using AutoMapper;
using MatlabProject.Application.Certificates.Models;
using MatlabProject.Application.Certificates.Queries;
using MatlabProject.Application.Certificates.Services;
using MatlabProject.Domain.Common.Queries;

namespace MatlabProject.Infrastructure.Certificates.QueryHandlers;

public class CertificateGetByIdQueryHandler(
    IMapper mapper,
    ICertificateService certificateService)
    : IQueryHandler<CertificateGetByIdQuery, CertificateDto>
{
    public async Task<CertificateDto> Handle(CertificateGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await certificateService.GetByIdAsync(request.CertificateId, cancellationToken: cancellationToken);

        return mapper.Map<CertificateDto>(result);
    }
}
