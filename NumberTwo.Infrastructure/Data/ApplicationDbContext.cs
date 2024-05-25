using Microsoft.EntityFrameworkCore;
using NumberTwo.Core.Entities;

namespace NumberTwo.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Bathroom> Bathrooms { get; set; }
    public DbSet<Review> Reviews { get; set; }
}
