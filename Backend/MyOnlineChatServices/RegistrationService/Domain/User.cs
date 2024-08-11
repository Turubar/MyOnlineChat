using CSharpFunctionalExtensions;
using RegistrationService.Application;

namespace RegistrationService.Models
{
    public class User
    {
        public User(Guid id, string nickname, string password, DateTime createdDate)
        {
            Id = id;
            Nickname = nickname;
            Password = password;
            CreatedDate = createdDate;
        }

        public Guid Id { get; set; }

        public string Nickname { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
