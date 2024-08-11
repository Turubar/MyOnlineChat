using CSharpFunctionalExtensions;
using RegistrationService.Application;
using RegistrationService.Models;

namespace RegistrationService.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByNickname(string nickname);
        void AddUser(User user);
    }
}
