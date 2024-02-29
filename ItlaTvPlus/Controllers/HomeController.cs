using Application.Services;
using Application.ViewModels.Series;
using ItlaTvPlus.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web;

namespace ItlaTvPlus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISerieService _serieService;
        private readonly IGeneroService _generoService;
        private readonly IProductoraService _productoraService;

        public HomeController(ISerieService serieService, IGeneroService generoService,
            IProductoraService productoraService)
        {
            this._serieService = serieService;
            this._generoService = generoService;
            this._productoraService = productoraService;
        }

        public async Task<IActionResult> Index(FilterSerieViewModel vm)
        {
            var list = await _serieService.GetAllViewModelWithFilter(vm);
            ViewBag.Generos = await _generoService.GetAllViewModel();
            ViewBag.Productoras = await _productoraService.GetAllViewModel();
            return View(list);
        }

        public IActionResult NotFound(string? backToPage)
        {
            ViewBag.BackToPage = backToPage;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
