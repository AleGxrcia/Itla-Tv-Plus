using Application.Services;
using Application.ViewModels.Productora;
using Microsoft.AspNetCore.Mvc;

namespace ItlaTvPlus.Controllers
{
    public class ProductoraController : Controller
    {
        private readonly IProductoraService _service;

        public ProductoraController(IProductoraService service)
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
            var modelo = new SaveProductoraViewModel();
            return View("SaveProductora", modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveProductoraViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProductora", vm);
            }

            await _service.Add(vm);
            return RedirectToRoute(new { controller = "Productora", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var productora = await _service.GetByIdViewModel(id);
                return View("SaveProductora", productora);
            }
            catch (Exception) 
            {
                return RedirectToRoute(new { controller = "Home", action = "NotFound", backToPage = "Productora" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveProductoraViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProductora", vm);
            }

            await _service.Update(vm);
            return RedirectToRoute(new { controller = "Productora", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var productora = await _service.GetByIdViewModel(id);
                return View("Delete", productora);
            }
            catch (Exception)
            {
                return RedirectToRoute(new { controller = "Home", action = "NotFound", backToPage = "Productora" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProductora(int id)
        {
            try
            {
                await _service.Delete(id);
                return RedirectToRoute(new { controller = "Productora", action = "Index" });
            }
            catch (Exception)
            {
                return RedirectToRoute(new { controller = "Home", action = "NotFound", backToPage = "Productora" });
            }

        }
    }
}
