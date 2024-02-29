using Application.Services;
using Application.ViewModels.Generos;
using Application.ViewModels.Series;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace ItlaTvPlus.Controllers
{
    public class SerieController : Controller
    {
        private readonly IGeneroService _generoService;
        private readonly IProductoraService _productoraService;
        private readonly ISerieService _service;

        public SerieController(IGeneroService generoService, IProductoraService productoraService,
            ISerieService service)
        {
            this._generoService = generoService;
            this._productoraService = productoraService;
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllViewModel();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var listGeneros = await _generoService.GetAllViewModel();
            var listProductoras = await _productoraService.GetAllViewModel();
            var modelo = new SaveSerieViewModel()
            {
                Generos = listGeneros,
                Productoras = listProductoras
            };

            return View("SaveSerie", modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveSerieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Generos = await _generoService.GetAllViewModel();
                vm.Productoras = await _productoraService.GetAllViewModel();
                return View("SaveSerie", vm);
            }

            await _service.Add(vm);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var serie = await _service.GetByIdSaveViewModel(id);
                serie.Generos = await _generoService.GetAllViewModel();
                serie.Productoras = await _productoraService.GetAllViewModel();
                return View("SaveSerie", serie);
            }
            catch (Exception)
            {
                return RedirectToRoute(new { controller = "Home", action = "NotFound", backToPage = "Serie" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveSerieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveSerie", vm);
            }

            await _service.Update(vm);
            return RedirectToRoute(new { controller = "Serie", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var serie = await _service.GetByIdSaveViewModel(id);
                return View("Delete", serie);
            }
            catch (Exception)
            {
                return RedirectToRoute(new { controller = "Home", action = "NotFound", backToPage = "Serie" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSerie(int id)
        {
            try
            {
                await _service.Delete(id);
                return RedirectToRoute(new { controller = "Serie", action = "Index" });
            }
            catch (Exception)
            {
                return RedirectToRoute(new { controller = "Home", action = "NotFound", backToPage = "Serie" });
            }
        }

        public async Task<IActionResult> VerDetalle(int id)
        {
            try
            {
                var serie = await _service.GetByIdDetailsViewModel(id);
                var videoId = ExtraerVideoId(serie.Url);
                serie.Url = videoId;

                return View("SerieDetalle", serie);
            }
            catch (Exception)
            {
                return RedirectToRoute(new { controller = "Home", action = "NotFound", backToPage = "Serie" });
            }
        }

        public string ExtraerVideoId(string url)
        {
            var uri = new Uri(url);

            var query = HttpUtility.ParseQueryString(uri.Query);

            var videoId = string.Empty;

            if (query.AllKeys.Contains("v"))
            {
                // Enlace en formato "watch?v="
                videoId = query.Get("v");
            }
            else if (uri.Segments.Length > 1)
            {
                // Enlace en formato "embed/"
                var segment = uri.Segments[uri.Segments.Length - 1];
                videoId = segment.TrimEnd('/');
            }

            return videoId;
        }


    }
}
