using AutoMapper;
using MatlabProject.Application.Questions.Models;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.Questions.Mappers;

public class QuestionMapper : Profile
{
    public QuestionMapper()
    {
        CreateMap<Question, QuestionDto>().ReverseMap();
    }
}
