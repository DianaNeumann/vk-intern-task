using Application.Abstractions.DataAccess;
using Application.Abstractions.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.User.LoginUser;

namespace Application.Handlers.Users;

public class LoginUserHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;
    private readonly IAuthService _service;

    public LoginUserHandler(IDatabaseContext context, IAuthService service)
    {
        _context = context;
        _service = service;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstAsync(a => a.Login.Equals(request.Login), cancellationToken);
        
        var token = _service.GenerateToken(user);
        return new Response(token);
    }
}