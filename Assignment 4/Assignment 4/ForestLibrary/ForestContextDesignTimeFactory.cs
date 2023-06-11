using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ForestLibrary;

public class ForestContextDesignTimeFactory: IDesignTimeDbContextFactory<ForestContext>
{
    public ForestContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ForestContext>();
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()) + "/ForestMVC/")
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(config.GetConnectionString("dev"));
        return new ForestContext(optionsBuilder.Options);
    }
}