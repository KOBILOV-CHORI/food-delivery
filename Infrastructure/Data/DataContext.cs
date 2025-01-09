using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Courier> Couriers { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Courier)
            .WithOne(c => c.User)
            .HasForeignKey<Courier>(c => c.UserId);
    }
}
