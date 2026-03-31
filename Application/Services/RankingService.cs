using Application.Interfaces;
using Application.ViewModels;
using Persistence.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class RankingService : IRankingService
    {
        private readonly InvestmentAppContext _context;

        public RankingService(InvestmentAppContext context)
        {
            _context = context;
        }

        public List<CountryRankingViewModel> GetRanking(int year)
        {
            // 1) Obtener indicadores del año especificado
            var indicators = _context.CountryIndicators
                .Include(ci => ci.Country)
                .Include(ci => ci.MacroIndicator)
                .Where(ci => ci.year == year)
                .ToList();

            // 2) Agrupar por país y calcular score ponderado
            var ranking = indicators
                .GroupBy(ci => ci.Country)
                .Select(group =>
                {
                    double score = group.Sum(ci =>
                        (double)ci.value * (double)ci.MacroIndicator.Weight
                    );

                    return new CountryRankingViewModel
                    {
                        CountryId = group.Key.Id,
                        CountryName = group.Key.Name,
                        Score = score
                    };
                })
                .OrderByDescending(r => r.Score)
                .ToList();

            // 3) Asignar posiciones
            for (int i = 0; i < ranking.Count; i++)
            {
                ranking[i].Position = i + 1;
            }

            return ranking;
        }
    }
}

