using AutoMapper;
using MatlabProject.Application.Tests.Models;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.Tests.Mappers;

public class TestMapper : Profile
{
    public TestMapper()
    {
        CreateMap<Test, TestDto>().ReverseMap();
    }
}
