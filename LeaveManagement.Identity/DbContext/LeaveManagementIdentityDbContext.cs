using LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Identity.DbContext;

public class LeaveManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public LeaveManagementIdentityDbContext(DbContextOptions<LeaveManagementIdentityDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(LeaveManagementIdentityDbContext).Assembly);

        Console.WriteLine(typeof(LeaveManagementIdentityDbContext).Assembly);

    }
}
