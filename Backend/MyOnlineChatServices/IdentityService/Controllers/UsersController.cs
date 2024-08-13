using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegistrationService.Application;
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
        private readonly IUserValidationService _validationService;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUserRepository _userRepository;

        public UsersController(IUserValidationService validationService, IPasswordHasher<User> passwordHasher, IUserRepository userRepository) 
        {
            _validationService = validationService;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(RegisterUserRequest request)
        {
            if (_validationService.ValidateUser(request.Nickname, request.Password).IsFailure)
            {
                return BadRequest("Некорректный ввод данных!");
            }

            var existsUser = await _userRepository.GetUserByNickname(request.Nickname);

            if (existsUser != null)
            {
                return BadRequest("Пользователь с таким именем существует!");
            }

            var newUser = new User(Guid.NewGuid(), request.Nickname, request.Password, DateTime.UtcNow);
            newUser.Password = _passwordHasher.HashPassword(newUser, newUser.Password);

            _userRepository.AddUser(newUser);

            return Ok(newUser);
        }
    }
}
