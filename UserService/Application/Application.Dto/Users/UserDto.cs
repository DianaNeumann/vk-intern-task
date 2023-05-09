using Domain.UserGroups;
using Domain.UserStates;

namespace Application.Dto.Users;

public record UserDto(
        int Id,
        string Login,
        string PasswordHash,
        DateTime CreatedDate,
        UserGroup UserGroup,
        UserState SserState
        );