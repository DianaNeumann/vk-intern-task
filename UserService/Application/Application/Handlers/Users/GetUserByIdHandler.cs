using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping.Users;
using MediatR;
using static Application.Contracts.User.GetUserById;

namespace Application.Handlers.Users;

public class GetUserByIdHandler : IRequestHandler<Query, Response>
{
    private readonly IDatabaseContext _context;


    public GetUserByIdHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.GetEntityAsync(request.Id, cancellationToken);
        return new Response(user.AsDto());
    }
}