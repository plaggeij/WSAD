namespace Assignment_2.Middleware;

public class ForestMiddleware
{
    private readonly RequestDelegate next;

    public ForestMiddleware(RequestDelegate Next)
    {
        next = Next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path;
        if (path.StartsWithSegments("/api/Tree"))
        {
            Console.WriteLine("Forest Middleware: A tree themed request has been detected!");
        }

        await next(context);
    }
}