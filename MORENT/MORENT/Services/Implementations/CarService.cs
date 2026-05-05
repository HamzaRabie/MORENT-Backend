using MORENT.Dtos;
using MORENT.Dtos.Filters;
using MORENT.Repository.Interfaces;
using MORENT.Services.Interfaces;

namespace MORENT.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepo _carRepo;

        public CarService(ICarRepo carRepo)
        {
            _carRepo = carRepo;
        }
        public async Task<GetAllCarsDto> GetAllAsync(CarsFiltersDto filters)
        {
            return await _carRepo.GetAllAsync(filters);
        }
    }
}
