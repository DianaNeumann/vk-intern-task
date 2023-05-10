using Application.Dto.UserGroups;
using Domain.UserGroups;

namespace Application.Mapping.UserGroups;

public static class UserGroupMapping
{
    public static UserGroupDto AsDto(this UserGroup userGroup)
        => new UserGroupDto(userGroup.Id, userGroup.Code, userGroup.Description);
}