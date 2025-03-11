using AutoMapper;
using MatlabProject.Application.Tests.Models;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.Tests.Mappers;

public class TestResultMapper : Profile
{
    public TestResultMapper()
    {
        CreateMap<TestResult, TestResultDto>().ReverseMap();
    }
}
