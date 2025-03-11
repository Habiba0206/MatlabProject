using AutoMapper;
using MatlabProject.Application.Identity.Models;
using MatlabProject.Domain.Entities;

namespace MatlabProject.Infrastructure.Identity.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<SignInDetails, User>().ReverseMap();
        CreateMap<SignUpDetails, User>().ReverseMap();
    }
}
