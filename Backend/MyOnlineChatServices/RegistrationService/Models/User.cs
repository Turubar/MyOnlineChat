namespace RegistrationService.Models
{
    public class User
    {
        public User (string nickname, string password)
        {
            Nickname = nickname;
            Password = password;
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; init; }

        public string Nickname { get; init; }

        public string Password { get; init; }

        public DateTime CreatedAt { get; init; }
    }
}
