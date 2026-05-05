namespace MORENT.Dtos
{
    public class GetAllCarsDto
    {
            public List<GetCarDetailsDto> Cars { get; set; } = new List<GetCarDetailsDto>();
            public int TotalCount { get; set; }
    }
}
