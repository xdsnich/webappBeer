// using Microsoft.AspNetCore.Mvc;
// using Microsoft.IdentityModel.Tokens;
// using System;
// using WebAppbotbeer.Data;
// using WebAppbotbeer.Data.Entities;

// namespace WebAppbotbeer.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class DrinkEntriesController : ControllerBase
//     {
//         private readonly Context _context;

//         public DrinkEntriesController(Context context)
//         {
//             _context = context;
//         }

//         [HttpGet("{userId}")]
//         public IActionResult GetEntries(int userId)
//         {
//             var entries = _context.DrinkEntries
//                 .Where(e => e.UserId == userId)
//                 .ToList();
//             return Ok(entries);
//         }

//         [HttpPost]
//         public IActionResult AddEntry([FromBody] DrinkEntry entry)
//         {
//             if (entry == null || entry.Liters <= 0 || entry.Date == default)
//             {
//                 return BadRequest("Invalid entry data.");
//             }

//             _context.DrinkEntries.Add(entry);
//             _context.SaveChanges();
//             return Ok(entry);
//         }

//     }
// }
