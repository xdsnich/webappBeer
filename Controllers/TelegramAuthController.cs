using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json.Linq;
using WebAppbotbeer.Data;
using WebAppbotbeer.Data.Dto;
using WebAppbotbeer.Data.Entities;
using WebAppbotbeer.Services.Auth;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


[ApiController]
[Route("api/[controller]")]
public class TelegramAuthController : ControllerBase
{
    private readonly Context _context;
    private readonly string _botToken;
    private readonly IConfiguration _configuration;
    private readonly GenerateTokenService _jwtGenerateService;

    public TelegramAuthController(Context context, IConfiguration configuration)
    {
        _configuration = configuration;
        _context = context;
        _botToken = configuration["Telegram:BotToken"];
        _jwtGenerateService = new GenerateTokenService(_configuration);
    }

    [HttpPost("telegram-login")]
    public async Task<IActionResult> TelegramLogin([FromBody] TelegramUserDto userDto)
    {
        Console.WriteLine($"Received data: {JsonSerializer.Serialize(userDto)}");



            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.TelegramId == userDto.Id);

            if (existingUser != null)
            {
                existingUser.FirstName = userDto.FirstName;
                existingUser.LastName = userDto.LastName;
                existingUser.Username = userDto.Username;
                existingUser.PhotoUrl = userDto.PhotoUrl;
                existingUser.Hash = userDto.Hash;
                existingUser.AuthDate = userDto.AuthDate;
                
                await _context.SaveChangesAsync();
            }
            try
            {
            if (existingUser == null)
            {
                var newUser = new User
                {
                    TelegramId = userDto.Id,
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Username = userDto.Username,
                    PhotoUrl = userDto.PhotoUrl,
                    Hash = userDto.Hash,
                    AuthDate = userDto.AuthDate,
                    TotalScore = 200
                };
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                existingUser = newUser;
                Console.WriteLine($"User Hash after save: {existingUser?.Hash}");

            }
            existingUser = await _context.Users.FirstOrDefaultAsync(u => u.TelegramId == userDto.Id);
            Console.WriteLine($"checking whether data is loaded{existingUser}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error savaing data: {ex.Message}");
        }
        //var token = _jwtGenerateService.GenerateToken(existingUser);
        
       
        //Console.WriteLine(token);
        return Ok();
    }

}


