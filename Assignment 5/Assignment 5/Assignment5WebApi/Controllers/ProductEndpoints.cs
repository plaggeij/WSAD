using Microsoft.EntityFrameworkCore;
using Assignment5Library.Data;
using Assignment5Library.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace Assignment5WebApi.Controllers;

public static class ProductEndpoints
{
    public static void MapProductEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Product").WithTags(nameof(Product));

        group.MapGet("/", async (StoreContext db) =>
        {
            return await db.Products.ToListAsync();
        })
        .WithName("GetAllProducts")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Product>, NotFound>> (int productid, StoreContext db) =>
        { 
            return await db.Products.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.ProductId == productid) 
                    is Product model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetProductById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int productid, Product product, StoreContext db) =>
        {
            var affected = await db.Products
                .Where(model => model.ProductId == productid)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.ProductId, product.ProductId)
                  .SetProperty(m => m.ProductName, product.ProductName)
                  .SetProperty(m => m.ProductPrice, product.ProductPrice)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateProduct")
        .WithOpenApi();

        group.MapPost("/", async (Product product, StoreContext db) =>
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Product/{product.ProductId}",product);
        })
        .WithName("CreateProduct")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int productid, StoreContext db) =>
        {
            var affected = await db.Products
                .Where(model => model.ProductId == productid)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteProduct")
        .WithOpenApi();
    }
}
