using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HorizonFutureVest.Web.Controllers
{
    [Authorize]
    public class CountryIndicatorsController : Controller
    {
        private readonly ICountryIndicatorService _service;

        public CountryIndicatorsController(ICountryIndicatorService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetAll());
        }

        public IActionResult Details(int id)
        {
            var item = _service.GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CountryIndicatorViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);
            _service.Add(vm);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var item = _service.GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CountryIndicatorViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);
            _service.Update(vm);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var item = _service.GetById(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

