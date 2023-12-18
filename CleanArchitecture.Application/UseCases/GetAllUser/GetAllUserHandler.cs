using AutoMapper;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using MediatR;


namespace CleanArchitecture.Application.UseCases.GetAllUser;
public class GetAllUserHandler :
       IRequestHandler<GetAllUserRequest, GetAllUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUserHandler(IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetAllUserResponse> Handle(GetAllUserRequest request,
        CancellationToken cancellationToken)
    {

        var user = _mapper.Map<User>(request);

        _userRepository.Create(user);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<GetAllUserResponse>(user);
    }
}
