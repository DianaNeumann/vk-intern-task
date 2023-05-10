using Application.Abstractions.Security;
using Application.Abstractions.Services;
using Application.Security.Passwords;
using Application.Security.Tokens;
using Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MPS.Domain.Modules.SecurityModules.PasswordModule.Interfaces;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddMediatR(typeof(IAssemblyMarker));
        collection.AddScoped<IAuthService, AuthService>();
        collection.AddScoped<IPasswordManager, Sha256PasswordManager>();
        collection.AddScoped<ITokenManager, JwtTokenManager>();

        return collection;
    }
}