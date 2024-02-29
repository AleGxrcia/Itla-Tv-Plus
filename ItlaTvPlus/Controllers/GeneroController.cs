using Application.Services;
using Application.ViewModels.Generos;
using Microsoft.AspNetCore.Mvc;

namespace ItlaTvPlus.Controllers
{
    public class GeneroController : Controller
    {
        private readonly IGeneroService _service;

        public GeneroController(IGeneroService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllViewModel();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var modelo = new SaveGeneroViewModel();
            return View("SaveGenero", modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveGeneroViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGenero", vm);
            }

            await _service.Add(vm);
            return RedirectToRoute(new { controller = "Genero", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var genero = await _service.GetByIdViewModel(id);
                return View("SaveGenero", genero);
            }
            catch (Exception) 
            {
                return RedirectToRoute(new { controller = "Home", action = "NotFound", backToPage = "Genero" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveGeneroViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGenero", vm);
            }

            await _service.Update(vm);
            return RedirectToRoute(new { controller = "Genero", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var genero = await _service.GetByIdViewModel(id);

                return View("Delete", genero);
            }
            catch (Exception)
            {
                return RedirectToRoute(new { controller = "Home", action = "NotFound", backToPage = "Genero" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGenero(int id)
        {
            try
            {
                await _service.Delete(id);
                return RedirectToRoute(new { controller = "Genero", action = "Index" });
            }
            catch (Exception)
            {
                return RedirectToRoute(new { controller = "Home", action = "NotFound", backToPage = "Genero" });
            }
        }
    }
}
