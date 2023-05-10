using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.DataAccess;

public interface IUserContext
{
    public DbSet<User> Users { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}