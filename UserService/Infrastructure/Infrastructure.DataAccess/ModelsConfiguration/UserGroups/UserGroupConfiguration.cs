using Domain.UserGroups;
using Domain.UserGroups.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.ModelsConfiguration.UserGroups;

public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
{
    public void Configure(EntityTypeBuilder<UserGroup> builder)
    {
        builder.HasData(new UserGroup(1033, UserGroupCode.User, "No privileges role"));
        
        builder.HasData(new UserGroup(3301, UserGroupCode.Admin, "Privileges role"));
    }
}
