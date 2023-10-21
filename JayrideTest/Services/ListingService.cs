using JayrideTest.Data;
using JayrideTest.Interfaces;
using System.Net;

namespace JayrideTest.Services
{
    public class ListingService : IListingService
    {
        private readonly ILogger<ListingService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ListingService(ILogger<ListingService> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            this._configuration = configuration;
        }
        public async Task<ListingInfo> GetListingsAsync(int passengers)
        {
            try
            {
                //HTTP request to get Listing information from https://jayridechallengeapi.azurewebsites.net/
                var httpClient = _httpClientFactory.CreateClient("jayride_http");


                var response = await httpClient.GetAsync("https://jayridechallengeapi.azurewebsites.net/api/QuoteRequest");

                if (response.IsSuccessStatusCode)
                {
                    var listingInfo = await response.Content.ReadFromJsonAsync<ListingInfo>();

                    if (listingInfo == null || listingInfo.Listings.Count == 0)
                    {
                        _logger.LogInformation("No listing found for {passengers} passengers", passengers);
                        return null;
                    }
                    _logger.LogInformation("sucessfully retrieve listing");

                    listingInfo.Listings = listingInfo.Listings.Where(p => p.VehicleType.MaxPassengers >= passengers).ToList();

                    foreach (var item in listingInfo.Listings)
                    {
                        item.TotalPrice = item.PricePerPassenger * passengers;
                    }

                    listingInfo.Listings = listingInfo.Listings.OrderBy(p => p.TotalPrice).ToList();


                    return listingInfo;
                }
                return null;



            }
            catch (Exception ex)
            {

                _logger.LogError("An error occured while receiving Listing info");
                return null;
            }

        }
    }
}
