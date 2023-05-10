using Domain.UserGroups;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.DataAccess;

public interface IUserGroupsContext
{
    public DbSet<UserGroup> UserGroups { get; }
    public UserGroup AdminGroup { get; }
    public UserGroup UserGroup { get; }

    public UserGroup GetGroupByCode(int code);
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}