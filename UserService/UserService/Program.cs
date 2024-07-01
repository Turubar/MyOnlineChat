using Microsoft.EntityFrameworkCore;
using UserService.Models;
using UserService.Models.Entities;

namespace UserService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string? connectionString = builder.Configuration.GetConnectionString("Connection");
            builder.Services.AddDbContext<DatabaseContext>();

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseRouting();

            app.MapControllerRoute("default", "{controller}/{action}");

            app.Run();
        }
    }
}
