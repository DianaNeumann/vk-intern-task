using Application.Abstractions.Security;
using Application.Contracts.User;
using Application.Dto.Users;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApi.Models.Users;

namespace Presentation.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IDummyConcurrencyManager _concurrencyManager;

    public UserController(IMediator mediator, IDummyConcurrencyManager concurrencyManager)
    {
        _mediator = mediator;
        _concurrencyManager = concurrencyManager;
    }

    private CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> CreateUserAsync(
        [FromBody] CreateUserModel model,
        [FromServices] IValidator<CreateUser.Command> validator)
    {
        if (_concurrencyManager.IsRacingSituationNow(model.Login))
        {
            return StatusCode(StatusCodes.Status400BadRequest, "User with the same login is registering now");
        }

        var command = new CreateUser.Command(model.Login, model.Password, model.UserGroupId);

        _concurrencyManager.RegistrationKnocking(model.Login);

        var delay = Task.Delay(5000, CancellationToken);

        var validationResult = await validator.ValidateAsync(command, CancellationToken);
        if (!validationResult.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, validationResult.Errors.Select(x => x.ErrorMessage));
        }

        var response = await _mediator.Send(command, CancellationToken);

        await delay.WaitAsync(CancellationToken);
        _concurrencyManager.RemoveValue(model.Login);

        return Ok(response.User);
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<string>> LoginUserAsync([FromBody] LoginUserModel model)
    {
        var command = new LoginUser.Command(model.Login, model.Password);
        var response = await _mediator.Send(command, CancellationToken);
        return Ok(response.Token);
    }

    [Authorize]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<string>> DeleteUserAsync(
        int id,
        [FromServices] IValidator<DeleteUser.Command> validator)
    {
        var command = new DeleteUser.Command(id);
        var validationResult = await validator.ValidateAsync(command, CancellationToken);
        if (!validationResult.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, validationResult.Errors.Select(x => x.ErrorMessage));
        }
        
        var response = await _mediator.Send(command, CancellationToken);
        return Ok(response.User);
    }

    [Authorize]
    [HttpGet("get/{id:int}")]
    public async Task<ActionResult<UserDto>> GetUserAsync(
        int id,
        [FromServices] IValidator<GetUserById.Query> validator)
    {
        var command = new GetUserById.Query(id);
        var validationResult = await validator.ValidateAsync(command, CancellationToken);
        if (!validationResult.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, validationResult.Errors.Select(x => x.ErrorMessage));
        }
        
        var response = await _mediator.Send(command, CancellationToken);
        return Ok(response.User);
    }

    [Authorize]
    [HttpGet("get/all/{cursor:int}/{pageSize:int}/")]
    public async Task<ActionResult<string>> GetAllUsersAsync(int cursor, int pageSize)
    {
        var command = new GetAllUsersCursor.Query(cursor, pageSize);
        var response = await _mediator.Send(command, CancellationToken);
        return Ok(response.CursorResponse);
    }
}