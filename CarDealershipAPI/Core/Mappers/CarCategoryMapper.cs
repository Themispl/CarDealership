using CarDealershipAPI.Core.Abstractions;
using CarDealershipAPI.Core.DomainModels;
using CarDealershipAPI.Core.DTOs;


namespace CarDealershipAPI.Core.Mappers
{
    public class CarCategoryMapper : ICarCategoryMapper
    {
        private readonly ICarTypeMapper _carTypeMapper;
        public CarCategoryMapper(ICarTypeMapper carTypeMapper)
        {
            _carTypeMapper = carTypeMapper;
        }
        public CarCategoryDto Map(CarCategory carCategory)
        {

            return new CarCategoryDto
            {
                Id = carCategory.Id,
                FuelCategory = carCategory.FuelCategory,
                Manufacturer = carCategory.Manufacturer,
                CarTypes = carCategory.CarTypes.Select(carType => _carTypeMapper.Map(carType)).ToList()
            };
        }
    }
}
