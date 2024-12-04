using Microsoft.AspNetCore.Mvc;
using WebAppbotbeer.Data.Entities;
using WebAppbotbeer.Data;
using WebAppbotbeer.Data.BarList;
using System;
using WebAppbotbeer.Services.MapServices;
namespace WebAppbotbeer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly Context _context;
        private readonly MapService _mapService;
        private readonly BarLocations _barLocations;
        public LocationController(Context context) 
        {
            _context = context;
            _mapService = new MapService();
            _barLocations = new BarLocations();
        }
        [HttpPost("nearest-pubs")]
        public IActionResult GetNearestPubs([FromBody] LocationData location)
        {
            if (location == null)
            {
                return BadRequest("Invalid location data.");
            }

            Console.WriteLine($"Received user location: Lat {location.Latitude}, Lng {location.Longitude}");

            var pubs = _barLocations.GetPubs();

            var nearestPubs = pubs
                .Select(pub => new
                {
                    pub.Id,
                    pub.Name,
                    pub.Latitude,
                    pub.Longitude,
                    Distance = _mapService.GetDistance(location.Latitude, location.Longitude, pub.Latitude, pub.Longitude)
                })
                .OrderBy(pub => pub.Distance) 
                .Take(3) 
                .ToList();

            Console.WriteLine($"Found {nearestPubs.Count} nearest pubs.");

            return Ok(nearestPubs);
        }

        [HttpPost("receive-location")]
        public IActionResult ReceiveLocation([FromBody] LocationData location)
        {
            if (location == null)
            {
                Console.WriteLine("ReceiveLocation method called.");
                return BadRequest("Invalid location data.");
            }

            try
            {
                location.Timestamp = DateTime.UtcNow;
                _context.Locations.Add(location);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving location to database: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

            Console.WriteLine($"Received location: Lat {location.Latitude}, Lng {location.Longitude}");
            Console.WriteLine($"Location saved at {location.Timestamp}");

            return Ok(new { success = true, locationId = location.Id });
        }


    }
}
