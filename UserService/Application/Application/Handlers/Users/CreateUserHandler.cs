using Application.Abstractions.DataAccess;
using Application.Abstractions.Security;
using Application.Abstractions.Services;
using Application.Mapping.Users;
using Domain.Users;
using Domain.UserStates.Tools;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.User.CreateUser;

namespace Application.Handlers.Users;

public class CreateUserHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;
    private readonly IAuthService _service;
    private readonly IDummyConcurrencyManager _concurrencyManager;

    public CreateUserHandler(IDatabaseContext context, IAuthService service, IDummyConcurrencyManager concurrencyManager)
    {
        _context = context;
        _service = service;
        _concurrencyManager = concurrencyManager;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var group = await _context.UserGroups.FirstAsync(g => (int)g.Code == request.UserGroup, cancellationToken: cancellationToken);
        var state = await _context.UserStates.FirstAsync(s => s.Code == UserStateCode.Active, cancellationToken: cancellationToken);
        var user = await _service.RegisterAsync(request.Login, request.Password, group, state, cancellationToken);
        
        return new Response(user.AsDto());
    }
}