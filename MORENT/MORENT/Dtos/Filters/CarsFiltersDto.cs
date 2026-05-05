namespace MORENT.Dtos.Filters
{
    public record CarsFiltersDto
    {
        public  string? Category { get; set; }
        public  int? SeatsNo { get; set; }
        public int pageNo { get; set; } =1;
      //  public int pageSize { get; set; } = 9;
        public  decimal? Price { get; set; }
    }
}
