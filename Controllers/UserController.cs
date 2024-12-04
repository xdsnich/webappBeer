using Microsoft.AspNetCore.Mvc;
using WebAppbotbeer.Data;
using WebAppbotbeer.Data.Entities;
namespace WebAppbotbeer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly Context _context;

        public UserController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SaveUser([FromBody] User userDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.TelegramId == userDto.TelegramId);

            if (user == null)
            {
                user = new User
                {
                    TelegramId = userDto.TelegramId,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Username = userDto.Username,
                    PhotoUrl = userDto.PhotoUrl,
                    DrinkEntries = userDto.DrinkEntries ?? new List<DrinkEntry>()
                };
                _context.Users.Add(user);
            }
            else
            {
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.Username = userDto.Username;
            }

            _context.SaveChanges();
            return Ok(user);
        }
    }
}
