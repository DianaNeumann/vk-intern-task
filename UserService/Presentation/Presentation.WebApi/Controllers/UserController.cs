using Application.Contracts.User;
using Application.Dto.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApi.Models.Users;
using static Application.Contracts.User.CreateUser;
using static Application.Contracts.User.LoginUser;

namespace Presentation.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("Register")]
    public async Task<ActionResult<UserDto>> CreateUserAsync([FromBody] CreateUserModel model)
    {
        var command = new CreateUser.Command(model.Login, model.Password, model.UserGroupId);
        var response = await _mediator.Send(command, CancellationToken);
        return Ok(response.User);
    }
    
    
    [HttpPost("Login")]
    public async Task<ActionResult<string>> LoginUserAsync([FromBody] LoginUserModel model)
    {
        var command = new LoginUser.Command(model.Login, model.Password);
        var response = await _mediator.Send(command, CancellationToken);
        return Ok(response.Token);
    }
    
    
}