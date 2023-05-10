using Domain.UserStates;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.DataAccess;

public interface IUserStateContext
{
    public DbSet<UserState> UserStates { get; }
   
    public UserState Active { get; }
    public UserState Blocked { get; }
    public UserState GetStateByCode(int code);
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}