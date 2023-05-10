using Domain.Users;

namespace Application.Abstractions.Security;

public interface ITokenManager
{
    string CreateToken(User user);
}