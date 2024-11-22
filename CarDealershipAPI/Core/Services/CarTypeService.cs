using CarDealershipAPI.Core.Abstractions;
using CarDealershipAPI.Core.DomainModels;
using CarDealershipAPI.Core.DTOs;
using CarDealershipAPI.Core.Requests;

namespace CarDealershipAPI.Core.Services
{
    public class CarTypeService : ICarTypeService
    {
        private readonly ICarTypeRepository _carTypeRepository;
        private readonly ICarTypeMapper _carTypeMapper;

        public CarTypeService(ICarTypeRepository carTypeRepository, ICarTypeMapper carTypeMapper)
        {
            _carTypeRepository = carTypeRepository;
            _carTypeMapper = carTypeMapper;
        }

        public async Task<IEnumerable<CarTypeDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var carTypes = await _carTypeRepository.GetAllAsync(cancellationToken);
            return carTypes.Select(carType => _carTypeMapper.Map(carType)).ToList();

        }

        public async Task<CarTypeDto?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var carType = await _carTypeRepository.GetByIdAsync(id, cancellationToken);
            if (carType == null)
            {
                throw new Exception($"An error occurred while retrieving the car type with id {id}.");
            }
            return _carTypeMapper.Map(carType);
        }

        public async Task<CarTypeDto> InsertAsync(GetMyDataRequest request, CancellationToken cancellationToken)
        {
            var carType = CarType.CrateNew(request.Model, request.Price, request.CarCategoryId);
            await _carTypeRepository.InsertAsync(carType, cancellationToken);
            return _carTypeMapper.Map(carType);
        }

        public async Task<CarTypeDto> UpdateAsync(MyDataUpdateRequest request, CancellationToken cancellationToken)
        {
            var carType = await _carTypeRepository.GetByIdAsync(request.Id, cancellationToken);
            if (carType == null)
            {
                throw new Exception("An error occurred while updating the car type, Car Type not found.");
            }

            var updateCarType = CarType.Update(request.Id, request.Model, request.Price, request.CarCategoryId);

            await _carTypeRepository.UpdateAsync(request.Id, updateCarType, cancellationToken);
            return _carTypeMapper.Map(carType);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var carType = await _carTypeRepository.GetByIdAsync(id, cancellationToken);
            if (carType == null)
            {
                throw new Exception($"An error occurred while retrieving the car type with id {id}.");
            }
            await _carTypeRepository.DeleteAsync(id, cancellationToken);
        }
    }
}
