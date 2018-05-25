using SGQP.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGQP.Services.ViewModels
{
    public class ThemeModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome do Tema")]
        public string Name { get; set; }

        public List<Subtheme> Subtemas { get; set; }

        [Required]
        [Display(Name = "Código do Tema")]
        public string ThemeCod { get; set; }
    }
}
