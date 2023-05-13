using Assignment1_Plagge_Jake.Models;

namespace Assignment1_Plagge_Jake
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.UseRouting();
            app.MapPost("/api/StuffController/FavoriteNum/AddFavNum/",
                (FavoriteNum favnum) => { return favnum.Name + "'s favorite number is " + favnum.Num; });
            app.Run();
        }
    }
}



