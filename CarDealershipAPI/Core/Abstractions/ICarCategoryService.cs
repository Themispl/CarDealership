using CarDealershipAPI.Core.DTOs;
using CarDealershipAPI.Core.Requests;

namespace CarDealershipAPI.Core.Abstractions
{
    public interface ICarCategoryService
    {
        Task<IEnumerable<CarCategoryDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<CarCategoryDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<CarCategoryDto> InsertAsync(GetMyDataCategoryRequest request, CancellationToken cancellationToken);
        Task<CarCategoryDto> UpdateAsync(MyDataCategoryUpdateRequest request, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
