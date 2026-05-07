using MORENT.Models;

namespace MORENT.Services.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> GetAllLocations();
    }
}
