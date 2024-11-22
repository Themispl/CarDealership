using CarDealershipAPI.Core.DTOs;
using CarDealershipAPI.Core.Requests;

namespace CarDealershipAPI.Core.Abstractions
{
    public interface ICarTypeService
    {
        Task<IEnumerable<CarTypeDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<CarTypeDto?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<CarTypeDto> InsertAsync(GetMyDataRequest request, CancellationToken cancellationToken);
        Task<CarTypeDto> UpdateAsync(MyDataUpdateRequest request, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
