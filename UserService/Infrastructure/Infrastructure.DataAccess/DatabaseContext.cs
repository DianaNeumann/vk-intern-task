using Application.Abstractions.DataAccess;
using Domain.UserGroups;
using Domain.Users;
using Domain.UserStates;
using Domain.UserStates.Tools;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess;

public class DatabaseContext : DbContext, IDatabaseContext
{
    private IDatabaseContext _databaseContextImplementation;

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; private init; } = null!;
    
    public DbSet<UserGroup> UserGroups { get; private init; } = null!;
    
    public DbSet<UserState> UserStates { get; private init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);
    }
}