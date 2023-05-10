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
    
    public UserGroup(int id, UserGroupCode code, string description)
    {
        Id = id;
        Code = code;
        Description = description;
    }
}