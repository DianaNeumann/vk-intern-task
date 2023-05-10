using Application.Dto.Users;
using MediatR;

namespace Application.Contracts.User;

public class CreateUser
{
    public record struct Command(string Login, string Password, int UserGroup) : IRequest<Response>;

    public record struct Response(UserDto User);
}