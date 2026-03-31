using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class CountryViewModel
    {
        public  int Id { get; set; }

        [Required(ErrorMessage = "El nombre del país es obligatorio")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El código ISO es obligatorio")]
        [StringLength(5)]
        public string IsoCode { get; set; } = string.Empty;
    }
}
