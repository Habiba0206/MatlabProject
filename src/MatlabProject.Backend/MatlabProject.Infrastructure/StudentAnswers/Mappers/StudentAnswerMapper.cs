using AutoMapper;
using MatlabProject.Application.StudentAnswers.Models;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.StudentAnswers.Mappers;

public class StudentAnswerMapper : Profile
{
    public StudentAnswerMapper()
    {
        CreateMap<StudentAnswer, StudentAnswerDto>().ReverseMap();
    }
}
