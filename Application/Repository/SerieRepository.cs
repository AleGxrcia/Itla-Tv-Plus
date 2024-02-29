using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public interface ISerieRepository
    {
        Task AddAsync(Serie serie);
        Task UpdateAsync(Serie serie);
        Task<List<Serie>> GetAllAsync();
        Task<Serie?> GetByIdAsync(int id);
        Task<List<Serie>> GetAllWithIncludeASync();
        Task DeleteAsync(Serie serie);
    }

    public class SerieRepository : ISerieRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SerieRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddAsync(Serie serie)
        {
            //serie.Genres.ToList().ForEach(g => _dbContext.Entry(g).State = EntityState.Unchanged);
            await _dbContext.Set<Serie>().AddAsync(serie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Serie serie)
        {
            _dbContext.Entry(serie).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Serie serie)
        {
            _dbContext.Set<Serie>().Remove(serie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Serie?> GetByIdAsync(int id)
        {
            return await _dbContext
                    .Set<Serie>()
                    .Include(s => s.PrimaryGenre)
                    .Include(s => s.SecondaryGenre)
                    .Include(s => s.Productora)
                    .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Serie>> GetAllAsync()
        {
            return await _dbContext
                    .Set<Serie>()
                    .ToListAsync();
        }

        public async Task<List<Serie>> GetAllWithIncludeASync()
        {
            return await _dbContext.Set<Serie>()
                    .Include(s => s.PrimaryGenre)
                    .Include(s => s.SecondaryGenre)
                    .Include(serie => serie.Productora)
                    .ToListAsync();
        }
    }
}
