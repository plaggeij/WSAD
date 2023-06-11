using Microsoft.EntityFrameworkCore;
namespace ForestLibrary;

public class ForestContext: DbContext
{
    public ForestContext(DbContextOptions<ForestContext> options):base(options) {}

    public DbSet<Tree>? Trees { get; set; }
    public DbSet<Branch>? Branches { get; set; }
    public DbSet<Leaf>? Leaves { get; set; }
}