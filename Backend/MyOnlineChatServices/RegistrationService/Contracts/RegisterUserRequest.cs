using RegistrationService.Models;
using System.ComponentModel.DataAnnotations;

namespace RegistrationService.Contracts
{
    public record RegisterUserRequest(
        [Required][MinLength(User.MIN_NICKNAME_LENGTH)][MaxLength(User.MAX_NICKNAME_LENGTH)] string Nickname,
        [Required][MinLength(User.MIN_PASSWORD_LENGTH)][MaxLength(User.MAX_PASSWORD_LENGTH)] string Password,
        IFormFile UserImage
        );
}
