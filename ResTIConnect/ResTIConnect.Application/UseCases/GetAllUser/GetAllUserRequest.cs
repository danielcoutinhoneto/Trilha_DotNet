using MediatR;

namespace ResTIConnect.Application.UseCases.GetAllUser;

public sealed record GetAllUserRequest(string Email, string Name) :
                                    IRequest<List<GetAllUserResponse>>;

