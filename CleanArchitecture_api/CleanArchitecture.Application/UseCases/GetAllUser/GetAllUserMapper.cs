using AutoMapper;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UseCases.GetAllUser;
public sealed class GetUserMapper : Profile
{
    public GetUserMapper()
    {
        CreateMap<GetAllUserRequest, User>();
        CreateMap<User, GetAllUserResponse>();
    }
}