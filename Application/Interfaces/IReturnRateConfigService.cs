using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IReturnRateConfigService
    {
        List<ReturnRateConfigViewModel> GetAll();
        ReturnRateConfigViewModel? GetById(int id);
        void Add(ReturnRateConfigViewModel vm);
        void Update(ReturnRateConfigViewModel vm);
        void Delete(int id);
    }
}
