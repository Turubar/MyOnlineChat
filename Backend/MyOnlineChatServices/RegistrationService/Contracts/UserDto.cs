namespace RegistrationService.Contracts
{
    public record UserDto(Guid Id, string Nickname, DateTime CreatedAt);
}
