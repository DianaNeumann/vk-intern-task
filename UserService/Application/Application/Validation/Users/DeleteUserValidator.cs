using Application.Abstractions.DataAccess;
using Application.Contracts.User;
using FluentValidation;

namespace Application.Validation.Users;

public class DeleteUserValidator : AbstractValidator<DeleteUser.Command>
{
    public DeleteUserValidator(IDatabaseContext context)
    {
        RuleFor(x => x.Id)
            .Must(x => context.Users.Any(u => u.Id.Equals(x)))
            .WithMessage("User doesn't exist");
    }
}