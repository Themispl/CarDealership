using CarDealershipAPI.Core.Abstractions;
using CarDealershipAPI.Core.DomainModels;
using CarDealershipAPI.Core.DTOs;
using CarDealershipAPI.Core.Exceptions;
using CarDealershipAPI.Core.Requests;

namespace CarDealershipAPI.Core.Services
{
    public class CarCategoryService : ICarCategoryService
    {
        private readonly ICarCategoryRepository _carCategoryRepository;
        private readonly ICarCategoryMapper _carCategoryMapper;

        public CarCategoryService(ICarCategoryRepository carCategoryRepository, ICarCategoryMapper carCategoryMapper)
        {
            _carCategoryRepository = carCategoryRepository;
            _carCategoryMapper = carCategoryMapper;
        }

        public async Task<IEnumerable<CarCategoryDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var carCategories = await _carCategoryRepository.GetAllAsync(cancellationToken);
            return carCategories.Select(carCategory => _carCategoryMapper.Map(carCategory)).ToList();
        }

        public async Task<CarCategoryDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var carCategory = await _carCategoryRepository.GetByIdAsync(id, cancellationToken);
            if (carCategory == null)
            {
                throw new EntityNotFoundException($"An error occurred while retrieving the car category with id {id}.");
            }

            return _carCategoryMapper.Map(carCategory);
        }

        public async Task<CarCategoryDto> InsertAsync(GetMyDataCategoryRequest request, CancellationToken cancellationToken)
        {
            var carCategory = CarCategory.CreateNew(request.FuelCategory, request.Manufacturer);
            await _carCategoryRepository.InsertAsync(carCategory, cancellationToken);
            return _carCategoryMapper.Map(carCategory);
        }

        public async Task<CarCategoryDto> UpdateAsync(MyDataCategoryUpdateRequest request, CancellationToken cancellationToken)
        {
            var carCategory = await _carCategoryRepository.GetByIdAsync(request.Id, cancellationToken);
            if (carCategory == null)
            {
                throw new Exception("An error occurred while updating the Car Category, Car Category not found.");
            }

            var updatedCarCategory = CarCategory.Update(request.Id, request.FuelCategory, request.Manufacturer);

            await _carCategoryRepository.UpdateAsync(request.Id, updatedCarCategory, cancellationToken);
            return _carCategoryMapper.Map(carCategory);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var carCategory = await _carCategoryRepository.GetByIdAsync(id, cancellationToken);
            if (carCategory == null)
            {
                throw new EntityNotFoundException($"An error occurred while retrieving the car category with id {id}.");
            }
            await _carCategoryRepository.DeleteAsync(id, cancellationToken);

        }
    }
}
