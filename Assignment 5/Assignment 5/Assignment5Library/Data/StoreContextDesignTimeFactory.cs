using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Assignment5Library.Data;

public class StoreContextDesignTimeFactory: IDesignTimeDbContextFactory<StoreContext>
{
    public StoreContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()) + "/Assignment 6 Wapi/")
            .AddJsonFile("appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(config.GetConnectionString("StoreDB"));
        return new StoreContext(optionsBuilder.Options);
    }
}