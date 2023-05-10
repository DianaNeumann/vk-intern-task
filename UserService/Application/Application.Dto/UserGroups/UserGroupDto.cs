using Domain.UserGroups.Tools;

namespace Application.Dto.UserGroups;

public record UserGroupDto(int Id, UserGroupCode Code, string Description);