using Microsoft.EntityFrameworkCore;

public class SalesDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Clerk> Clerks { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=YOUR_SERVER;Database=SalesDB;Trusted_Connection=True;");
    }
}