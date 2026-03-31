using System.ComponentModel.DataAnnotations;


namespace Application.ViewModels
{
    public class CountryIndicatorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El país es obligatorio")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "El macroindicador es obligatorio")]
        public int MacroIndicatorId { get; set; }

        [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100")]
        public int Year { get; set; }

        [Required(ErrorMessage = "El valor es obligatorio")]
        public decimal Value { get; set; }
    }
}
