using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public interface IGeneroRepository
    {
        Task AddAsync(Genre genero);
        Task DeleteAsync(Genre entity);
        Task<List<Genre>> GetAllAsync();
        Task<Genre?> GetByIdAsync(int id);
        Task UpdateAsync(Genre genero);
    }

    public class GeneroRepository : IGeneroRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GeneroRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddAsync(Genre genero)
        {
            await _dbContext.Set<Genre>().AddAsync(genero);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Genre genero)
        {
            _dbContext.Entry(genero).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Genre entity)
        {
            _dbContext.Set<Genre>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Genre>> GetAllAsync()
        {
            return await _dbContext
                    .Set<Genre>()
                    .ToListAsync();
        }

        public async Task<Genre?> GetByIdAsync(int id)
        {
            return await _dbContext
                    .Set<Genre>()
                    .FindAsync(id);
        }
    }
}
