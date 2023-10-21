using JayrideTest.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JayrideTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly ILogger<ListingController> _logger;
        private readonly IListingService _listingService;

        public ListingController(ILogger<ListingController> logger, IListingService listingService)
        {
            this._logger = logger;
            _listingService = listingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListing(int passenger)
        {
            if (passenger == 0)
                return BadRequest();

            _logger.LogInformation("Receiving requset for GetListingfor passengers {passenger}", passenger);

            var listingInfo = await _listingService.GetListingsAsync(passenger);
            if (listingInfo == null)
                return NotFound();

            return Ok(listingInfo);
        }

    }
}
