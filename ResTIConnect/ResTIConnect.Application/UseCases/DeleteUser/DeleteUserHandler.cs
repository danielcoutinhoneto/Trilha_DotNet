﻿using AutoMapper;
using MediatR;
using ResTIConnect.Domain.Interfaces;

namespace ResTIConnect.Application.UseCases.DeleteUser;

public class DeleteUserHandler :
    IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    private readonly IUnitofWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleteUserHandler(IUnitofWork unitofWork, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitofWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.Id, cancellationToken);

        if (user is null) return default;

        _userRepository.Delete(user);
        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<DeleteUserResponse>(user);
    }
}


