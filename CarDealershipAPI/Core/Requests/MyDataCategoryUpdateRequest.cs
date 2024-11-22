namespace CarDealershipAPI.Core.Requests
{
    public record MyDataCategoryUpdateRequest
    {
        public required int Id { get; init; }
        public required string FuelCategory { get; init; }
        public required string Manufacturer { get; init; }
    }
}
