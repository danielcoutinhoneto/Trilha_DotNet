using MediatR;

namespace ResTIConnect.Application.UseCases.DeleteUser
{
    public sealed record DeleteUserRequest(Guid Id) 
                    : IRequest<DeleteUserResponse>;

}
