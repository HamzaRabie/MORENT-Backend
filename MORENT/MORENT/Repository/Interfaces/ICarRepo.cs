using MORENT.Dtos;
using MORENT.Dtos.Filters;
using MORENT.Models;

namespace MORENT.Repository.Interfaces
{
    public interface ICarRepo
    {
        Task<GetAllCarsDto> GetAllAsync(CarsFiltersDto filters);
    }
}
