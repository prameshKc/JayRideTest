using JayrideTest.Data;

namespace JayrideTest.Interfaces
{
    public interface IListingService
    {
        Task<ListingInfo> GetListingsAsync(int passengers);
    }
}
