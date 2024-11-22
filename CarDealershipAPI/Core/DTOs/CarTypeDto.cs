namespace CarDealershipAPI.Core.DTOs
{
    public record CarTypeDto
    {
        public int Id { get; init; }
        public string? Model { get; init; }
        public decimal Price { get; init; }
        public int CarCategoryId { get; init; }
    }
}

