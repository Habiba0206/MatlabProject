using AutoMapper;
using MatlabProject.Application.AnswerOptions.Models;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.AnswerOptions.Mappers;

public class AnswerOptionMapper : Profile
{
    public AnswerOptionMapper()
    {
        CreateMap<AnswerOption, AnswerOptionDto>().ReverseMap();
    }
}
