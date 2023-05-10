using Application.Dto.Users;
using MediatR;

namespace Application.Contracts.User;

public class GetUserById
{
    public record Query(int Id) : IRequest<Response>;
    public record Response(UserDto User);
}