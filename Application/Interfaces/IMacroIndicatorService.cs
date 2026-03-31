using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IMacroIndicatorService
    {
        List<MacroIndicatorViewModel> GetAll();
        MacroIndicatorViewModel? GetById(int id);
        void Add(MacroIndicatorViewModel vm);
        void Update(MacroIndicatorViewModel vm);
        void Delete(int id);
    }
}
