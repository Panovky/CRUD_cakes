using CRUD_cakes.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_cakes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string? con = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<CakesContext>(option => option.UseNpgsql(con));

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "index",
                pattern: "{controller=Cake}/{action=Index}/");

            app.Run();
        }
    }
}
