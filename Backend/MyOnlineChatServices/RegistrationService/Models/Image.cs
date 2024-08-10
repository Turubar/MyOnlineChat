using CSharpFunctionalExtensions;

namespace RegistrationService.Models
{
    public class Image
    { 
        public Image(string fileName) 
        {
            FileName = fileName;
        }

        public Guid UserId { get; set; }

        public string FileName { get; set; } = string.Empty;

        public static Result<Image> Create(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return Result.Failure<Image>("Некорректное имя файла!");
            }

            var image = new Image(fileName);

            return Result.Success(image);
        }
    }
}