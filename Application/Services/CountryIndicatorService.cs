using Application.Interfaces;
using Application.ViewModels;
using Persistence.Entities;
using Persistence.Persistence;

namespace Application.Services
{
    public class CountryIndicatorService : ICountryIndicatorService
    {
        private readonly InvestmentAppContext _context;

        public CountryIndicatorService(InvestmentAppContext context)
        {
            _context = context;
        }

        public List<CountryIndicatorViewModel> GetAll()
        {
            return _context.CountryIndicators
                .Select(ci => new CountryIndicatorViewModel
                {
                    Id = ci.Id,
                    CountryId = ci.CountryId,
                    MacroIndicatorId = ci.MacroIndicatorId,
                    Year = ci.year,
                    Value = ci.value
                }).ToList();
        }

        public CountryIndicatorViewModel? GetById(int id)
        {
            var ci = _context.CountryIndicators.FirstOrDefault(x => x.Id == id);
            if (ci == null) return null;

            return new CountryIndicatorViewModel
            {
                Id = ci.Id,
                CountryId = ci.CountryId,
                MacroIndicatorId = ci.MacroIndicatorId,
                Year = ci.year,
                Value = ci.value
            };
        }

        public void Add(CountryIndicatorViewModel vm)
        {
            var entity = new CountryIndicator
            {
                CountryId = vm.CountryId,
                MacroIndicatorId = vm.MacroIndicatorId,
                year = vm.Year,
                value = vm.Value
            };
            _context.CountryIndicators.Add(entity);
            _context.SaveChanges();
        }

        public void Update(CountryIndicatorViewModel vm)
        {
            var entity = _context.CountryIndicators.FirstOrDefault(x => x.Id == vm.Id);
            if (entity == null) return;

            entity.CountryId = vm.CountryId;
            entity.MacroIndicatorId = vm.MacroIndicatorId;
            entity.year = vm.Year;
            entity.value = vm.Value;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.CountryIndicators.FirstOrDefault(x => x.Id == id);
            if (entity == null) return;

            _context.CountryIndicators.Remove(entity);
            _context.SaveChanges();
        }
    }
}

