using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public interface IProductoraRepository
    {
        Task AddAsync(Productora productora);
        Task DeleteAsync(Productora entity);
        Task<List<Productora>> GetAllAsync();
        Task<Productora?> GetByIdAsync(int id);
        Task UpdateAsync(Productora productora);
    }

    public class ProductoraRepository : IProductoraRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductoraRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddAsync(Productora productora)
        {
            await _dbContext.Set<Productora>().AddAsync(productora);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Productora productora)
        {
            _dbContext.Entry(productora).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Productora entity)
        {
            _dbContext.Set<Productora>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Productora>> GetAllAsync()
        {
            return await _dbContext
                .Set<Productora>()
                .ToListAsync();
        }

        public async Task<Productora?> GetByIdAsync(int id)
        {
            return await _dbContext
                .Set<Productora>()
                .FindAsync(id);
        }
    }
}
