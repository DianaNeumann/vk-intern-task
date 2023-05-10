using Application.Contracts.User.Tools;
using Application.Dto.Users;
using MediatR;

namespace Application.Contracts.User;

public class GetAllUsersCursor
{
    public record Query(int Cursor, int PageSize) : IRequest<Response>;
    public record Response(CursorResponse<IEnumerable<UserDto>> CursorResponse);
}