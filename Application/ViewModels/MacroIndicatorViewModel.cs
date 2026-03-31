using System.ComponentModel.DataAnnotations; 

namespace Application.ViewModels
{
    public class MacroIndicatorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del macroindicador es obligatorio")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(0, 1, ErrorMessage = "El peso debe estar entre 0 y 1")]
        public decimal Weight { get; set; }

        [Display(Name = "¿Mayor es mejor?")]
        public bool IsHigherBetter { get; set; } = true;

    }
}
