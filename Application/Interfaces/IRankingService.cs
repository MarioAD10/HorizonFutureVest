using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IRankingService
    {
        List<CountryRankingViewModel> GetRanking(int year);
    }
}

