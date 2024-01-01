using AutoMapper;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Application.UseCases.GetAllUser;

public class GetAllUserMapper : Profile
{
    public GetAllUserMapper()
    {
        CreateMap<User, GetAllUserResponse>();
    }

}
