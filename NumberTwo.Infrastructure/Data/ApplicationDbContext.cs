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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Bathroom)
            .WithMany(b => b.Reviews)
            .HasForeignKey(r => r.BathroomId);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId);

    }
}
