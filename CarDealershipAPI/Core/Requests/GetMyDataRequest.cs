namespace CarDealershipAPI.Core.Requests
{
    public record GetMyDataRequest
    {
        public required string Model { get; init; }
        public required decimal Price { get; init; }
        public required int CarCategoryId { get; init; }
    }
}
