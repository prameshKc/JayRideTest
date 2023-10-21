using JayrideTest.Data;
using JayrideTest.Interfaces;

namespace JayrideTest.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILogger<LocationService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public LocationService(ILogger<LocationService> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            this._configuration = configuration;
        }
        public async Task<LocationInfo> GetLocationInfoAsync(string ipAddress)
        {
            try
            {
                //HTTP request to get location information from ipinfo
                var httpClient = _httpClientFactory.CreateClient("jayride_http");

                string url = string.Format(_configuration["IpInfo"], ipAddress);

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var locationInfo = await response.Content.ReadFromJsonAsync<LocationInfo>();
                    _logger.LogInformation("sucessfully retrieve location information from IP: {ipAddress}", ipAddress);
                    return locationInfo;
                }

                _logger.LogWarning("Failed to retrieve location information for IP : {ipAddress}", ipAddress);
                return null;

            }
            catch (Exception ex)
            {

                _logger.LogError("An error occured while retreiving info for IP : {ipAddress}", ipAddress);
                return null;
            }



        }
    }
}
