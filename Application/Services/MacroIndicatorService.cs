using Application.Interfaces;
using Application.ViewModels;
using Persistence.Entities;
using Persistence.Persistence;

namespace Application.Services
{
    public class MacroIndicatorService : IMacroIndicatorService
    {
        private readonly InvestmentAppContext _context;

        public MacroIndicatorService(InvestmentAppContext context)
        {
            _context = context;
        }

        public List<MacroIndicatorViewModel> GetAll()
        {
            return _context.MacroIndicators
                .Select(m => new MacroIndicatorViewModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Weight = m.Weight,
                    IsHigherBetter = m.IsHigherBetter
                }).ToList();
        }

        public MacroIndicatorViewModel? GetById(int id)
        {
            var m = _context.MacroIndicators.FirstOrDefault(x => x.Id == id);
            if (m == null) return null;

            return new MacroIndicatorViewModel
            {
                Id = m.Id,
                Name = m.Name,
                Weight = m.Weight,
                IsHigherBetter = m.IsHigherBetter
            };
        }

        public void Add(MacroIndicatorViewModel vm)
        {
            var entity = new MacroIndicator
            {
                Name = vm.Name,
                Weight = vm.Weight,
                IsHigherBetter = vm.IsHigherBetter
            };

            _context.MacroIndicators.Add(entity);
            _context.SaveChanges();
        }

        public void Update(MacroIndicatorViewModel vm)
        {
            var entity = _context.MacroIndicators.FirstOrDefault(x => x.Id ==  vm.Id);
            if (entity == null) return;

            entity.Name = vm.Name;
            entity.Weight = vm.Weight;
            entity.IsHigherBetter = vm.IsHigherBetter;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.MacroIndicators.FirstOrDefault(x => x.Id == id);
            if (entity == null) return;

            _context.MacroIndicators.Remove(entity);
            _context.SaveChanges();
        }
    }
}
