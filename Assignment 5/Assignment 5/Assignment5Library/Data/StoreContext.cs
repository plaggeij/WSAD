using Assignment5Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment5Library.Data;

public class StoreContext: DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options){
        
    }
    
    public DbSet<Customer> Custoners { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
}