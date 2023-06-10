using Microsoft.EntityFrameworkCore;

namespace ForestLibrary.Data;

public class ForestContext: DbContext
{
    public DbSet<Tree> Trees { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Leaf> Leaves { get; set; }
    
    public ForestContext(DbContextOptions<ForestContext> options):base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("dev");
    }
}