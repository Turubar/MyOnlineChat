using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using RegistrationService.Application;
using RegistrationService.Models;

namespace RegistrationService.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersDbContext _context;

        public UserRepository(UsersDbContext context)
        {
            _context = context;
        }

        public async void AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByNickname(string nickname)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);
        }
    }
}
