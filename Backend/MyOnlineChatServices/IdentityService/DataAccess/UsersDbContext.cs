using Microsoft.EntityFrameworkCore;
using RegistrationService.Models;

namespace RegistrationService.DataAccess
{
    public class UsersDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<User> Users => Set<User>();

        public UsersDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Database"));
        }
    }
}
