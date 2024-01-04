using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.UseCases.CreateUser;
using ResTIConnect.Application.UseCases.DeleteUser;
using ResTIConnect.Application.UseCases.GetAllUser;
using ResTIConnect.Application.UseCases.UpdateUser;

namespace ResTIConnect.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetAllUserResponse>>> GetAll(CancellationToken cancellationToken)
    {
        var request = new GetAllUserRequest("example@email.com", "Example Name"); 
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateUserRequest request)
    {
        var useId = await _mediator.Send(request);
        return Ok(useId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateUserResponse>>
        Update(Guid id, UpdateUserRequest request, CancellationToken cancellationToken)
    {
        if (id != request.Id)
            return BadRequest();

        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid? id, 
                                    CancellationToken cancellationToken)
    {
        if (id is null)
            return BadRequest();

        var deleteUserRequest = new DeleteUserRequest(id.Value);

        var response = await _mediator.Send(deleteUserRequest, cancellationToken);
        return Ok(response);
    }
}

