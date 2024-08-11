using CSharpFunctionalExtensions;
using RegistrationService.Models;
using System.ComponentModel.DataAnnotations;

namespace RegistrationService.Application
{
    public interface IUserValidationService
    {
        Result ValidateUser(string nickname, string password);
    }
}
