using CarDealershipAPI.Core.DomainModels;

namespace CarDealershipAPI.Core.Abstractions
{
    public interface ICarTypeRepository
    {
        Task<CarType?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<CarType>> GetAllAsync(CancellationToken cancellationToken);
        Task<CarType> InsertAsync(CarType carType, CancellationToken cancellationToken);
        Task<CarType?> UpdateAsync(int id, CarType carType, CancellationToken cancellationToken);
        Task<CarType> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
