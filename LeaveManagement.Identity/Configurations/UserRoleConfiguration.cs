using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Identity.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                UserId = "e05a91c6-0a6e-4e3e-94d3-207c4c6a08a4",
                RoleId = "34f1230a-6412-42ff-9ff7-8863a9f6b994"
            },
            new IdentityUserRole<string>
            {
                UserId = "a9032542-bb1b-49b7-815a-d3fe274ef78d",
                RoleId = "0bc44c33-31f9-490d-a339-f22643d9cc39"
            });
    }
}
