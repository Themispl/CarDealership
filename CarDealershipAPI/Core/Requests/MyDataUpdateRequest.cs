namespace CarDealershipAPI.Core.Requests
{
    public record MyDataUpdateRequest
    {
        public int Id { get; init; }
        public required string Model { get; init; }
        public required decimal Price { get; init; }
        public required int CarCategoryId { get; init; }
    }
}
