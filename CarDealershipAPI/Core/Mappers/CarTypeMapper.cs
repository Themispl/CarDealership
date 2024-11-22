using CarDealershipAPI.Core.Abstractions;
using CarDealershipAPI.Core.DomainModels;
using CarDealershipAPI.Core.DTOs;

namespace CarDealershipAPI.Core.Mappers
{
    public class CarTypeMapper : ICarTypeMapper
    {
        public CarTypeDto Map(CarType carType)
        {
            return new CarTypeDto
            {
                Id = carType.Id,
                Model = carType.Model,
                Price = carType.Price,
                CarCategoryId = carType.CarCategoryId
            };
        }
    }
}
