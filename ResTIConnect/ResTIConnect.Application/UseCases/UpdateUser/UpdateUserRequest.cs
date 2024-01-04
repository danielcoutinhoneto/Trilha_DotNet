using MediatR;

namespace ResTIConnect.Application.UseCases.UpdateUser
{
     public sealed record UpdateUserRequest(Guid Id, 
                             string Email, string Name) 
                             : IRequest<UpdateUserResponse>;
}
