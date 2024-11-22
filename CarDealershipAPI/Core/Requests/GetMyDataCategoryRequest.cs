namespace CarDealershipAPI.Core.Requests
{
    public record GetMyDataCategoryRequest
    {
        public required string FuelCategory { get; init; }
        public required string Manufacturer { get; init; }
    }
}
