using Application.Dto.UserStates;
using Domain.UserStates;

namespace Application.Mapping.UserStates;

public static class UserStateMapping
{
    public static UserStateDto AsDto(this UserState userState)
        => new UserStateDto(userState.Id, userState.Code, userState.Description);
}