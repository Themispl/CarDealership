namespace CarDealershipAPI.Core.DTOs
{
    public record CarCategoryDto
    {
        public int Id { get; init; }
        public string? FuelCategory { get; init; }
        public string? Manufacturer { get; init; }
        public IReadOnlyCollection<CarTypeDto> CarTypes { get; init; } = new List<CarTypeDto>();
    }
}
