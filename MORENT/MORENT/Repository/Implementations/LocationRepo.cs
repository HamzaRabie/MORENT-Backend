
using Microsoft.EntityFrameworkCore;
using MORENT.Context;
using MORENT.Models;
using MORENT.Repository.Interfaces;

namespace MORENT.Repository.Implementations
{
    public class LocationRepo : ILocationRepo
    {
        private readonly AppDbContext _context;

        public LocationRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Location>> GetAllLocations()
        {
            return await _context.Locations.ToListAsync();
        }
    }
}
