using AutoMapper;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Application.UseCases.DeleteUser;

public sealed class DeleteUserMapper : Profile
{
    public DeleteUserMapper()
    {
        CreateMap<DeleteUserRequest, User>();
        CreateMap<User, DeleteUserResponse>();
        
    }

}
