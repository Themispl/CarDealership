namespace CarDealershipAPI.Core.DomainModels
{
    public class CarCategory
    {

        public int Id { get; init; }
        public string FuelCategory { get; init; }
        public string Manufacturer { get; init; }

        public IReadOnlyCollection<CarType> CarTypes { get; } = new List<CarType>();


        private CarCategory(int id, string fuelCategory, string manufacturer)
        {
            Id = id;
            FuelCategory = fuelCategory;
            Manufacturer = manufacturer;
        }

        public static CarCategory CreateNew(string fuelCategory, string manufacturer)
        {
            var carCategory = new CarCategory(default, fuelCategory, manufacturer);
            return carCategory;
        }

        public static CarCategory Update(int id, string fuelCategory, string manufacturer)
        {
            var carCategory = new CarCategory(id, fuelCategory, manufacturer);
            return carCategory;
        }

    }
}
