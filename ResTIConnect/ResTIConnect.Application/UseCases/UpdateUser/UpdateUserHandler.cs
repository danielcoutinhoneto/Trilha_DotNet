﻿using AutoMapper;
using MediatR;
using ResTIConnect.Domain.Interfaces;

namespace ResTIConnect.Application.UseCases.UpdateUser;

public class UpdateUserHandler :
    IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly IUnitofWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IUnitofWork unitofWork, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitofWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(command.Id, cancellationToken);

        if (user is null) return default;

        user.Name = command.Name;
        user.Email = command.Email;

        _userRepository.Update(user);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<UpdateUserResponse>(user);
    }
}

