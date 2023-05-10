using Domain.UserGroups;
using Domain.Users;
using Domain.UserStates;

namespace Application.Abstractions.Services;

public interface IAuthService
{
    Task<User> RegisterAsync(
        string login,
        string password,
        UserGroup group,
        UserState state,
        CancellationToken cancellationToken);

    Task<bool> IsPasswordCorrect(string login, string password);
    
    Task<User> GetUserByLogin(string login);
    
    string GenerateToken(User user);
}