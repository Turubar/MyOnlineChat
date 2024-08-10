using CSharpFunctionalExtensions;
using RegistrationService.Models;

namespace RegistrationService.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByNickname(string nickname);
        Task<Result<User>> AddUser(User user);
    }
}
