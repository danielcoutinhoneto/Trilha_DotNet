using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.UseCases.CreateUser;
using ResTIConnect.Application.UseCases.GetAllUser;

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
    public async Task<ActionResult<List<GetAllUserResponse>>>
        GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllUserResponse(), cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateUserRequest request)
    {
        var useId = await _mediator.Send(request);
        return Ok(useId);
    }
}

