using CSharpFunctionalExtensions;
using RegistrationService.DataAccess;
using RegistrationService.Models;
using System.ComponentModel.DataAnnotations;

namespace RegistrationService.Application
{
    public class UserValidationService : IUserValidationService
    {
        private readonly UsersDbContext _dbContext;

        public const int MIN_NICKNAME_LENGTH = 4;
        public const int MAX_NICKNAME_LENGTH = 20;

        public const int MIN_PASSWORD_LENGTH = 8;
        public const int MAX_PASSWORD_LENGTH = 30;

        public UserValidationService(UsersDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Result ValidateUser(string nickname, string password)
        {
            if (string.IsNullOrEmpty(nickname) || nickname.Length < MIN_NICKNAME_LENGTH || nickname.Length > MAX_NICKNAME_LENGTH)
            {
                return Result.Failure("Некорректное имя пользователя!");
            }

            if (string.IsNullOrEmpty(password) || password.Length < MIN_PASSWORD_LENGTH || password.Length > MAX_PASSWORD_LENGTH)
            {
                return Result.Failure("Некорректный пароль!");
            }

            return Result.Success();
        }
    }
}
