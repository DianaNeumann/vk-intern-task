using Domain.UserStates.Tools;

namespace Domain.UserStates;

public class UserState
{
    public int Id { get; init; }
    public UserStateCode Code { get; set; }
    public string Description { get; set; }

    public UserState()
    {
        
    }
 
    public UserState(int id, UserStateCode code, string description)
    {
        Id = id;
        Code = code;
        Description = description;
    }
}