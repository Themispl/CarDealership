using CarDealershipAPI.Core.Abstractions;
using CarDealershipAPI.Core.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipAPI.Data.Repositories
{
    public class CarCategoryRepository : ICarCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CarCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CarCategory>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.CarCategories.ToListAsync(cancellationToken);
        }

        public async Task<CarCategory?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var carCategory = await _context.CarCategories.SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
            return carCategory;
        }

        public async Task<CarCategory> InsertAsync(CarCategory carCategory, CancellationToken cancellationToken)
        {
            await _context.CarCategories.AddAsync(carCategory, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return carCategory;
        }

        public async Task<CarCategory?> UpdateAsync(int id, CarCategory carCategory, CancellationToken cancellationToken)
        {
            if (id.Equals(carCategory.Id) == false)
            {
                throw new Exception("Car Category id does not much provided id");
            }
            var existingCarCategory = await _context.CarCategories.SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
            if (existingCarCategory == null)
            {
                return null;
            }
            _context.Entry(existingCarCategory).CurrentValues.SetValues(carCategory);
            await _context.SaveChangesAsync(cancellationToken);
            return carCategory;
        }

        public async Task<CarCategory> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var carCategory = await GetByIdAsync(id, cancellationToken);
            if (carCategory == null)
            {
                return null;
            }
            _context.CarCategories.Remove(carCategory);
            await _context.SaveChangesAsync(cancellationToken);
            return carCategory;
        }
    }
}
