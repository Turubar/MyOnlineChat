using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Result<User>> AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public async Task<User?> GetUserByNickname(string nickname)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);
        }
    }
}
