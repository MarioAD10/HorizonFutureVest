using Application.Interfaces;
using Application.ViewModels;
using Persistence.Entities;
using Persistence.Persistence;

namespace Application.Services
{
    public class ReturnRateConfigService : IReturnRateConfigService
    {
        private readonly InvestmentAppContext _context;

        public ReturnRateConfigService(InvestmentAppContext context)
        {
            _context = context;
        }

        public List<ReturnRateConfigViewModel> GetAll()
        {
            return _context.ReturnRateConfigs
                .Select(r => new ReturnRateConfigViewModel
                {
                    Id = r.Id,
                    MinRate = r.MinRate,
                    MaxRate = r.MaxRate
                }).ToList();
        }

        public ReturnRateConfigViewModel? GetById(int id)
        {
            var r = _context.ReturnRateConfigs.FirstOrDefault(x => x.Id == id);
            if (r == null) return null;

            return new ReturnRateConfigViewModel
            {
                Id = r.Id,
                MinRate = r.MinRate,
                MaxRate = r.MaxRate
            };
        }

        public void Add(ReturnRateConfigViewModel vm)
        {
            var entity = new ReturnRateConfig
            {
                MinRate = vm.MinRate,
                MaxRate = vm.MaxRate
            };
            _context.ReturnRateConfigs.Add(entity);
            _context.SaveChanges();
        }

        public void Update(ReturnRateConfigViewModel vm)
        {
            var entity = _context.ReturnRateConfigs.FirstOrDefault(x => x.Id == vm.Id);
            if (entity == null) return;

            entity.MinRate = vm.MinRate;
            entity.MaxRate = vm.MaxRate;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.ReturnRateConfigs.FirstOrDefault(x => x.Id == id);
            if (entity == null) return;

            _context.ReturnRateConfigs.Remove(entity);
            _context.SaveChanges();
        }
    }
}
