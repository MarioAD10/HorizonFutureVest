using Application.ViewModels;

namespace Application.Interfaces
{
    public interface ICountryService
    {
        List<CountryViewModel> GetAll();
        CountryViewModel? GetById(int id);
        void Add(CountryViewModel vm);
        void Update(CountryViewModel vm);
        void Delete(int id);
    }
}
