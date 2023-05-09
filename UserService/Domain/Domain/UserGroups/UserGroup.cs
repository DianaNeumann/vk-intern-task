using Domain.UserGroups.Tools;

namespace Domain.UserGroups;

public class UserGroup
{
    public int Id { get; init; }
    public UserGroupCode Code { get; set; }
    public string Description { get; set; }

    public UserGroup()
    {
        
    }
    
    public UserGroup(UserGroupCode code, string description)
    {
        Code = code;
        Description = description;
    }
}