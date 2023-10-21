using JayrideTest.Data;

namespace JayrideTest.Interfaces
{
    public interface ILocationService
    {
        Task<LocationInfo> GetLocationInfoAsync(string ipAddress);
    }
}
