using Application.Abstractions.DataAccess;
using Application.Abstractions.Security;
using Application.Abstractions.Services;
using Domain.UserGroups;
using Domain.Users;
using Domain.UserStates;
using Microsoft.EntityFrameworkCore;
using MPS.Domain.Modules.SecurityModules.PasswordModule.Interfaces;

namespace Application.Services;

public class AuthService : IAuthService
{
    private readonly IDatabaseContext _context;
    private readonly IPasswordManager _passwordManager;
    private readonly ITokenManager _tokenManager;

    public AuthService(IDatabaseContext context, IPasswordManager passwordManager, ITokenManager tokenManager)
    {
        _context = context;
        _passwordManager = passwordManager;
        _tokenManager = tokenManager;
    }

    public async Task<User> RegisterAsync(
        string login,
        string password,
        UserGroup group,
        UserState state,
        CancellationToken cancellationToken)
    {
        var passwordHash = _passwordManager.CreatePasswordHash(password);
        var user = new User(login, passwordHash, group, state);

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return user;
    }
    

    public async Task<bool> IsPasswordCorrect(string login, string password)
    {
        var user = await GetUserByLogin(login);

        var isPasswordCorrect = _passwordManager.VerifyPasswordHash(password, user.PasswordHash);
        return isPasswordCorrect;
    }

    public async Task<User> GetUserByLogin(string login)
    {
        return await _context.Users.FirstAsync(a => a.Login.Equals(login));
    }

    public string GenerateToken(User user) => _tokenManager.CreateToken(user);
}