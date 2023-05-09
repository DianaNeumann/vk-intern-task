using Domain.UserStates.Tools;

namespace Application.Dto.UserStates;

public record UserStateDto(int Id, UserStateCode Code, string Description);