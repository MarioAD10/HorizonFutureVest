using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class ReturnRateConfigViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La tasa mínima es obligatoria")]
        [Range(0, 100, ErrorMessage = "La tasa mínima debe estar entre 0% y 100%")]
        public decimal MinRate { get; set; }

        [Required(ErrorMessage = "La tasa máxima es obligatoria")]
        [Range(0, 100, ErrorMessage = "La tasa máxima debe estar entre 0% y 100%")]
        public decimal MaxRate { get; set; }
    }
}
