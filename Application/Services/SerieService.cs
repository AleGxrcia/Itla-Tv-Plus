using Application.Repository;
using Application.ViewModels.Generos;
using Application.ViewModels.Series;
using Database.Entities;

namespace Application.Services
{
    public interface ISerieService
    {
        Task Add(SaveSerieViewModel vm);
        Task Update(SaveSerieViewModel vm);
        Task Delete(int id);
        Task<SaveSerieViewModel> GetByIdSaveViewModel(int id);
        Task<List<SerieViewModel>> GetAllViewModel();
        Task<SerieDetailsViewModel> GetByIdDetailsViewModel(int id);
        Task<List<SerieViewModel>> GetAllViewModelWithFilter(FilterSerieViewModel filter);
    }

    public class SerieService : ISerieService
    {
        private readonly ISerieRepository _repository;

        public SerieService(ISerieRepository repository)
        {
            this._repository = repository;
        }

        public async Task Add(SaveSerieViewModel vm)
        {
            Serie serie = new();
            serie.Name = vm.Name;
            serie.ImagePath = vm.ImagePath;
            serie.Url = vm.Url;
            serie.PrimaryGenreId = vm.PrimaryGenre;
            serie.ProductoraId = vm.ProductoraId;

            if (vm.SecondaryGenre != null && vm.SecondaryGenre > 0)
            {
                serie.SecondaryGenreId = vm.SecondaryGenre;
            }

            await _repository.AddAsync(serie);
        }

        public async Task Update(SaveSerieViewModel vm)
        {
            Serie serie = new();
            serie.Id = vm.Id;
            serie.Name = vm.Name;
            serie.ImagePath = vm.ImagePath;
            serie.Url = vm.Url;
            serie.PrimaryGenreId = vm.PrimaryGenre;
            serie.ProductoraId = vm.ProductoraId;

            if (vm.SecondaryGenre != null && vm.SecondaryGenre > 0)
            {
                serie.SecondaryGenreId = vm.SecondaryGenre;
            }

            await _repository.UpdateAsync(serie);
        }

        public async Task Delete(int id)
        {
            var serie = await _repository.GetByIdAsync(id);

            if (serie != null)
            {
                await _repository.DeleteAsync(serie);
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<SaveSerieViewModel> GetByIdSaveViewModel(int id)
        {
            var serie = await _repository.GetByIdAsync(id);

            if (serie != null)
            {
                SaveSerieViewModel vm = new();
                vm.Id = serie.Id;
                vm.Name = serie.Name;
                vm.ImagePath = serie.ImagePath;
                vm.Url = serie.Url;
                vm.PrimaryGenre = serie.PrimaryGenreId;
                vm.ProductoraId = serie.ProductoraId;

                if (serie.SecondaryGenreId != null && serie.SecondaryGenreId > 0)
                {
                    vm.SecondaryGenre = serie.SecondaryGenreId;
                }

                return vm;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<SerieDetailsViewModel> GetByIdDetailsViewModel(int id)
        {
            var serie = await _repository.GetByIdAsync(id);

            if (serie != null)
            {
                SerieDetailsViewModel vm = new();
                vm.Id = serie.Id;
                vm.Name = serie.Name;
                vm.ImagePath = serie.ImagePath;
                vm.Url = serie.Url;
                vm.PrimaryGenreName = serie.PrimaryGenre.Name;
                vm.PrimaryGenreId = serie.PrimaryGenreId;
                vm.SecondaryGenreName = serie.SecondaryGenre?.Name;
                vm.SecondaryGenreId = serie.SecondaryGenreId;
                vm.ProductoraName = serie.Productora.Name;
                vm.ProductoraId = serie.ProductoraId;

                return vm;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<List<SerieViewModel>> GetAllViewModel()
        {
            var list = await _repository.GetAllWithIncludeASync();
            return list.Select(g => new SerieViewModel
            {
                Id = g.Id,
                Name = g.Name,
                ImagePath = g.ImagePath,
                Url = g.Url,
                PrimaryGenreName = g.PrimaryGenre.Name,
                PrimaryGenreId = g.PrimaryGenreId,
                SecondaryGenreName = g.SecondaryGenre?.Name,
                SecondaryGenreId = g.SecondaryGenreId,
                ProductoraName = g.Productora.Name,
                ProductoraId = g.ProductoraId
            }).ToList();
        }

        public async Task<List<SerieViewModel>> GetAllViewModelWithFilter(FilterSerieViewModel filter)
        {
            var list = await _repository.GetAllWithIncludeASync();
            var listViewModel = list.Select(g => new SerieViewModel
            {
                Id = g.Id,
                Name = g.Name,
                ImagePath = g.ImagePath,
                Url = g.Url,
                PrimaryGenreName = g.PrimaryGenre.Name,
                PrimaryGenreId = g.PrimaryGenreId,
                SecondaryGenreName = g.SecondaryGenre?.Name,
                SecondaryGenreId = g.SecondaryGenreId,
                ProductoraName = g.Productora.Name,
                ProductoraId = g.ProductoraId
            }).ToList();

            if (filter.GenreId != null)
            {
                listViewModel = listViewModel.Where(serie =>
                serie.PrimaryGenreId == filter.GenreId.Value ||
                serie.SecondaryGenreId == filter.GenreId.Value).ToList();
            }

            if (filter.ProductoraId != null)
            {
                listViewModel = listViewModel.Where(serie => serie.ProductoraId == filter.ProductoraId.Value).ToList();
            }

            if (filter.SerieSearch != null)
            {
                string searchValue = filter.SerieSearch.ToUpper();
                listViewModel = listViewModel.Where(serie => serie.Name.ToUpper().Contains(searchValue)).ToList();
            }


            return listViewModel;
        }
    }
}
