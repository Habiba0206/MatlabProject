using AutoMapper;
using MatlabProject.Application.Certificates.Models;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.Certificates.Mappers;

public class CertificateMapper : Profile
{
    public CertificateMapper()
    {
        CreateMap<Certificate, CertificateDto>().ReverseMap();
    }
}
