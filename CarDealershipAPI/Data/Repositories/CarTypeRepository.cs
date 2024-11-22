using CarDealershipAPI.Core.Abstractions;
using CarDealershipAPI.Core.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipAPI.Data.Repositories
{
    public class CarTypeRepository : ICarTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public CarTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarType>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.CarTypes.ToListAsync(cancellationToken);
        }

        public async Task<CarType?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var carType = await _context.CarTypes.SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
            return carType;
        }

        public async Task<CarType> InsertAsync(CarType carType, CancellationToken cancellationToken)
        {
            await _context.CarTypes.AddAsync(carType, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return carType;
        }

        public async Task<CarType?> UpdateAsync(int id, CarType carType, CancellationToken cancellationToken)
        {
            if (id.Equals(carType.Id) == false)
            {
                throw new Exception("Car Type id does not much provided id");
            }
            var existingCarType = await _context.CarTypes.SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
            if (existingCarType == null)
            {
                return null;
            }
            _context.Entry(existingCarType).CurrentValues.SetValues(carType);
            await _context.SaveChangesAsync(cancellationToken);
            return carType;

        }

        public async Task<CarType> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var carType = await GetByIdAsync(id, cancellationToken);
            if (carType == null)
            {
                return null;
            }
            _context.CarTypes.Remove(carType);
            await _context.SaveChangesAsync(cancellationToken);
            return carType;
        }
    }
}
