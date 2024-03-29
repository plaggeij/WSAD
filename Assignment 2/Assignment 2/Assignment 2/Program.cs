using System.Configuration;
using Assignment_2.Data;
using Assignment_2.Dependencies;
using Assignment_2.Middleware;
using Assignment_2.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string connectionName = string.Empty;

if (args.Length == 0)
{
    var env = builder.Configuration.GetValue<string>("Environment");
    
    // Not sure why we need this switch if the environment name matches the connection string name but ok
    // I could see it being needed for other examples but for this assignment seems a little bit extra. 
    switch (env.ToLower())
    {
        case "dev":
            connectionName = "dev";
            break;
        case "test":
            connectionName = "test";
            break;
        case "prod":
            connectionName = "prod";
            break;
        default:
            throw new Exception("Connection string not found");
    }
}
else
{
    connectionName = args[0];
}

builder.Services.AddDbContext<ForestContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(connectionName));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITree, Tree>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    Console.Write("Hello from the forest! \n");
    await next(context);
});
app.UseMiddleware<ForestMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();