using CSharpFunctionalExtensions;

namespace RegistrationService.Models
{
    public class User
    {
        public const int MIN_NICKNAME_LENGTH = 6;
        public const int MAX_NICKNAME_LENGTH = 20;

        public const int MIN_PASSWORD_LENGTH = 8;
        public const int MAX_PASSWORD_LENGTH = 30;

        private User (Guid id, string nickname, string password, DateTime createdDate, Image? userImage)
        {
            Id = id;
            Nickname = nickname;
            Password = password;
            CreatedDate = createdDate;
            UserImage = userImage;
        }

        public Guid Id { get; }

        public string Nickname { get; } = string.Empty;

        public string Password { get; } = string.Empty;

        public DateTime CreatedDate { get; }

        public Image? UserImage { get; }

        public static Result<User> Create(Guid id, string nickname, string password, DateTime createdDate, Image? userImage)
        {
            //if (id == Guid.Empty) ???

            if (string.IsNullOrEmpty(nickname) || nickname.Length < MIN_NICKNAME_LENGTH || nickname.Length > MAX_NICKNAME_LENGTH)
            {
                return Result.Failure<User>("Некорректное имя пользователя!");
            }

            if (string.IsNullOrEmpty(password) || password.Length < MIN_PASSWORD_LENGTH || password.Length > MAX_PASSWORD_LENGTH)
            {
                return Result.Failure<User>("Некорректный пароль!");
            }

            var user = new User(id, nickname, password, createdDate, userImage);

            return Result.Success(user);
        }
    }
}
