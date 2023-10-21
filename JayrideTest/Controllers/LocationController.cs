using JayrideTest.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JayrideTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {

        private readonly ILogger<LocationController> _logger;
        private readonly ILocationService _iLocation;

        public LocationController(ILogger<LocationController> logger, ILocationService iLocation)
        {
            _logger = logger;
            _iLocation = iLocation;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocationInfo(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress))
                return BadRequest();

            _logger.LogInformation("Receiving requset for GetLocationInfo with IP: {ipAddress}", ipAddress);

            var locationInfo = await _iLocation.GetLocationInfoAsync(ipAddress);
            if (locationInfo == null)
                return NotFound();

            return Ok(locationInfo);
        }

    }
}
