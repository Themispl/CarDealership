using CarDealershipAPI.Core.DomainModels;
using CarDealershipAPI.Core.DTOs;

namespace CarDealershipAPI.Core.Abstractions
{
    public interface ICarTypeMapper
    {
        CarTypeDto Map(CarType carType);
    }
}
