using System.ComponentModel.DataAnnotations.Schema;
using Domain.UserGroups;
using Domain.UserStates;
using Domain.UserStates.Tools;

namespace Domain.Users;

public class User
{
    public int Id { get; init; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedDate { get; set; }
    
    [ForeignKey("User.UserGroup")]
    public virtual UserGroup UserGroup { get; set; }
    [ForeignKey("User.UserState")]
    public virtual UserState UserState { get; set; }
    
    
    public User()
    {
        
    }
    
    public User(string login, string passwordHash, UserGroup userGroup, UserState userState)
    {
        Login = login;
        PasswordHash = passwordHash;
        CreatedDate = DateTime.Now.ToUniversalTime();;
        UserGroup = userGroup;
        UserState = userState;
    }
}