using MORENT.Models;
using MORENT.Repository.Interfaces;
using MORENT.Services.Interfaces;

namespace MORENT.Services.Implementations
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepo _locationRepo;

        public LocationService(ILocationRepo _locationRepo)
        {
            this._locationRepo = _locationRepo;
        }
        public async Task<List<Location>> GetAllLocations()
        {
            return await _locationRepo.GetAllLocations();
        }
    }
}
