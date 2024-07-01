using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserService.Models.Entities;

namespace UserService.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; } 

        public DatabaseContext()
        { 

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connection = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionString")["Connection"];
            optionsBuilder.UseNpgsql(connection);
        }
    }
}
