using Application.Interfaces;
using Application.ViewModels;
using Persistence.Entities;
using Persistence.Persistence;


namespace Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly InvestmentAppContext _context;

        public CountryService(InvestmentAppContext context)
        {
            _context = context;
        }

        public List<CountryViewModel> GetAll()
        {
            return _context.Countries
                .Select(c => new CountryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsoCode = c.IsoCode
                }).ToList();
        }

        public CountryViewModel? GetById(int id)
        {
            var c = _context.Countries.FirstOrDefault(x => x.Id == id);
            if (c == null) return null;

            return new CountryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                IsoCode = c.IsoCode
            };
        }

        public void Add(CountryViewModel vm)
        {
            var entity = new Country
            {
                Name = vm.Name,
                IsoCode = vm.IsoCode
            };

            _context.Countries.Add(entity);
            _context.SaveChanges();
        }

        public void Update(CountryViewModel vm)
        {
            var entity = _context.Countries.FirstOrDefault(x => x.Id == vm.Id);
            if (entity == null) return;

            entity.Name = vm.Name;
            entity.IsoCode = vm.IsoCode;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Countries.FirstOrDefault(x => x.Id == id);
            if (entity == null) return;

            _context.Countries.Remove(entity);
            _context.SaveChanges();
        }
    }
}
