using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrationService.Contracts;
using RegistrationService.DataAccess;
using RegistrationService.Models;

namespace RegistrationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersDbContext _dbContext;

        public UsersController(UsersDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken ct)
        {
            
            var user = new User(request.Nickname, request.Password);

            await _dbContext.Users.AddAsync(user, ct);
            await _dbContext.SaveChangesAsync(ct);

            return Ok();
        }
    }
}
