using Application.Abstractions.DataAccess;
using Application.Mapping.Users;
using Domain.Users;
using Domain.UserStates;
using Domain.UserStates.Tools;
using MediatR;
using static Application.Contracts.User.DeleteUser;

namespace Application.Handlers.Users;

public class DeleteUserHandler: IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;


    public DeleteUserHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var user = _context.Users.First(x => x.Id.Equals(request.Id));
        var state = _context.UserStates.First(x => x.Code.Equals(UserStateCode.Blocked));
        user.UserState = state;
        
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(user.AsDto());
    }
}