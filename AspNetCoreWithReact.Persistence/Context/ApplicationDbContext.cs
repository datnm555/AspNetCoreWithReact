using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWithReact.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Activity> Activities { get; set; }
}