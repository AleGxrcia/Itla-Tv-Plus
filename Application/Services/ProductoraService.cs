using Application.Repository;
using Application.ViewModels.Productora;
using Database.Entities;

namespace Application.Services
{
    public interface IProductoraService
    {
        Task Add(SaveProductoraViewModel vm);
        Task Delete(int id);
        Task<List<ProductoraViewModel>> GetAllViewModel();
        Task<SaveProductoraViewModel> GetByIdViewModel(int id);
        Task Update(SaveProductoraViewModel vm);
    }

    public class ProductoraService : IProductoraService
    {
        private readonly IProductoraRepository _repository;

        public ProductoraService(IProductoraRepository repository)
        {
            this._repository = repository;
        }

        public async Task Add(SaveProductoraViewModel vm)
        {
            Productora productora = new();
            productora.Name = vm.Name;

            await _repository.AddAsync(productora);
        }

        public async Task Update(SaveProductoraViewModel vm)
        {
            Productora productora = new();
            productora.Id = vm.Id;
            productora.Name = vm.Name;

            await _repository.UpdateAsync(productora);
        }

        public async Task Delete(int id)
        {
            var productora = await _repository.GetByIdAsync(id);

            if (productora != null)
            {
                await _repository.DeleteAsync(productora);
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<ProductoraViewModel>> GetAllViewModel()
        {
            var list = await _repository.GetAllAsync();
            return list.Select(p => new ProductoraViewModel { 
                Id = p.Id,
                Name = p.Name
            }).ToList();
        }

        public async Task<SaveProductoraViewModel> GetByIdViewModel(int id)
        {
            var productora = await _repository.GetByIdAsync(id);

            if (productora != null)
            {
                SaveProductoraViewModel vm = new();
                vm.Id = productora.Id;
                vm.Name = productora.Name;

                return vm;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
