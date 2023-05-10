using Application.Abstractions.DataAccess;
using Application.Abstractions.Security;
using Application.Contracts.User;
using Domain.UserGroups;
using Domain.UserGroups.Tools;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Application.Validation.Users;

public class CreateUserValidator  : AbstractValidator<CreateUser.Command>
{
    private readonly IDatabaseContext _context;
    private readonly IDummyConcurrencyManager _concurrencyManager;
    
    private CancellationToken cancellationToken => CancellationToken.None;
    
    public CreateUserValidator(IDatabaseContext context, IDummyConcurrencyManager concurrencyManager)
    {
        _context = context;
        _concurrencyManager = concurrencyManager;
        
        RuleFor(x => x.Login)
            .NotEmpty()
            .WithMessage("Empty name");

        RuleFor(x => x.UserGroup)
            .Must(g => context.Users.Any(x => x.UserGroup.Code.Equals(g)))
            .When(c => c.UserGroup.Equals((int)UserGroupCode.Admin))
            .WithMessage("Admin already registered");

        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .WithMessage("Empty password");
    }
}