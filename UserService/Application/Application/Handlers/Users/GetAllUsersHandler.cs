using Application.Abstractions.DataAccess;
using Application.Contracts.User.Tools;
using Application.Dto.Users;
using Application.Mapping.Users;
using Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Application.Contracts.User.GetAllUsersCursor;

namespace Application.Handlers.Users;

public class GetAllUsersHandler: IRequestHandler<Query, Response>
{
    private readonly IDatabaseContext _context;

    public GetAllUsersHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
    {
        /* Postgres dosn't support Multiple Active Result Sets,
         so do it in this order */
        
        var users = await _context.Users
            .Where(u => u.Id >= request.Cursor)
            .Take(request.PageSize + 1)
            .OrderBy(u => u.Id)
            .ToListAsync(cancellationToken);

        long cursor = users[^1].Id;

        var usersResponses = users
            .Take(request.PageSize)
            .Select(x => x.AsDto());
        
        return new Response(new CursorResponse<IEnumerable<UserDto>>(cursor, usersResponses));
    }
}