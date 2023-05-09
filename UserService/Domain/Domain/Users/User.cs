using Domain.UserGroups;
using Domain.UserStates;

namespace Domain.Users;

public class User
{
    public int Id { get; init; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedDate { get; set; }
    public virtual UserGroup UserGroup { get; set; }
    public virtual UserState UserState { get; set; }
    
    
    public User()
    {
        
    }
    
    public User(string login, string passwordHash, DateTime createdDate, UserGroup userGroup, UserState userState)
    {
        Login = login;
        PasswordHash = passwordHash;
        CreatedDate = createdDate;
        UserGroup = userGroup;
        UserState = userState;
    }
}