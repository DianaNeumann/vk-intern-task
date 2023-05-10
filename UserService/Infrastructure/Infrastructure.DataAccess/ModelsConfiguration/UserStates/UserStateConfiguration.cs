using Domain.UserStates;
using Domain.UserStates.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.ModelsConfiguration.UserStates;

public class UserStateConfiguration : IEntityTypeConfiguration<UserState>
{
    public void Configure(EntityTypeBuilder<UserState> builder)
    {
        builder.HasData(new UserState(11, UserStateCode.Active, "Active user's state"));

        builder.HasData(new UserState(10, UserStateCode.Blocked, "Bocked user's state"));
    }
}