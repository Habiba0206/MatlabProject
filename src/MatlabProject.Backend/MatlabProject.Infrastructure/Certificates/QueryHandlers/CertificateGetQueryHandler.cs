using AutoMapper;
using MatlabProject.Application.Certificates.Models;
using MatlabProject.Application.Certificates.Queries;
using MatlabProject.Application.Certificates.Services;
using MatlabProject.Domain.Common.Queries;
using Microsoft.EntityFrameworkCore;

namespace MatlabProject.Infrastructure.Certificates.QueryHandlers;

public class CertificateGetQueryHandler(
    IMapper mapper,
    ICertificateService certificateService)
    : IQueryHandler<CertificateGetQuery, ICollection<CertificateDto>>
{
    public async Task<ICollection<CertificateDto>> Handle(CertificateGetQuery request, CancellationToken cancellationToken)
    {
        var result = await certificateService.Get(
            request.CertificateFilter,
            new QueryOptions()
            {
                QueryTrackingMode = QueryTrackingMode.AsNoTracking
            })
            .ToListAsync(cancellationToken);

        return mapper.Map<ICollection<CertificateDto>>(result);
    }
}
