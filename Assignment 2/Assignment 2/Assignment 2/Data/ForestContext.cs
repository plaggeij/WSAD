using Assignment_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_2.Data;

public class ForestContext: DbContext
{
    public ForestContext(DbContextOptions<ForestContext> options):base(options)
    {
        
    }
    public DbSet<Tree> Trees { get; set; }
    public DbSet<Branch> Branches { get; set; }
}