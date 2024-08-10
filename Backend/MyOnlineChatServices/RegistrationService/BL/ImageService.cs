using CSharpFunctionalExtensions;
using RegistrationService.Models;

namespace RegistrationService.BL
{
    public class ImageService
    {
        public async Task<Result<Image>> CreateImage(IFormFile userImage, string path)
        {
            try
            {
                var fileName = Path.GetFileName(userImage.FileName);
                var filePath = Path.Combine(path, fileName);

                await using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await userImage.CopyToAsync(stream);
                }

                var image = Image.Create(filePath);

                return image;
            }
            catch (Exception ex)
            {
                return Result.Failure<Image>(ex.Message);
            }
        }
    }
}
