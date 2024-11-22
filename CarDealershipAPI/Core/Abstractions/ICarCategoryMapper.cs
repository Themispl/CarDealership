using CarDealershipAPI.Core.DomainModels;
using CarDealershipAPI.Core.DTOs;

namespace CarDealershipAPI.Core.Abstractions
{
    public interface ICarCategoryMapper
    {
        CarCategoryDto Map(CarCategory carCategory);
    }
}
