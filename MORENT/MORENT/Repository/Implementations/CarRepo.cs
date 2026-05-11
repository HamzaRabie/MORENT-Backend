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

         //   query = query.Where(c=>c.IsAvailable); not needed as we will check on payment 

            int total = await query.CountAsync();

            var cars = await query
                .Skip(9 * (filters.pageNo - 1))
                .Take(9)
                .Select(c => new GetCarDetailsDto
                {
                    Id = c.Id,
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

        public async Task<GetCarDetailsDto?> GetByIdAsync(Guid id)
        {
            var car = await _context.Cars.Include(c => c.Reviews).FirstOrDefaultAsync(c => c.Id == id);

            if(car is null)
                return null;

            var dto = new GetCarDetailsDto
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Category = car.Category,
                PricePerDay = car.PricePerDay,
                OriginalPrice = car.OriginalPrice,
                ImageUrl = car.ImageUrl,
                Images = string.IsNullOrEmpty(car.Images)? new List<string>(): car.Images.Split(',').ToList(),
                IsAvailable = car.IsAvailable,
                Seats = car.Seats,
                FuelType = car.FuelType,
                FuelCapacity = car.FuelCapacity,
                Transmission = car.Transmission,
                IsFavorite = car.IsFavorite,
                Description = car.Description,
                Rating = car.Reviews.Any()? Math.Round(car.Reviews.Average(r => r.Rating), 1): 0,
                ReviewCount = car.Reviews.Count,
                Reviews = car.Reviews
                 .OrderByDescending(r => r.CreatedAt)
                 .Select(r => new ReviewDto
                 {
                     Id = r.Id.ToString(),
                     UserName = r.UserName,
                     UserRole = r.UserRole,
                     UserAvatar = r.UserAvatar,
                     Rating = r.Rating,
                     Comment = r.Comment,
                     CreatedAt = r.CreatedAt
                 }).ToList()
            };

            return dto;
        }
    }
}
