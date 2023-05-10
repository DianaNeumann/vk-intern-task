using Application.Abstractions.DataAccess;
using Application.Contracts.User;
using FluentValidation;

namespace Application.Validation.Users;

public class GetUserByIdValidator : AbstractValidator<GetUserById.Query>
{
    public GetUserByIdValidator(IDatabaseContext context)
    {
        RuleFor(x => x.Id)
            .Must(x => context.Users.Any(u => u.Id.Equals(x)))
            .WithMessage("User doesn't exist");
    }
}