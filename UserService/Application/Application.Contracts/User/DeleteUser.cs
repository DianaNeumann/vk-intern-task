using Application.Dto.Users;
using MediatR;

namespace Application.Contracts.User;

public class DeleteUser
{
    public record struct Command(int Id) : IRequest<Response>;

    public record struct Response(UserDto User);
}