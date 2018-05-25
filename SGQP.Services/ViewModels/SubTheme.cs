using SGQP.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SGQP.Services.ViewModels
{
    public class SubTheme
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome do Subtema")]
        public string Name { get; set; }

        [Required]
        public Theme ThemeId { get; set; }

        [Required]
        [Display(Name = "Código do Subtema")]
        public string SubThemeCod { get; set; }
    }
}
