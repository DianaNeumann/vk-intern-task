using Application.Dto.Users;
using MediatR;

namespace Application.Contracts.User;

public class LoginUser
{
    public record struct Command(string Login, string Password) : IRequest<Response>;

    public record struct Response(string Token);
}