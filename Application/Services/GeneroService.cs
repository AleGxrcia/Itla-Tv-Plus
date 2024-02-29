using Application.Repository;
using Application.ViewModels.Generos;
using Database.Entities;

namespace Application.Services
{
    public interface IGeneroService
    {
        Task Add(SaveGeneroViewModel vm);
        Task Delete(int id);
        Task<List<GeneroViewModel>> GetAllViewModel();
        Task<SaveGeneroViewModel> GetByIdViewModel(int id);
        Task Update(SaveGeneroViewModel vm);
    }

    public class GeneroService : IGeneroService
    {
        private readonly IGeneroRepository _repository;

        public GeneroService(IGeneroRepository repository)
        {
            this._repository = repository;
        }

        public async Task Add(SaveGeneroViewModel vm)
        {
            Genre genero = new();
            genero.Name = vm.Name;
            
            await _repository.AddAsync(genero);
        }

        public async Task Update(SaveGeneroViewModel vm)
        {
            Genre genero = new();
            genero.Id = vm.Id;
            genero.Name = vm.Name;

            await _repository.UpdateAsync(genero);
        }

        public async Task Delete(int id)
        {
            var genero = await _repository.GetByIdAsync(id);

            if (genero != null)
            {
                await _repository.DeleteAsync(genero);
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<GeneroViewModel>> GetAllViewModel()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(g => new GeneroViewModel {
                Id = g.Id,
                Name = g.Name
            }).ToList();
        }

        public async Task<SaveGeneroViewModel> GetByIdViewModel(int id)
        {
            var genero = await _repository.GetByIdAsync(id);

            if (genero != null)
            {
                SaveGeneroViewModel vm = new();
                vm.Id = genero.Id;
                vm.Name = genero.Name;

                return vm;
            }
            else
            {
                throw new Exception();
            }

        }

    }
}
