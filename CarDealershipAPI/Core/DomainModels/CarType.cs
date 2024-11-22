namespace CarDealershipAPI.Core.DomainModels
{
    public class CarType
    {
        public int Id { get; init; }
        public string? Model { get; init; }
        public decimal Price { get; init; }
        public int CarCategoryId { get; init; }

        private CarType(int id, string model, decimal price, int carCategoryId)
        {
            Id = id;
            Model = model;
            Price = price;
            CarCategoryId = carCategoryId;
        }

        public static CarType CrateNew(string model, decimal price, int carCategoryId)
        {
            var carType = new CarType(default, model, price, carCategoryId);
            return carType;
        }

        public static CarType Update(int id, string model, decimal price, int carCategoryId)
        {
            var carCategory = new CarType(id, model, price, carCategoryId);
            return carCategory;
        }
    }
}
