using MORENT.Models;

namespace MORENT.Repository.Interfaces
{
    public interface ILocationRepo
    {
        Task<List<Location>> GetAllLocations();
    }
}
