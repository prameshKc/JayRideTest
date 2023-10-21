using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JayrideTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ILogger<CandidateController> _logger;

        public CandidateController(ILogger<CandidateController> logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        public IActionResult GetCandidateInfo()
        {
            _logger.LogInformation("received GetCandidateInfo Endpoint request");
            var response = new
            {
                name = "test",
                phone = "test"
            };

            return Ok(response);
        }
    }
}
