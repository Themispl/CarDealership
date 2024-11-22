using CarDealershipAPI.Core.DomainModels;

namespace CarDealershipAPI.Core.Abstractions
{
    public interface ICarCategoryRepository
    {
        Task<CarCategory?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<CarCategory>> GetAllAsync(CancellationToken cancellationToken);
        Task<CarCategory> InsertAsync(CarCategory carCategory, CancellationToken cancellationToken);
        Task<CarCategory?> UpdateAsync(int id, CarCategory carCategory, CancellationToken cancellationToken);
        Task<CarCategory> DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
