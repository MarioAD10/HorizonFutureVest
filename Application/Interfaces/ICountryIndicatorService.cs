using Application.ViewModels;


namespace Application.Interfaces
{
    public interface ICountryIndicatorService
    {
        List<CountryIndicatorViewModel> GetAll();
        CountryIndicatorViewModel? GetById(int id);
        void Add(CountryIndicatorViewModel vm);
        void Update(CountryIndicatorViewModel vm);
        void Delete(int id);
    }
}
