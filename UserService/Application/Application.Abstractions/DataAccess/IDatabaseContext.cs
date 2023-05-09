using Domain.UserGroups;
using Domain.Users;
using Domain.UserStates;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.DataAccess;

public interface IDatabaseContext
{
    public DbSet<User> Users { get; }
    public DbSet<UserGroup> UserGroups { get; }
    public DbSet<UserState> UserStates { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}