using Microsoft.EntityFrameworkCore;
using MORENT.Context;
using MORENT.Dtos;
using MORENT.Dtos.Filters;
using MORENT.Repository.Interfaces;

namespace MORENT.Repository.Implementations
{
    public class CarRepo : ICarRepo
    {
        private readonly AppDbContext _context;

        public CarRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<GetAllCarsDto> GetAllAsync(CarsFiltersDto filters)
        {
            var query = _context.Cars.AsQueryable();

            if (!string.IsNullOrEmpty(filters.Category))
                query = query.Where(c => c.Category == filters.Category);

            if (filters.SeatsNo.HasValue)
                query = query.Where(c => c.Seats == filters.SeatsNo);

           
            query = query.Where(c => c.PricePerDay <= filters.Price);

            query = query.Where(c=>c.IsAvailable);

            int total = await query.CountAsync();

            var cars = await query
                .Skip(9 * (filters.pageNo - 1))
                .Take(9)
                .Select(c => new GetCarDetailsDto
                {
                    Id = c.Id.ToString(),
                    Brand = c.Brand,
                    Model = c.Model,
                    FuelCapacity = c.FuelCapacity,
                    FuelType = c.FuelType,
                    IsAvailable = c.IsAvailable,
                    IsFavorite = c.IsFavorite, //remove later
                    OriginalPrice = c.OriginalPrice,
                    Transmission = c.Transmission,
                    Category = c.Category,
                    Seats = c.Seats,
                    PricePerDay = c.PricePerDay,
                    ImageUrl = c.ImageUrl
                })
                .ToListAsync();

            return new GetAllCarsDto { Cars = cars, TotalCount = total };

        } 
    }
}
