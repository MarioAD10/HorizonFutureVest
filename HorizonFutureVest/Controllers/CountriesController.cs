using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HorizonFutureVest.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController (ICountryService countryService)
        {
            _countryService = countryService;
        }

        // Get: Countries
        public IActionResult Index()
        {
            var countries = _countryService.GetAll();
            return View(countries);
        }

        // GET: Countries/Details/5
        public IActionResult Details(int id)
        {
            var country = _countryService.GetById(id);
            if (country == null) return NotFound();

            return View(country);
        }

        // GET: Countries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CountryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            _countryService.Add(vm);
            return RedirectToAction(nameof(Index));
        }

        // GET: Countries/Edit/5
        public IActionResult Edit(int id)
        {
            var country = _countryService.GetById(id);
            if (country == null) return NotFound();

            return View(country);
        }


        // POST: Countries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CountryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            _countryService.Update(vm);
            return RedirectToAction(nameof(Index));
        }

        // GET: Countries/Delete/5
        public IActionResult Delete(int id)
        {
            var country = _countryService.GetById(id);
            if (country == null) return NotFound();

            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _countryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
