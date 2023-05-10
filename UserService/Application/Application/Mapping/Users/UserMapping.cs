using Application.Dto.Users;
using Domain.Users;

namespace Application.Mapping.Users;

public static class UserMapping
{
    public static UserDto AsDto(this User user)
        => new UserDto(
                user.Id,
                user.Login,
                user.PasswordHash,
                user.CreatedDate,
                user.UserGroup,
                user.UserState
                );
}