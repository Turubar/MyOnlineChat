using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationService.BL;
using RegistrationService.Contracts;
using RegistrationService.DataAccess;
using RegistrationService.DataAccess.Repositories;
using RegistrationService.Models;

namespace RegistrationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly string _staticFilesPath = 
            Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles/UserImages");

        //private readonly UsersDbContext _dbContext;
        private readonly ImageService _imageService;
        private readonly UserRepository _userRepository;

        public UsersController(/*UsersDbContext dbContext,*/ ImageService imageService, UserRepository userRepository) 
        {
            //_dbContext = dbContext;
            _imageService = imageService;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(RegisterUserRequest request)
        {
            var userExists = await _userRepository.GetUserByNickname(request.Nickname);

            if (userExists != null)
            {
                return BadRequest("Пользователь с таким именем существует!");
            }

            var imageResult = await _imageService.CreateImage(request.UserImage, _staticFilesPath);

            if (imageResult.IsFailure)
            {
                return BadRequest(imageResult.Error);
            }

            var newUser = Models.User.Create(Guid.NewGuid(), request.Nickname, request.Password, DateTime.Now, imageResult.Value);

            if (newUser.IsFailure)
            {
                return BadRequest(newUser.Error);
            }

            return Ok(newUser);
        }
    }
}
