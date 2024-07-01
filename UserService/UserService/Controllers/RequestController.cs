using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.Models;
using UserService.Models.Entities;

namespace UserService.Controllers
{
    [Route("api")]
    public class RequestController : Controller
    {
        private readonly DatabaseContext _context;

        public RequestController(DatabaseContext context)
        {
            _context = context;
        }

        [Route("users")]
        public DbSet<User> GetUsers ()
        {
            return _context.Users;
        }
    }
}
