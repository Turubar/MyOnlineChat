using System.ComponentModel.DataAnnotations;

namespace RegistrationService.Contracts
{
    public record RegisterUserRequest([Required] string Nickname, [Required] string Password);
}
