using MORENT.Dtos;
using MORENT.Dtos.Filters;

namespace MORENT.Services.Interfaces
{
    public interface ICarService
    {
       Task<GetAllCarsDto> GetAllAsync(CarsFiltersDto filters);
       Task<GetCarDetailsDto> GetByIdAsync(Guid id);
    }
}
