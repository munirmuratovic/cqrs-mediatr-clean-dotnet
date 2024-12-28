using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Identity.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "0bc44c33-31f9-490d-a339-f22643d9cc39",
                Name = "Employee",
                NormalizedName = "EMPLOYEE",
            },
            new IdentityRole
            {
                Id = "34f1230a-6412-42ff-9ff7-8863a9f6b994",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });
    }
}

